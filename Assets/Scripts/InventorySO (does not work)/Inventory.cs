using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();

    public void AddItem(ItemObject _item, int _itemAmount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_itemAmount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            Container.Add(new InventorySlot(_item, _itemAmount));
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int itemAmount;

    public InventorySlot(ItemObject _item, int _itemAmount)
    {
        item = _item;
        itemAmount = _itemAmount;
    }

    public void AddAmount(int value)
    {
        itemAmount += value;
    }
}
