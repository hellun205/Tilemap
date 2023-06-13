using System.Collections.Generic;
using System.Linq;
using Item;
using UnityEngine;

namespace Isometric.Player
{
  public class PlayerInventory : MonoBehaviour
  {
    public delegate void InventoryEventListener(PlayerInventory sender);

    public event InventoryEventListener OnInventoryChanged;
    
    public Dictionary<ItemData, uint> items = new(); 

    public void AddItem(ItemData item, uint count)
    {
      if (items.ContainsKey(item))
      {
        items[item] += count;
      }
      else
      {
        items.Add(item, count);
      }
      OnInventoryChanged?.Invoke(this);
    }

    public void RemoveItem(ItemData item, uint count)
    {
      if (items.ContainsKey(item))
      {
        if (count < items[item])
        {
          items[item] -= count;
        }
        else
        {
          items.Remove(item);
        }
        OnInventoryChanged?.Invoke(this);
      }
    }

    public bool HasItem(ItemData item, uint count = 1)
    {
      return items.ContainsKey(item) && items[item] >= count;
    }
  }
}