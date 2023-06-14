using UnityEngine;

namespace Isometric.Player
{
  public class PlayerManager
  {
    private static PlayerAnimation _animation;
    private static PlayerInteract _interact;
    private static PlayerInventory _inventory;
    private static PlayerMovement _movement;
    
    public static PlayerAnimation Animation => _animation ??= GameObject.FindObjectOfType<PlayerAnimation>();
    public static PlayerInteract Interact  => _interact ??= GameObject.FindObjectOfType<PlayerInteract>();
    public static PlayerInventory Inventory  => _inventory ??= GameObject.FindObjectOfType<PlayerInventory>();
    public static PlayerMovement Movement  => _movement ??= GameObject.FindObjectOfType<PlayerMovement>();
    
    
  }
}