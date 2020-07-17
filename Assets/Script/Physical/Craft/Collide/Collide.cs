using System.Collections;
using UnityEngine;

public class Collide : Craft{

  public Spawnable onHitEffect;
  float threshold = 5f;
  float frequency = 5f;
  float nextEffect;
  void OnCollisionStay(Collision collision){
    if(time < nextEffect){ return; }
    nextEffect = time + 1f / frequency;
    if(rb.velocity.magnitude < threshold){ return; }
    Loop(collision.contacts.Length, i => {
      center.pool.Spawn(onHitEffect, collision.contacts[i].point, transform.rotation);
    });
    if(alien){ alien.HandleCollision(collision); }
  }

}
