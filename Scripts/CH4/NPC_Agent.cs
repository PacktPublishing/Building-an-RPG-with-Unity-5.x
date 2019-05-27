using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;

[Serializable]
public class NPC_Agent : MonoBehaviour
{

  [SerializeField]
  public NPC npcData;

  [SerializeField]
  public Transform canvasNPCStatsAttachment;

  [SerializeField]
  public Canvas canvasNPCStats;

  [SerializeField]
  public GameObject canvasNPCStatsPrefab;

  public void SetHealthValue(float value)
  {
    this.canvasNPCStats.GetComponent<NPCStatUI>().imgHealthBar.fillAmount = value;
  }

  public void SetStrengthValue(float value)
  {
    this.canvasNPCStats.GetComponent<NPCStatUI>().imgManaBar.fillAmount = value;
  }

  //// Use this for initialization
  void Start()
  {
    // let's go ahead and instantiate our stats
    GameObject tmpCanvasGO = GameObject.Instantiate(
      this.canvasNPCStatsPrefab,
      this.canvasNPCStatsAttachment.transform.position + this.canvasNPCStatsPrefab.transform.position,
      this.canvasNPCStatsPrefab.transform.rotation) as GameObject;

    tmpCanvasGO.transform.SetParent(this.canvasNPCStatsAttachment);

    this.canvasNPCStats = tmpCanvasGO.GetComponent<Canvas>();
    this.canvasNPCStats.GetComponent<NPCStatUI>().imgHealthBar.fillAmount = 1f;
    this.canvasNPCStats.GetComponent<NPCStatUI>().imgManaBar.fillAmount = 1f;

    NPC tmp = new NPC();
    tmp.TAG = "ENEMY";
    tmp.characterGO = this.transform.gameObject;
    tmp.NAME = "B1";
    tmp.HEALTH = 100.0f;
    tmp.DEFENSE = 50.0f;
    tmp.DESCRIPTION = "The Beast";
    tmp.DEXTERITY = 33.0f;
    tmp.INTELLIGENCE = 80.0f;
    tmp.STRENGTH = 60.0f;


    this.npcData = tmp;
  }

  //// Update is called once per frame
  void Update()
  {
    if (this.npcData.HEALTH < 0.0f)
    {
      this.npcData.HEALTH = 0.0f;

      this.transform.GetComponent<NPC_Movement>().die = true;
    }
  }
}
