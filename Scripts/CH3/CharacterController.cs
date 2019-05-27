using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{

  public Animator animator;

  public float speed = 6.0f;
  public float h = 0.0f;
  public float v = 0.0f;

  public bool attack1 = false;  // used for attack mode 1
  public bool attack2 = false;  // used for attack mode 2
  public bool attack3 = false;  // used for attack mode 3

  public bool jump = false;     // used for jumping
  public bool die = false;      // are we alive?

  public bool DEBUG = false;

  // Reference to the sphere collider trigger component.
  private SphereCollider col;

  // where is the player character in relation to NPC
  public Vector3 direction;

  // how far away is the player character from NPC
  public float distance = 0.0f;

  // what is the angle between the PC and NPC
  public float angle = 0.0f;

  // is the PC in sight?
  public bool enemyInSight;

  // what is the field of view for our NPC?
  // currently set to 110 degrees
  public float fieldOfViewAngle = 110.0f;

  // calculate the angle between PC and NPC
  public float calculatedAngle;



  // Use this for initialization
  void Start()
  {
    this.animator = GetComponent<Animator>() as Animator;

    // we don't see the player by default
    this.enemyInSight = false;
  }

  // Update is called once per frame
  private Vector3 moveDirection = Vector3.zero;

  Quaternion startingAngle = Quaternion.AngleAxis(-60, Vector3.up);
  Quaternion stepAngle = Quaternion.AngleAxis(5, Vector3.up);
  Vector3 viewDistance = new Vector3(0, 0, 30);

  Quaternion startingAttackAngle = Quaternion.AngleAxis(-25, Vector3.up);
  Quaternion stepAttackAngle = Quaternion.AngleAxis(5, Vector3.up);
  Vector3 attackDistance = new Vector3(0, 0, 2);

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.C))
    {
      this.attack1 = true;
      this.GetComponent<IKHandle>().enabled = false;
    }
    if (Input.GetKeyUp(KeyCode.C))
    {
      this.attack1 = false;
      this.GetComponent<IKHandle>().enabled = true;
    }
    animator.SetBool("Attack1", attack1);

    if (Input.GetKeyDown(KeyCode.Z))
    {
      this.attack2 = true;
      this.GetComponent<IKHandle>().enabled = false;
    }
    if (Input.GetKeyUp(KeyCode.Z))
    {
      this.attack2 = false;
      this.GetComponent<IKHandle>().enabled = true;
    }
    animator.SetBool("Attack2", attack2);

    if (Input.GetKeyDown(KeyCode.X))
    {
      this.attack3 = true;
      this.GetComponent<IKHandle>().enabled = false;
    }
    if (Input.GetKeyUp(KeyCode.X))
    {
      this.attack3 = false;
      this.GetComponent<IKHandle>().enabled = true;
    }
    animator.SetBool("Attack3", attack3);

    if (Input.GetKeyDown(KeyCode.Space))
    {
      this.jump = true;
      this.GetComponent<IKHandle>().enabled = false;
    }
    if (Input.GetKeyUp(KeyCode.Space))
    {
      this.jump = false;
      this.GetComponent<IKHandle>().enabled = true;
    }
    animator.SetBool("Jump", jump);

    if (Input.GetKeyDown(KeyCode.I))
    {
      this.die = true;
      SendMessage("Died");
    }
    animator.SetBool("Die", die);

  }

  void FixedUpdate()
  {
    // The Inputs are defined in the Input Manager
    h = Input.GetAxis("Horizontal"); // get value for horizontal axis
    v = Input.GetAxis("Vertical");   // get value for vertical axis

    speed = new Vector2(h, v).sqrMagnitude;

    if (DEBUG)
      Debug.Log(string.Format("H:{0} - V:{1} - Speed:{2}", h, v, speed));

    animator.SetFloat("Speed", speed);
    animator.SetFloat("Horizontal", h);
    animator.SetFloat("Vertical", v);

    // We have three different attack modes, we have only implemented the curve parameter for attack1
    // therefore, during game play if you use attack2/attack3 you will see the visual attack happening
    // but the data will not reflect
    if (this.attack1 || this.attack2 || this.attack3)
    {
      #region used for attack range
      RaycastHit hitAttack;
      var angleAttack = transform.rotation * startingAttackAngle;
      var directionAttack = angleAttack * attackDistance;
      var posAttack = transform.position + Vector3.up;
      for (var i = 0; i < 10; i++)
      {
        Debug.DrawRay(posAttack, directionAttack, Color.yellow);
        if (Physics.Raycast(posAttack, directionAttack, out hitAttack, 1.0f))
        {
          var enemy = hitAttack.collider.GetComponent<NPC_Agent>();
          if (enemy)
          {
            //Enemy was seen
            if(DEBUG)
              Debug.Log(string.Format("Detected: {0}", enemy.npcData.NAME));
            this.enemyInSight = true;
            GameMaster.instance.closestNPCEnemy = hitAttack.collider.gameObject;
          }
          else
          {
            this.enemyInSight = false;
          }
        }
        directionAttack = stepAngle * directionAttack;
      }
      #endregion

      if (enemyInSight)
      {
        if (animator.GetFloat("Attack1C") == 1.0f)
        {
          PC pc = this.gameObject.GetComponent<PlayerAgent>().playerCharacterData;
          float impact = (pc.STRENGTH + pc.HEALTH) / 100.0f;
          GameMaster.instance.PlayerAttackEnemy(impact);
        }
      }

    }

  }


}
