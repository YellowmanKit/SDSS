using System.Collections;
using UnityEngine;

public abstract class Projectile : Physical{

  public float damage;

  protected void Die(){
    rb.velocity = Vector3.zero;
    go.SetActive(false);
  }

  public Spawnable onHitEffect;
  protected abstract void OnHit(Hitpoint hitpoint);
  void OnTriggerEnter(Collider other){
    Hitpoint hitpoint = other.GetComponent<Hitpoint>();
    if(hitpoint.shielded){ return; }
    ApplyMomentum(other.gameObject.GetComponent<Rigidbody>());
    GameObject effect = center.pool.Spawn(onHitEffect, transform.position, transform.rotation);
    effect.transform.Rotate(0f, hitpoint.shield? 180f:0f, 0f);
    OnHit(hitpoint);
    Die();
  }

  protected float momentum { get { return rb.mass * rb.velocity.magnitude; } }
  void ApplyMomentum(Rigidbody otherRb){
    otherRb.AddForce(transform.forward * momentum, ForceMode.Impulse);
  }


}
