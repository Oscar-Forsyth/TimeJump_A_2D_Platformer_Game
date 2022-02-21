using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheck : MonoBehaviour
{
    [SerializeField]
    InventoryItemData IID;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckForItem())
        {
            Debug.Log("true");
        }
        else
        {
            Debug.Log("faöse");
        }
    }

    bool CheckForItem ()
    {
        return InventorySystem.current.Get(IID) != null;
    }


}
