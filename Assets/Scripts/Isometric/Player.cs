using System;
using UnityEngine;

namespace Isometric
{
  public class Player : MonoBehaviour
  {
    [SerializeField]
    private new Rigidbody2D rigidbody;

    private Vector2 moveVector = new Vector2();
    public float moveSpeed = 4f;
    private void Reset()
    {
      rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
      moveVector.x = Input.GetAxisRaw("Horizontal");
      moveVector.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
      rigidbody.velocity =moveVector.normalized * moveSpeed;
    }
  }
}