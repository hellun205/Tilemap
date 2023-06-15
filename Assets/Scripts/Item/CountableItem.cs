using System;

namespace Item
{
  [Serializable]
  public class CountableItem
  {
    public ItemData item;
    
    public uint count;

    public CountableItem(ItemData item, uint count)
    {
      this.item = item;
      this.count = count;
    }
  }
}