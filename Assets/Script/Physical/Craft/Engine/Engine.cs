using System.Collections;
using UnityEngine;

public class Engine : Craft{

  public Vector2 velocity { get { return rb.velocity; } }

  public float thrust, output;
  public Vector2 direction;
  void FixedUpdate(){
    Push(direction * thrust * Mathf.Clamp(output, 0f, 1f));
    Tilt();
  }



}
