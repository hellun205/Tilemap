using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Isometric
{
  public class HideColliderColor : MonoBehaviour
  {
    private void Start()
    {
      GetComponent<TilemapRenderer>().enabled = false;
    }
  }
}