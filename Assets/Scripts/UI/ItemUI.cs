using System;
using Item;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
  public class ItemUI : MonoBehaviour, IPointerClickHandler
  {
    [SerializeField]
    private Image icon;

    [SerializeField]
    private TextMeshProUGUI text;

    public Sprite sprite
    {
      get => icon.sprite;
      set => icon.sprite = value;
    }

    private string _itemName;
    private uint _count;

    public string itemName
    {
      get => _itemName;
      set
      {
        _itemName = value;
        text.text = $"{_itemName}{(count == 1 ? "" : $" x {count}")}";
      }
    }

    public uint count
    {
      get => _count;
      set
      {
        _count = value;
        itemName = itemName;
      }
    }

    public int index;

    public Action<PointerEventData, int> interAction;

    public void OnPointerClick(PointerEventData eventData)
    {
      if (eventData.button == PointerEventData.InputButton.Right)
        interAction?.Invoke(eventData, index);
    }
  }
}