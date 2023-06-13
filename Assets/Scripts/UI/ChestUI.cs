using System;
using System.Collections.Generic;
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
  public class ChestUI : SingleTon<ChestUI>
  {
    private PanelVisibler panelVisibler;

    [SerializeField]
    private GameObject contents;

    [SerializeField]
    private ItemUI itemPrefab;

    [CanBeNull]
    private Chest _chest;

    public Chest chest
    {
      get => _chest;
      set
      {
        _chest = value;
        Refresh();
      }
    }

    public List<ItemUI> items = new();

    [SerializeField]
    private PlayerInventory inventory;

    protected override void Awake()
    {
      base.Awake();
      panelVisibler = new PanelVisibler(this);
    }

    public void Open(Chest chest)
    {
      this.chest = chest;
      panelVisibler.Show();
    }

    public void Close()
    {
      panelVisibler.Hide();
      this.chest = null;
    }

    public void Refresh()
    {
      if (chest is null)
        return;
      Clear();
      foreach (var item in chest.items)
      {
        var uiObj = Instantiate(itemPrefab, contents.transform);
        uiObj.index = chest.items.IndexOf(item);
        uiObj.sprite = item.item.sprite;
        uiObj.itemName = item.item._name;
        uiObj.count = item.count;
        uiObj.interAction = GetItem;
        items.Add(uiObj);
      }
    }

    private void GetItem(PointerEventData obj, int index)
    {
      var item = chest.items[index];
      inventory.AddItem(item.item , item.count);
      chest.items.RemoveAt(index);
      Refresh();
    }

    private void Clear()
    {
      items.ForEach(item => Destroy(item.gameObject));
      items.Clear();
    }
  }
}