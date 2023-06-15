using Item;
using UnityEngine;
using Utils;

namespace Isometric.Deco
{
  public class RandomChest : Chest
  {
    [Header("Random Var")]
    public byte length = 1;
    public byte minCount = 1;
    public byte maxCount = 1;

    private void Start()
    {
      var itemList = Items.Instance.items;
      for (var i = 0; i < length; i++)
      {
        var randomItem = itemList.Random();
        items.Add(new CountableItem(randomItem, (uint)Random.Range(minCount, maxCount + 1)));
      }
    }
  }
}