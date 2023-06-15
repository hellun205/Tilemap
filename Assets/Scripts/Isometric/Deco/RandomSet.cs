using UnityEngine;

namespace Isometric.Deco
{
  [CreateAssetMenu(fileName = "RandomSet", menuName = "Data/RandomSet", order = 0)]
  public class RandomSet : ScriptableObject
  {
    public byte length = 1;
    public byte minCount = 1;
    public byte maxCount = 1;
  }
}