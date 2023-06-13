using UnityEngine;

namespace Item
{
  [CreateAssetMenu(fileName = "Item", menuName = "Data/Item", order = 0)]
  public class ItemData : ScriptableObject
  {
    public string _name;

    [Multiline]
    public string descriptions;

    public Sprite sprite;
  }
}