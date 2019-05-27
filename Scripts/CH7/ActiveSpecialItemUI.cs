using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ActiveSpecialItemUI : EventTrigger
{

  public override void OnPointerClick(PointerEventData data)
  {
    InventoryItem iia = this.gameObject.GetComponent<ActiveInventoryItemUI>().item;

    switch(iia.CATEGORY)
    {
      case BaseItem.ItemCatrgory.HEALTH:
        {
          // add the item to the special items panel
          GameMaster.instance.UI.ApplySpecialInventoryItem(iia);
          Destroy(this.gameObject);

          break;
        }
      case BaseItem.ItemCatrgory.POTION:
        {
          break;
        }
    }

  }

}
