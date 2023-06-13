using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utils
{
  public static class Utility
  {
    public static Vector3 Setter(this Vector3 v, float? x = null, float? y = null, float? z = null)
      => new Vector3(x ?? v.x, y ?? v.y, z ?? v.z);
    
    public static Color Setter(this Color c, float? r = null, float? g = null, float? b = null, float? a = null)
      => new Color(r ?? c.r, g ?? c.g, b ?? c.b, a ?? c.a);
    
    public static T Random<T>(this IEnumerable<T> enumerable)
    {
      var enumerable1 = enumerable as T[] ?? enumerable.ToArray();
      return enumerable1[UnityEngine.Random.Range(0, enumerable1.Length)];
    }

    public static bool IsEqual(this Color a, Color b) =>
      Mathf.Approximately(a.a, b.a) && Mathf.Approximately(a.r, b.r) &&
      Mathf.Approximately(a.g, b.g) && Mathf.Approximately(a.b, b.b);

    public static bool IsEqual(this Vector2 a, Vector2 b) =>
      Mathf.Approximately(a.x, b.x) && Mathf.Approximately(a.y, b.y);

    public static bool IsEqual(this Vector3 a, Vector3 b) =>
      Mathf.Approximately(a.x, b.x) && Mathf.Approximately(a.y, b.y) && Mathf.Approximately(a.z, b.z);

  }
}