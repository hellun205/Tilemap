using System.Collections.Generic;
using Item;

namespace Isometric.Deco
{
  public abstract class CollectableObject : InteractableObject
  {
    public List<CountableItem> items;
  }
}