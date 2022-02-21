using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory { get; private set; }

    public static InventorySystem current;

    public event Action onInventoryChangedEvent;

    private void Awake()
    {
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();

        current = this;//GameObject.Find("Inventory").GetComponent<InventorySystem>();

    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

    public void Add(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
            Debug.Log("Item: " + value.data.id + ". Amount:" + value.stackSize);
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
            for (int i = 0; i < inventory.Count; i++)
            {
                Debug.Log(inventory[i].data.id);
            }
        }
        if (onInventoryChangedEvent != null)
        {
            onInventoryChangedEvent();
        }
    }
    public void Remove(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();
            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
        }
        if (onInventoryChangedEvent != null)
        {
            onInventoryChangedEvent();
        }
    }
    public void RightShuffle()
    {
        //Debug.Log(inventory[0].data.displayName)
        if (inventory.Count <= 1)
        {
            return;
        }
        InventoryItem item = inventory[0];
        inventory.Remove(item);
        inventory.Add(item);
        //Calls for UI update
        if (onInventoryChangedEvent != null)
        {
            onInventoryChangedEvent();
        }
    }
    public void LeftShuffle()
    {
        if (inventory.Count <= 1)
        {
            return;
        }

        InventoryItem item = inventory[inventory.Count-1];
        inventory.Remove(item);
        inventory.Insert(0, item);

        //Calls for UI update
        if (onInventoryChangedEvent != null)
        {
            onInventoryChangedEvent();
        }
    }
}
