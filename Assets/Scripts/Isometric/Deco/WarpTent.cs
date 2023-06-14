using Isometric.Player;
using UnityEngine;

namespace Isometric.Deco
{
  public class WarpTent : InteractableObject
  {
    public WarpTent destination;

    [SerializeField]
    private Transform warpTrans;

    public bool canWarp = true;
    
    public override void Interact()
    {
      base.Interact();
      if (!canWarp) return;
      PlayerManager.Movement.transform.position = destination.warpTrans.position;
      destination.canWarp = false;
    }

    public override void Exit()
    {
      base.Exit();
      canWarp = true;
    }
  }
}