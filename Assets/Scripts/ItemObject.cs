using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;
    bool pickable = false;
    public void OnHandlePickupItem()
    {
        InventorySystem.current.Add(referenceItem);
        Destroy(gameObject);
    }

    public void Update()
    {
        if (pickable && Input.GetKeyDown(KeyCode.C))
        {
            OnHandlePickupItem();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        pickable = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        pickable = false;
    }
}
