using UnityEngine;
using System.Collections;

public class InventoryItemAgent : MonoBehaviour
{
  public InventoryItem ItemDescription;

  public void OnTriggerEnter(Collider c)
  {
    // make sure we are colliding with the player
    if(c.gameObject.tag.Equals("Player"))
    {
      // Make a copy of the Inventory Item Object
      InventoryItem myItem = new InventoryItem();
      myItem.CopyInventoryItem(this.ItemDescription);

      // Add the item to our inventory
      GameMaster.instance.INVENTORY.AddItem(myItem);

      // Destroy the GameObject from the scene
      GameMaster.instance.RPG_Destroy(this.gameObject);
    }
  }

}
