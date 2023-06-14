using System;
using Isometric.Player;
using UnityEngine;

namespace Isometric.Deco
{
  public abstract class InteractableObject : MonoBehaviour
  {
    public bool needKeyDown = false;
    public bool isInteractable;
    
    public virtual void Interact() => isInteractable = true;

    public virtual void Exit() => isInteractable = false;

    protected virtual void OnDestroy()
    {
      if (PlayerManager.Interact.interactableObject.Contains(this))
      {
        PlayerManager.Interact.interactableObject.Remove(this);
      }
    }
  }
}