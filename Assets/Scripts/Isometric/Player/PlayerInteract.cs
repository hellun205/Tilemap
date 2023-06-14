using Isometric.Deco;
using JetBrains.Annotations;
using UnityEngine;

namespace Isometric.Player
{
  public class PlayerInteract : MonoBehaviour
  {
    [CanBeNull]
    public InteractableObject interactableObject;

    public KeyCode key = KeyCode.Space;

    public bool isInteracting;

    [SerializeField]
    private PlayerInventory inventory;

    private void OnTriggerEnter2D(Collider2D col)
    {
      if (col.TryGetComponent<InteractableObject>(out var interactableObj))
      {
        interactableObject = interactableObj;
      }
      
      Interact();
    }

    private void OnTriggerExit2D(Collider2D col)
    {
      if (interactableObject is not null && interactableObject.isInteractable)
      {
        interactableObject.Exit();
        isInteracting = false;
      }
      
      if (col.TryGetComponent<InteractableObject>(out var interactableObj) && interactableObject == interactableObj)
      {
        interactableObject = null;
      }
    }

    private void Update()
    {
      // if (Input.GetKeyDown(key))
      // {
      //   Interact();
      // }
    }

    private void Interact()
    {
      if (!isInteracting && interactableObject is not null)
      {
        Debug.Log(interactableObject.name);
        interactableObject.Interact();
        isInteracting = true;
      }
    }
  }
}