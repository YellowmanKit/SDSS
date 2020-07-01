using System.Collections;
using UnityEngine;

public abstract class Projectile : Physical{

  public float damage, penetration;
  protected float penetrationQuota;

  protected abstract void OnHit(Hitpoint hitpoint);
  public bool isBeam;
  void OnTriggerEnter(Collider other){
    Hitpoint hitpoint = other.GetComponent<Hitpoint>();
    if(!hitpoint){ return; }
    if(!isBeam && hitpoint.shielded){ return; }
    Hit(hitpoint);
  }

  void Hit(Hitpoint hitpoint){
    ApplyMomentum(hitpoint.GetComponent<Rigidbody>());
    SpawnOnHitEffect(HitPosition(hitpoint), (hitpoint.shield != null) && !isBeam);
    OnHit(hitpoint);
  }

  protected abstract void AreaDamage();
  protected abstract void Die();
  public void Explode(){
    SpawnOnHitEffect(transform.position, false);
    AreaDamage();
  }

  protected abstract Vector3 HitPosition(Hitpoint hitpoint);
  public Spawnable onHitEffect;
  protected void SpawnOnHitEffect(Vector3 position, bool reverse){
    GameObject effect = center.pool.Spawn(onHitEffect, position, transform.rotation);
    effect.transform.Rotate(0f, reverse? 180f:0f, 0f);
  }

  protected float momentum { get { return rb.mass * rb.velocity.magnitude; } }
  void ApplyMomentum(Rigidbody otherRb){
    otherRb.AddForce(transform.forward * momentum, ForceMode.Impulse);
  }


}
