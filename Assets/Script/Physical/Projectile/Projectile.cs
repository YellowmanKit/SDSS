using System.Collections;
using UnityEngine;

public abstract class Projectile : Physical{

  public float damage;

  protected abstract void OnHit(Hitpoint hitpoint);
  public bool penetrate;
  void OnTriggerEnter(Collider other){
    Hitpoint hitpoint = other.GetComponent<Hitpoint>();
    if(!penetrate && hitpoint.shielded){ return; }
    ApplyMomentum(other.gameObject.GetComponent<Rigidbody>());
    SpawnOnHitEffect(hitpoint);
    OnHit(hitpoint);
  }

  protected abstract Vector3 HitPosition(Hitpoint hitpoint);
  public Spawnable onHitEffect;
  protected void SpawnOnHitEffect(Hitpoint hitpoint){
    GameObject effect = center.pool.Spawn(onHitEffect, HitPosition(hitpoint), transform.rotation);
    effect.transform.Rotate(0f, (hitpoint.shield != null && !penetrate)? 180f:0f, 0f);
  }

  protected float momentum { get { return rb.mass * rb.velocity.magnitude; } }
  void ApplyMomentum(Rigidbody otherRb){
    otherRb.AddForce(transform.forward * momentum, ForceMode.Impulse);
  }


}
