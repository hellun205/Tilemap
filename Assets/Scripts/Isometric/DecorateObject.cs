using System;
using UnityEngine;

namespace Isometric
{
  public class DecorateObject : MonoBehaviour
  {
    private const string FrontOrder = "DecoFront";
    private const string BackOrder = "DecoBack";
    
    private SpriteRenderer sr;

    private void Awake()
    {
      sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      
      if (other.CompareTag("Player") && other.isTrigger)
       sr.sortingLayerName = FrontOrder;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      if (other.CompareTag("Player") && other.isTrigger)
        sr.sortingLayerName = BackOrder;
    }
  }
}