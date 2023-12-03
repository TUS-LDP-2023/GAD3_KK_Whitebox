using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
[CreateAssetMenu(fileName = "New Inventory", menuName = "ObjectData/Items/Inventory")]

public class Inventory : ScriptableObject
{
   public List<InventorySlot> InventorySlot = new List<InventorySlot>();
    public void AddItem(ObjectData _item, int amount)
    {
        bool hasItem = false;
        for (int i = 0; i < InventorySlot.Count; i++)
        {
            if (InventorySlot[i].item == _item)
            {
                InventorySlot[i].AddAmount(amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            InventorySlot.Add(new InventorySlot(_item, amount));
        }
    }
}
[System.Serializable]
public class InventorySlot
{
    public ObjectData item;
    public int amount;
    public InventorySlot(ObjectData _object, int _amount)
    {
        item = _object;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}

