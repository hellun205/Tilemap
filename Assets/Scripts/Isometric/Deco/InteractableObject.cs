using UnityEngine;

namespace Isometric.Deco
{
  public abstract class InteractableObject : MonoBehaviour
  {
    public bool isInteractable;
    
    public virtual void Interact() => isInteractable = true;

    public virtual void Exit() => isInteractable = false;
  }
}