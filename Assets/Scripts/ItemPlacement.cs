using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacement : MonoBehaviour

   
{
    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            InventorySystem.current.LeftShuffle();
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            InventorySystem.current.RightShuffle();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            PlaceItem();
        }
    }

    void PlaceItem()
    {
        if (InventorySystem.current.inventory.Count < 1)
        {
            return;
        }
        
        
        InventoryItemData item = InventorySystem.current.inventory[0].data;
        Instantiate(item.prefab, transform.position , Quaternion.identity);
        InventorySystem.current.Remove(item);
    }
}
