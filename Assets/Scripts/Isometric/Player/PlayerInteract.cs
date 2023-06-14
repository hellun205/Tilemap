using System.Collections.Generic;
using System.Linq;
using Isometric.Deco;
using JetBrains.Annotations;
using UnityEngine;

namespace Isometric.Player
{
  public class PlayerInteract : MonoBehaviour
  {
    public List<InteractableObject> interactableObject = new List<InteractableObject>();

    public KeyCode key = KeyCode.Space;

    [SerializeField]
    private PlayerInventory inventory;

    private void OnTriggerEnter2D(Collider2D col)
    {
      Debug.Log(interactableObject.Count);
      if (col.TryGetComponent<InteractableObject>(out var interactableObj) &&
          !interactableObject.Contains(interactableObj))
      {
        interactableObject.Add(interactableObj);
      }
      
      interactableObject.Where(x => !x.needKeyDown).ToList().ForEach(Interact);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
      Debug.Log(interactableObject.Count);
      if (col.TryGetComponent<InteractableObject>(out var interactableObj))
      {
        interactableObject.Where(x => interactableObj == x).ToList().ForEach(x =>
        {
          if (x.isInteractable) x.Exit();
          interactableObject.Remove(x);
        });
      }
    }

    private void Update()
    {
      if (Input.GetKeyDown(key))
      {
        foreach (var obj in interactableObject)
        {
          if (obj.needKeyDown) Interact(obj);
        }
      }
    }

    private void Interact(InteractableObject obj)
    {
      if (!obj.isInteractable)
        obj.Interact();
    }
  }
}