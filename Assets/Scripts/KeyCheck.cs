using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheck : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    [SerializeField]
    InventoryItemData IID;

    bool locked = true;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (locked && CheckForItem())
        {
            Debug.Log("True");
            Destroy(door);
            InventorySystem.current.Remove(IID);
            this.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
            Destroy(this.GetComponent<BoxCollider2D>());
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            locked = false;
        }
        else
        {
            Debug.Log("false");
        }
    }

    bool CheckForItem ()
    {
        return InventorySystem.current.Get(IID) != null;
    }


}
