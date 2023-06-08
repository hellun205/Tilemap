using UnityEngine;

namespace Utils
{
  public static class Utility
  {
    public static Vector3 Setter(this Vector3 v, float? x = null, float? y = null, float? z = null)
      => new Vector3(x ?? v.x, y ?? v.y, z ?? v.z);
  }
}