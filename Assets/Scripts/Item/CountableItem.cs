using System;

namespace Item
{
  [Serializable]
  public struct CountableItem
  {
    public ItemData item;
    
    public uint count;
  }
}