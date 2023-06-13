using UnityEngine;

namespace Isometric.Player
{
  public class PlayerMovement : MonoBehaviour
  {
    [SerializeField]
    private new Rigidbody2D rigidbody;

    [SerializeField]
    private PlayerAnimation playerAnimation;
    
    private Vector2 moveVector = new Vector2();
    
    public float moveSpeed = 4f;

    private void Update()
    {
      moveVector.x = Input.GetAxisRaw("Horizontal");
      moveVector.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
      var curPos = rigidbody.position;
      var inputVec = moveVector.normalized * (moveSpeed * Time.fixedDeltaTime);
      rigidbody.MovePosition(curPos + inputVec);
      
      playerAnimation.SetDirection(moveVector);
    }
  }
}