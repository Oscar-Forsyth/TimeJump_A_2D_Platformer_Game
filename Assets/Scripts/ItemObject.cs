using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;
    //bool pickable = false;
    public void OnHandlePickupItem()
    {
        InventorySystem.current.Add(referenceItem);
        Destroy(gameObject);
    }
    void Start()
    {
        //gameObject.transform.position += new Vector3(0.01f, 0f, 0f);
    }
    public void Update()
    {
        if (Pickable() && Input.GetKeyDown(KeyCode.C))
        {
            OnHandlePickupItem();
        }
        
    }
    private bool Pickable()
    {
        Vector2 playerPos = LevelManager.instance.getPlayerPosition();
        Vector2 itemPos = transform.position;

        float dist = Vector2.Distance(playerPos, itemPos);
        return dist < 1f;
       
    }
    

}
