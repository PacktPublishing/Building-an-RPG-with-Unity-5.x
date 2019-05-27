using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System;
using System.Collections;
using System.Collections.Generic;

public class GameMaster : MonoBehaviour
{
  public static GameMaster instance;

  // let's have a reference to the player character GameObject
  public GameObject PC_GO;

  // reference to player Character Customization
  public PC PC_CC;
  public InventorySystem INVENTORY;

  public GameObject START_POSITION;

  public GameObject CHARACTER_CUSTOMIZATION;

  public LevelController LEVEL_CONTROLLER;
  public AudioController AUDIO_CONTROLLER;

  // Ref to UI Elements ...
  public bool DISPLAY_SETTINGS = false;
  public bool DISPLAY_INVENTORY = false;

  public UIController UI;

  // Let's have a reference to all NPC (Enemy) GameObjects
  public List<GameObject> goListNPCEnemy;

  public GameObject closestNPCEnemy;


  void Awake()
  {
    // simple singlton
    if (instance == null)
    {
      instance = this;

      instance.DISPLAY_INVENTORY = false;
      instance.DISPLAY_SETTINGS = false;

      // initialize Level Controller
      instance.LEVEL_CONTROLLER = new LevelController();

      // initialize Audio Controller
      instance.AUDIO_CONTROLLER = new AudioController();
      instance.AUDIO_CONTROLLER.AUDIO_SOURCE = GameMaster.instance.GetComponent<AudioSource>();
      instance.AUDIO_CONTROLLER.SetDefaultVolume();

      // initialize Inventory System
      instance.INVENTORY = new InventorySystem();

      instance.goListNPCEnemy = new List<GameObject>();
      instance.closestNPCEnemy = null;

    }
    else if (instance != this)
    {
      Destroy(this);
    }

    // keep the game object when moving from
    // one scene to the next scene
    DontDestroyOnLoad(this);
  }

  #region Player Inventory Items Applied
  public void PlayerWeaponChanged(InventoryItem invItem)
  {
    Debug.Log(string.Format("Weapon changed to: {0}", instance.PC_CC.SELECTED_WEAPON.ToString()));
    GameMaster.instance.PC_GO.GetComponent<CharacterCustomization>().SetWeaponType(GameMaster.instance.PC_CC.SELECTED_WEAPON);
  }

  public void PlayerArmourChanged(InventoryItem item)
  {
    switch (item.TYPE.ToString())
    {
      case "HELMET":
        {
          GameMaster.instance.PC_CC.SELECTED_HELMET = (PC.HELMET_TYPE)Enum.Parse(typeof(PC.HELMET_TYPE), instance.PC_CC.SELECTED_ARMOUR.NAME);
          GameMaster.instance.PC_GO.GetComponent<CharacterCustomization>().SetHelmetType(GameMaster.instance.PC_CC.SELECTED_HELMET);
          break;
        }
      case "SHIELD":
        {
          GameMaster.instance.PC_CC.SELECTED_SHIELD = (PC.SHIELD_TYPE)Enum.Parse(typeof(PC.SHIELD_TYPE), instance.PC_CC.SELECTED_ARMOUR.NAME);
          GameMaster.instance.PC_GO.GetComponent<CharacterCustomization>().SetShieldType(GameMaster.instance.PC_CC.SELECTED_SHIELD);
          break;
        }
      case "SHOULDER_PAD":
        {
          GameMaster.instance.PC_CC.SELECTED_SHOULDER_PAD = (PC.SHOULDER_PAD)Enum.Parse(typeof(PC.SHOULDER_PAD), instance.PC_CC.SELECTED_ARMOUR.NAME);
          GameMaster.instance.PC_GO.GetComponent<CharacterCustomization>().SetShoulderPad(GameMaster.instance.PC_CC.SELECTED_SHOULDER_PAD);
          break;
        }
      case "KNEE_PAD":
        {
          break;
        }
      case "BOOTS":
        {
          break;
        }

    }
  }

  public void PlayerClothingChanged()
  {
    // code to be implemented
  }

  public void PlayerHealthChanged()
  {
    // code to be implemented
  }

  public void PlayerPotionChanged()
  {
    // code to be implemented
  }
  #endregion

  // for each level/scene that has been loaded
  // do some of the preparation work
  void OnLevelWasLoaded()
  {
    GameMaster.instance.LEVEL_CONTROLLER.OnLevelWasLoaded();

    // find all NPC GameObjects of Enemy type
    if(GameObject.FindGameObjectsWithTag("ENEMY").Length>0)
    {
      var tmpGONPCEnemy = GameObject.FindGameObjectsWithTag("ENEMY");

      GameMaster.instance.goListNPCEnemy.Clear();
      foreach(GameObject goTmpNPCEnemy in tmpGONPCEnemy)
      {
        instance.goListNPCEnemy.Add(goTmpNPCEnemy);
      }
    }    
  }

  // Use this for initialization
  void Start()
  {
    // let's find a reference to the UI controller of the loaded scene
    if (GameObject.FindGameObjectWithTag("UI") != null)
    {
      GameMaster.instance.UI = GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>();
    }

    GameMaster.instance.UI.SettingsCanvas.gameObject.SetActive(GameMaster.instance.DISPLAY_SETTINGS);
  }

  // Update is called once per frame
  void Update()
  {
    // only when we are in the game level
    if(instance.LEVEL_CONTROLLER.CURRENT_SCENE.name==SceneName.Level_1)
    {
      if (Input.GetKeyUp(KeyCode.J))
      {
        instance.DISPLAY_INVENTORY = !instance.DISPLAY_INVENTORY;
        instance.UI.DisplayInventory();
      }
    }
  }

  public void MasterVolume(float volume)
  {
    GameMaster.instance.AUDIO_CONTROLLER.MasterVolume(volume);
  }

  public void StartGame()
  {
    GameMaster.instance.LoadLevel();
  }

  public void LoadLevel()
  {
    GameMaster.instance.LEVEL_CONTROLLER.LoadLevel();
  }

  public void RPG_Destroy(GameObject obj)
  {
    Destroy(obj);
  }

  public void PlayerAttackEnemy(float value)
  {
    NPC npc = instance.closestNPCEnemy.GetComponent<NPC_Agent>().npcData;
    npc.HEALTH -= value;
  }

  public void EnemyAttackPlayer(float value)
  {
    instance.PC_CC.HEALTH -= value;
  }
}

