using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDElementsUI : MonoBehaviour
{
  public Image imgHealthBar;
  public Image imgManaBar;

  public GameObject activeInventoryItem;
  public GameObject activeSpecialItem;

  public Transform panelActiveInventoryItems;
  public Transform panelActiveSpecialItems;
}
