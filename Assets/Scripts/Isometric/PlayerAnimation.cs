using System;
using UnityEngine;

namespace Isometric
{
  public class PlayerAnimation : MonoBehaviour
  {
    public const string Static = "Static";
    
    public const string Run = "Run";
    
    public static readonly string[] Dir = new[] { "N", "NW", "W", "SW", "S" , "SE", "E", "NE" };

    [SerializeField]
    private Animator anim;

    private int lastDir = 5;

    public void SetDirection(Vector2 direction)
    {
      if (direction.magnitude < 0.01)
      {
        anim.Play($"{Static}{Dir[lastDir]}");
      }
      else
      {
        lastDir = DirectionToInt(direction);
        anim.Play($"{Run}{Dir[lastDir]}");
      }
    }

    private int DirectionToInt(Vector2 dir)
    {
      var norDir = dir.normalized;
      const int step = 360 / 8;
      const int offset = step / 2;

      var angle = Vector2.SignedAngle(Vector2.up, norDir);
      angle += offset;

      if (angle < 0)
        angle += 360;

      var stepCount = angle / step;
      return Mathf.FloorToInt(stepCount);
    }
  }
}