using System;
using UnityEngine;
using Utils;

namespace Isometric
{
  public sealed class CameraController : MonoBehaviour
  {
    public float smoothSpeed = 2f;
    private Transform target;
    public Vector2 min, max;

    private void Start()
    {
      target = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
      var x = Mathf.Clamp(target.position.x, min.x, max.x);
      var y = Mathf.Clamp(target.position.y, min.y, max.y);
      
      var position = transform.position;
      transform.position = Vector3.Lerp(position, new(x,y,position.z), smoothSpeed * Time.deltaTime);
    }
  }
}