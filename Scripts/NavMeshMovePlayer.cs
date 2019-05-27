using UnityEngine;
using System.Collections;

public class NavMeshMovePlayer : MonoBehaviour {

   public NavMeshAgent navMeshAgent;
   public Animator myAnimator;

   public Vector3 movePosition;

   public bool WALKING = false;
   public bool RUNNING = false;

   public AudioSource myAudioSource;
   public AudioClip[] audioClips;

	// Use this for initialization
	void Start () {
      this.navMeshAgent = GetComponent<NavMeshAgent>();
      this.myAnimator = GetComponent<Animator>();

      this.myAudioSource = GetComponent<AudioSource>();

      myAudioSource.PlayOneShot(audioClips[0], 1);

   }

   // Update is called once per frame
   void Update()
   {
      if(Input.GetMouseButtonUp(0))
      {
         RaycastHit hit;
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

         Debug.Log(ray.ToString());

         if (Physics.Raycast(ray, out hit, Mathf.Infinity))
         {
            this.WALKING = true;
            this.movePosition = hit.point;

            myAudioSource.PlayOneShot(audioClips[1], 1);

         }
      }

      if (Input.GetKeyUp(KeyCode.LeftShift))
      {
         this.RUNNING = true;
         this.WALKING = false;

         this.navMeshAgent.speed = 5.0f;
      }

      if(Input.GetKey(KeyCode.None))
      {
         this.RUNNING = false;
         this.WALKING = true;

         this.navMeshAgent.speed = 3.5f;
      }


      if (this.WALKING)
      {
         this.myAnimator.SetBool("WALK", this.WALKING);
         this.navMeshAgent.SetDestination(this.movePosition);
      }
      if(this.RUNNING)
      {
         this.myAnimator.SetBool("RUNNING", this.RUNNING);
         this.navMeshAgent.SetDestination(this.movePosition);
      }

      if (this.transform.position.x == this.movePosition.x && this.transform.position.z == this.movePosition.z)
      {
         this.WALKING = false;
         this.RUNNING = false;

         this.myAnimator.SetBool("WALK", this.WALKING);
         this.myAnimator.SetBool("RUNNING", this.RUNNING);

         this.navMeshAgent.speed = 3.5f;
      }

      Debug.Log(this.navMeshAgent.pathStatus);
   }

   void OnCollisionEnter(Collision c)
   {
      Debug.Log(c.transform.tag);
      if(c.transform.tag.Equals("STOPPER"))
      {
         this.WALKING = false;
         this.RUNNING = false;

         this.myAnimator.SetBool("WALK", this.WALKING);
         this.myAnimator.SetBool("RUNNING", this.RUNNING);

         this.navMeshAgent.speed = 3.5f;
      }
   }
}
