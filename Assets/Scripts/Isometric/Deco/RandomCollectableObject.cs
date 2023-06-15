using Item;
using UnityEngine;
using Utils;

namespace Isometric.Deco
{
  public abstract class RandomCollectableObject : CollectableObject
  {
    [SerializeField]
    private RandomSet set;

    private void Start()
    {
      if (set is null)
        return;
      var itemList = Items.Instance.items;
      for (var i = 0; i < set.length; i++)
      {
        var randomItem = itemList.Random();
        items.Add(new CountableItem(randomItem, (uint)Random.Range(set.minCount, set.maxCount + 1)));
      }
    }
  }
}