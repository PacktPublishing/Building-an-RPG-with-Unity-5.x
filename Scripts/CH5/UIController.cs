using UnityEngine;
using UnityEngine.UI;

using System;

public class UIController : MonoBehaviour
{
  public Canvas SettingsCanvas;
  public Slider ControlMainVolume;

  // the canvas object for inventory system
  public Canvas InventoryCanvas;

  public Transform PanelItem;
  public GameObject InventoryItemElement;

  public HUDElementsUI hudUI;

  public void Update()
  {

  }

  public void DisplaySettings()
  {
    GameMaster.instance.DISPLAY_SETTINGS = !GameMaster.instance.DISPLAY_SETTINGS;
    this.SettingsCanvas.gameObject.SetActive(GameMaster.instance.DISPLAY_SETTINGS);
  }

  public void MainVolume()
  {
    GameMaster.instance.MasterVolume(ControlMainVolume.value);
  }

  public void StartGame()
  {
    GameMaster.instance.StartGame();
  }

  public void LoadLevel()
  {
    if (GameObject.FindGameObjectWithTag("BASE"))
    {
      GameMaster.instance.PC_CC = GameObject.FindGameObjectWithTag("BASE").GetComponent<CharacterCustomization>().PC_CC;
    }
    GameMaster.instance.LEVEL_CONTROLLER.LEVEL = 1;
    GameMaster.instance.LoadLevel();
  }

  public void DisplayInventory()
  {
    this.InventoryCanvas.gameObject.SetActive(GameMaster.instance.DISPLAY_INVENTORY);
  }

  private void ClearInventoryItemsPanel()
  {
    while(this.PanelItem.childCount>0)
    {
      Transform t = this.PanelItem.GetChild(0).transform;
      t.parent = null;
      Destroy(t.gameObject);
    }
  }


  public void DisplayWeaponsCategory()
  {
    if(GameMaster.instance.DISPLAY_INVENTORY)
    {
      this.ClearInventoryItemsPanel();

      foreach (InventoryItem item in GameMaster.instance.INVENTORY.WEAPONS)
      {
        GameObject objItem = GameObject.Instantiate(this.InventoryItemElement) as GameObject;
        InventoryItemUI invItem = objItem.GetComponent<InventoryItemUI>();
        invItem.txtItemElement.text =
          string.Format("Name: {0}, Description: {1}, Strength: {2}, Weight: {3}",
                                  item.NAME,
                                  item.DESCRIPTION,
                                  item.STRENGTH,
                                  item.WEIGHT);


        invItem.item = item;

        // add button triggers
        invItem.butAdd.GetComponent<Button>().onClick.AddListener(() =>
        {
          Debug.Log(string.Format("You have clicked button add for {0}, {1}", invItem.txtItemElement.text, invItem.item.NAME));

          // let's apply the selected item to the player character
          GameMaster.instance.PC_CC.SELECTED_WEAPON = (PC.WEAPON_TYPE)Enum.Parse(typeof(PC.WEAPON_TYPE), invItem.item.NAME);
          GameMaster.instance.PlayerWeaponChanged(invItem.item);
          this.AddActiveInventoryItem(invItem.item);
        });

        // delete button triggers
        invItem.butDelete.GetComponent<Button>().onClick.AddListener(() =>
        {
          Debug.Log(string.Format("You have clicked button delete for {0}", invItem.txtItemElement.text));
          Destroy(objItem);
        });

        objItem.transform.SetParent(this.PanelItem);
      }

    }
  }

  public void DisplayArmourCategory()
  {
    if (GameMaster.instance.DISPLAY_INVENTORY)
    {
      this.ClearInventoryItemsPanel();

      foreach (InventoryItem item in GameMaster.instance.INVENTORY.ARMOUR)
      {
        GameObject objItem = GameObject.Instantiate(this.InventoryItemElement) as GameObject;
        InventoryItemUI invItem = objItem.GetComponent<InventoryItemUI>();
        invItem.txtItemElement.text =
          string.Format("Name: {0}, Description: {1}, Strength: {2}, Weight: {3}",
                                  item.NAME,
                                  item.DESCRIPTION,
                                  item.STRENGTH,
                                  item.WEIGHT);

        invItem.item = item;

        // add button triggers
        invItem.butAdd.GetComponent<Button>().onClick.AddListener(() =>
        {
          Debug.Log(string.Format("You have clicked button add for {0}, {1}", invItem.txtItemElement.text, invItem.item.NAME));

          // let's apply the selected item to the player character
          GameMaster.instance.PC_CC.SELECTED_ARMOUR = invItem.item;
          GameMaster.instance.PlayerArmourChanged(invItem.item);
          this.AddActiveInventoryItem(invItem.item);
        });

        // delete button triggers
        invItem.butDelete.GetComponent<Button>().onClick.AddListener(() =>
        {
          Debug.Log(string.Format("You have clicked button delete for {0}", invItem.txtItemElement.text));
          Destroy(objItem);
        });

        objItem.transform.SetParent(this.PanelItem);
      }
    }
  }

  public void DisplayClothingCategory()
  {
    if (GameMaster.instance.DISPLAY_INVENTORY)
    {
      this.ClearInventoryItemsPanel();

      foreach (InventoryItem item in GameMaster.instance.INVENTORY.CLOTHING)
      {
        GameObject objItem = GameObject.Instantiate(this.InventoryItemElement) as GameObject;
        InventoryItemUI invItem = objItem.GetComponent<InventoryItemUI>();
        invItem.txtItemElement.text =
          string.Format("Name: {0}, Description: {1}, Strength: {2}, Weight: {3}",
                                  item.NAME,
                                  item.DESCRIPTION,
                                  item.STRENGTH,
                                  item.WEIGHT);

        invItem.item = item;

        // add button triggers
        invItem.butAdd.GetComponent<Button>().onClick.AddListener(() =>
        {
          Debug.Log(string.Format("You have clicked button add for {0}", invItem.txtItemElement.text));

          
        });

        // delete button triggers
        invItem.butDelete.GetComponent<Button>().onClick.AddListener(() =>
        {
          Debug.Log(string.Format("You have clicked button delete for {0}", invItem.txtItemElement.text));
          Destroy(objItem);
        });

        objItem.transform.SetParent(this.PanelItem);
      }
    }
  }

  public void DisplayHealthCategory()
  {
    if (GameMaster.instance.DISPLAY_INVENTORY)
    {
      this.ClearInventoryItemsPanel();

      foreach (InventoryItem item in GameMaster.instance.INVENTORY.HEALTH)
      {
        GameObject objItem = GameObject.Instantiate(this.InventoryItemElement) as GameObject;
        InventoryItemUI invItem = objItem.GetComponent<InventoryItemUI>();
        invItem.txtItemElement.text =
          string.Format("Name: {0}, Description: {1}, Strength: {2}, Weight: {3}",
                                  item.NAME,
                                  item.DESCRIPTION,
                                  item.STRENGTH,
                                  item.WEIGHT);

        invItem.item = item;

        // add button triggers
        invItem.butAdd.GetComponent<Button>().onClick.AddListener(() =>
        {
          Debug.Log(string.Format("You have clicked button add for {0}", invItem.txtItemElement.text));

          // let's apply the selected item to the player character
          GameMaster.instance.PC_CC.HEALTH += invItem.item.STRENGTH * 100;
          if(GameMaster.instance.PC_CC.HEALTH>100f)
          {
            GameMaster.instance.PC_CC.HEALTH = 100f;
          }

          GameMaster.instance.INVENTORY.DeleteItem(invItem.item);

          Destroy(objItem);

        });

        // delete button triggers
        invItem.butDelete.GetComponent<Button>().onClick.AddListener(() =>
        {
          Debug.Log(string.Format("You have clicked button delete for {0}", invItem.txtItemElement.text));
          Destroy(objItem);
        });

        objItem.transform.SetParent(this.PanelItem);
      }

    }
  }

  public void DisplayPotionsCategory()
  {
    if (GameMaster.instance.DISPLAY_INVENTORY)
    {
      this.ClearInventoryItemsPanel();

      foreach (InventoryItem item in GameMaster.instance.INVENTORY.POTIONS)
      {
        GameObject objItem = GameObject.Instantiate(this.InventoryItemElement) as GameObject;
        InventoryItemUI invItem = objItem.GetComponent<InventoryItemUI>();
        invItem.txtItemElement.text =
          string.Format("Name: {0}, Description: {1}, Strength: {2}, Weight: {3}",
                                  item.NAME,
                                  item.DESCRIPTION,
                                  item.STRENGTH,
                                  item.WEIGHT);

        invItem.item = item;

        // add button triggers
        invItem.butAdd.GetComponent<Button>().onClick.AddListener(() =>
        {
          Debug.Log(string.Format("You have clicked button add for {0}", invItem.txtItemElement.text));
        });

        // delete button triggers
        invItem.butDelete.GetComponent<Button>().onClick.AddListener(() =>
        {
          Debug.Log(string.Format("You have clicked button delete for {0}", invItem.txtItemElement.text));
          Destroy(objItem);
        });

        objItem.transform.SetParent(this.PanelItem);
      }

    }
  }

  #region Adding Active Inventory Item to the UI
  public void AddActiveInventoryItem(InventoryItem item)
  {
    // Make a copy of the Inventory Item Object
    InventoryItem myItem = new InventoryItem();
    myItem.CopyInventoryItem(item);

    GameObject objItem = GameObject.Instantiate(this.hudUI.activeInventoryItem) as GameObject;
    ActiveInventoryItemUI aeUI = objItem.GetComponent<ActiveInventoryItemUI>();
    aeUI.txtActiveItem.text = myItem.NAME.ToString();

    aeUI.item = myItem;

    objItem.transform.SetParent(this.hudUI.panelActiveInventoryItems);

    LayoutRebuilder.MarkLayoutForRebuild(this.hudUI.panelActiveInventoryItems as RectTransform);
  }

  public void AddSpecialInventoryItem(InventoryItem item)
  {
    // Make a copy of the Inventory Item Object
    InventoryItem myItem = new InventoryItem();
    myItem.CopyInventoryItem(item);

    GameObject objItem = GameObject.Instantiate(this.hudUI.activeSpecialItem) as GameObject;
    ActiveInventoryItemUI aeUI = objItem.GetComponent<ActiveInventoryItemUI>();
    aeUI.txtActiveItem.text = myItem.NAME.ToString();
    aeUI.item = myItem;

    objItem.transform.SetParent(this.hudUI.panelActiveSpecialItems);

    LayoutRebuilder.MarkLayoutForRebuild(this.hudUI.panelActiveSpecialItems as RectTransform);
  }

  public void ApplySpecialInventoryItem(InventoryItem item)
  {
    GameMaster.instance.PC_CC.HEALTH += item.STRENGTH * 100;
    if (GameMaster.instance.PC_CC.HEALTH > 100f)
    {
      GameMaster.instance.PC_CC.HEALTH = 100f;
    }

    GameMaster.instance.INVENTORY.DeleteItem(item);
  }
  #endregion

}
