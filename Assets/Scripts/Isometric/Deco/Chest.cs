using System.Collections.Generic;
using System.Linq;
using Item;
using UI;
using UnityEngine;

namespace Isometric.Deco
{
  public class Chest :  CollectableObject
  {
    public override void Interact()
    {
      base.Interact();
      
      Debug.Log("open chest");
      ChestUI.Instance.Open(this);
    }

    public override void Exit()
    {
      base.Exit();
      
      ChestUI.Instance.Close();
    }

  }
}