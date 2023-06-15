using System;
using System.Collections.Generic;
using System.Linq;
using Animation.Preset;
using Isometric.Deco;
using Isometric.Player;
using Item;
using JetBrains.Annotations;
using Manager;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
  public sealed class InventoryUI : SingleTon<InventoryUI>
  {
    private PanelVisibler panelVisibler;

    [SerializeField]
    private GameObject contents;

    [SerializeField]
    private ItemUI itemPrefab;

    [SerializeField]
    private PlayerInventory inventory;
    
    public List<ItemUI> items = new();

    public KeyCode key = KeyCode.E;

    protected override void Awake()
    {
      base.Awake();
      panelVisibler = new PanelVisibler(this);
      inventory.OnInventoryChanged += _ => Refresh();
    }

    private bool isOpen;

    public void Open()
    {
      panelVisibler.Show();
      isOpen = true;
    }

    public void Close()
    {
      panelVisibler.Hide();
      isOpen = false;
    }

    public void Refresh()
    {
      Clear();
      foreach (var item in inventory.items)
      {
        var uiObj = Instantiate(itemPrefab, contents.transform);
        uiObj.index = inventory.items.Keys.ToList().IndexOf(item.Key);
        uiObj.sprite = item.Key.sprite;
        uiObj.itemName = item.Key._name;
        uiObj.count = item.Value;
        uiObj.interAction = SellItem;
        items.Add(uiObj);
      }
    }

    private void SellItem(PointerEventData obj, int index)
    {
      var item = inventory.items.Keys.ToList()[index];
      if (Items.Instance.crystals.Any(x => x == item))
        return;
      inventory.RemoveItem(item, 1);
      Timer.Instance.AddTime(0.7f);
      Refresh();
    }

    private void Clear()
    {
      items.ForEach(item => Destroy(item.gameObject));
      items.Clear();
    }

    private void Update()
    {
      if (Input.GetKeyDown(key))
      {
        if (isOpen)
          Close();
        else
          Open();
      }
    }
  }
}