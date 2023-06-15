using System;
using Isometric.Player;
using Item;
using UnityEngine;

namespace Isometric.Deco
{
  public sealed class Item : InteractableObject
  {
    private SpriteRenderer sr;
    [NonSerialized]
    public Rigidbody2D rb;
    
    private ItemData _item;
    public ItemData item
    {
      get => _item;
      set
      {
        _item = value;
        sr.sprite = _item.sprite;
      }
    }

    private void Awake()
    {
      sr = GetComponent<SpriteRenderer>();
      rb = GetComponent<Rigidbody2D>();
    }

    public override void Interact()
    {
      base.Interact();
      PlayerManager.Inventory.AddItem(_item, 1);
      Destroy(gameObject, 2f);
      gameObject.SetActive(false);
    }
  }
}