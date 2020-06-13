using System.Collections;
using UnityEngine;

public class Engine : Craft{

  public Vector2 velocity { get { return rb.velocity; } }

  public float thrust, output;
  public Vector2 direction;
  void FixedUpdate(){
    rb.AddForce(direction * thrust * Mathf.Clamp(output, 0f, 1f));
    Tilt();
  }

  public void Freeze(bool active){
    rb.isKinematic = active;
    rb.velocity = Vector3.zero;
  }

}
