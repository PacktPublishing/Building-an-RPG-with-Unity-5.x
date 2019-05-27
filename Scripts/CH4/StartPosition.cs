using UnityEngine;
using System.Collections;

public class StartPosition : MonoBehaviour
{
  GameObject PC;

  float timeBuffer = 0.5f;
  float setTime = 0.0f;

  void Awake()
  {
    GameObject START_POSITION = GameObject.FindGameObjectWithTag("START_POSITION") as GameObject;
    this.PC = GameObject.FindGameObjectWithTag("Player") as GameObject;

    if (START_POSITION != null && PC != null)
    {
      this.PC.transform.position = START_POSITION.transform.position;
      this.PC.transform.rotation = START_POSITION.transform.rotation;

      this.PC.GetComponent<IKHandle>().enabled = false;
    }

    this.setTime = Time.deltaTime + this.timeBuffer;
  }

  // Use this for initialization
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    if(Time.deltaTime>this.setTime)
    {
      this.PC.GetComponent<IKHandle>().enabled = true;
    }
  }
}
