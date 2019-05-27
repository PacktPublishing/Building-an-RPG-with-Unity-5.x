using UnityEngine;
using System.Collections;

public class NPC_Sight : MonoBehaviour
{
    // Number of degrees, centred on forward, for the enemy see.
    public float fieldOfViewAngle = 110f;
    // Whether or not the player is currently sighted.
    public bool playerInSight;
    // Last place this enemy spotted the player.
    public Vector3 personalLastSighting;

    // Reference to the NavMeshAgent component.
    private NavMeshAgent nav;
    // Reference to the sphere collider trigger component.
    private SphereCollider col;
    // Reference to the Animator.
    private Animator anim;

    // Reference to the player.
    private GameObject player;
    // Reference to the player's animator component.
    private Animator playerAnim;

    public float playerHealth = 100.0f;

    public float deadZone = 5.0f;
    public float distance = 0.0f;
    public Vector3 direction;

    public bool DEBUG = false;
    public bool DEBUG_DRAW = false;

    void Awake()
    {
        // Setting up the references.
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = player.GetComponent<Animator>();
    }


    void Update()
    {

    }

    void FixedUpdate()
    {
      if (playerHealth > 0.0f)
        anim.SetBool("PlayerInSight", playerInSight);

      NavAnimSetup();

    }

    void OnTriggerStay(Collider other)
    {
        if (DEBUG)
            Debug.Log("Entered the Collider");

        // If the player has entered the trigger sphere...
        if (other.gameObject == player)
        {
            if (DEBUG)
                Debug.Log("Player Hit Collider");

            // By default the player is not in sight.
            playerInSight = false;

            // Create a vector from the enemy to the player and store the angle between it and forward.
            direction = other.transform.position - transform.position;

            distance = Vector3.Distance(other.transform.position, transform.position);

            float angle = Vector3.Angle(direction, transform.forward);

            if (DEBUG_DRAW)
                Debug.DrawLine(other.transform.position, transform.position, Color.cyan);

            // If the angle between forward and where the player is, is less than half the angle of view...
            if (angle < fieldOfViewAngle * 0.5f)
            {
                RaycastHit hit;

                if (DEBUG_DRAW)
                    Debug.DrawRay(transform.position + transform.up, direction.normalized, Color.magenta);

                // ... and if a raycast towards the player hits something...
                if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
                {
                    // ... and if the raycast hits the player...
                    if (hit.collider.gameObject == player)
                    {
                        // ... the player is in sight.
                        playerInSight = true;

                        if (DEBUG)
                            Debug.Log("PlayerInSight: " + playerInSight);
                    }
                }
            }
            else
            {
                distance = 0f;
            }

            if (playerInSight)
            {
                nav.SetDestination(player.transform.position);

                CalculatePathLength(player.transform.position);

                if (distance < 1.5f)
                {
                    anim.SetBool("Attack", true);
                    anim.SetBool("Attack1", true);
                }
            }
            else
            {
                anim.SetBool("Attack", false);
                anim.SetBool("Attack1", false);
            }
        }
    }


    void OnTriggerExit(Collider other)
    {
        // If the player leaves the trigger zone...
        if (other.gameObject == player)
            // ... the player is not in sight.
            playerInSight = false;
    }


    float CalculatePathLength(Vector3 targetPosition)
    {
        // Create a path and set it based on a target position.
        NavMeshPath path = new NavMeshPath();
        if (nav.enabled)
            nav.CalculatePath(targetPosition, path);

        // Create an array of points which is the length of the number of corners in the path + 2.
        Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];

        // The first point is the enemy's position.
        allWayPoints[0] = transform.position;

        // The last point is the target position.
        allWayPoints[allWayPoints.Length - 1] = targetPosition;

        // The points inbetween are the corners of the path.
        for (int i = 0; i < path.corners.Length; i++)
        {
            allWayPoints[i + 1] = path.corners[i];
        }

        // Create a float to store the path length that is by default 0.
        float pathLength = 0;

        // Increment the path length by an amount equal to the distance between each waypoint and the next.
        for (int i = 0; i < allWayPoints.Length - 1; i++)
        {
            pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);

            if (DEBUG_DRAW)
                Debug.DrawLine(allWayPoints[i], allWayPoints[i + 1], Color.red);
        }

        return pathLength;
    }

    public float speedDampTime = 0.1f;              // Damping time for the Speed parameter.
    public float angularSpeedDampTime = 0.7f;       // Damping time for the AngularSpeed parameter
    public float angleResponseTime = 0.6f;          // Response time for turning an angle into angularSpeed.

    void NavAnimSetup()
    {
        // Create the parameters to pass to the helper function.
        float speed;
        float angle;

        // If the player is in sight...
        if (!playerInSight)
        {
            // ... the enemy should stop...
            speed = 0.0f;

            // ... and the angle to turn through is towards the player.
            angle = FindAngle(transform.forward, player.transform.position - transform.position, transform.up);

            anim.SetBool("Attack", false);
        }
        else
        {
            // Otherwise the speed is a projection of desired velocity on to the forward vector...
            speed = distance;

            // ... and the angle is the angle between forward and the desired velocity.
            angle = FindAngle(transform.forward, nav.desiredVelocity, transform.up);


            // If the angle is within the deadZone...
            if (Mathf.Abs(angle) < deadZone)
            {
                // ... set the direction to be along the desired direction and set the angle to be zero.
                transform.LookAt(transform.position + nav.desiredVelocity);
                angle = 0f;
            }
        }

        Debug.Log(string.Format("Speed:{0} Angle:{1}", speed, angle));

        // Call the Setup function of the helper class with the given parameters.
        float angularSpeed = angle / angleResponseTime;

        // Set the mecanim parameters and apply the appropriate damping to them.
        anim.SetFloat("Speed", speed, speedDampTime, Time.deltaTime);
        anim.SetFloat("AngularSpeed", angularSpeed, angularSpeedDampTime, Time.deltaTime);

    }


    float FindAngle(Vector3 fromVector, Vector3 toVector, Vector3 upVector)
    {
        // If the vector the angle is being calculated to is 0...
        if (toVector == Vector3.zero)
            // ... the angle between them is 0.
            return 0f;

        // Create a float to store the angle between the facing of the enemy and the direction it's travelling.
        float angle = Vector3.Angle(fromVector, toVector);

        // Find the cross product of the two vectors (this will point up if the velocity is to the right of forward).
        Vector3 normal = Vector3.Cross(fromVector, toVector);

        // The dot product of the normal with the upVector will be positive if they point in the same direction.
        angle *= Mathf.Sign(Vector3.Dot(normal, upVector));

        // We need to convert the angle we've found from degrees to radians.
        angle *= Mathf.Deg2Rad;

        return angle;
    }
}
