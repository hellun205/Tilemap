using System;

namespace Item
{
  [Serializable]
  public class CountableItem
  {
    public ItemData item;
    
    public uint count;
  }
}