using System.Collections;
using UnityEngine;

public class Collide : Craft{

  public Spawnable onHitEffect;
  public float threshold;
  void OnCollisionStay(Collision collision){
    if(rb.velocity.magnitude < threshold){ return; }
    Loop(collision.contacts.Length, i => {
      center.pool.Spawn(onHitEffect, collision.contacts[i].point, transform.rotation);
    });
    if(alien){ alien.HandleCollision(collision); }
  }

}
