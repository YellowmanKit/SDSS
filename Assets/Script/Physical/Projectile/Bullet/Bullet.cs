using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile{

  protected override Vector3 HitPosition(Hitpoint hitpoint){ return transform.position; }

  public void Fire(float force){
    dieTime = float.MaxValue;
    Set(true);
    quota = penetration;
    rb.AddForce(transform.forward * force, ForceMode.Impulse);
  }

  void Update(){
    CheckDie();
  }

  protected override void OnHit(Hitpoint hitpoint){
    hitpoint.TakeDamage(damage * weaken, transform.position);
    if(quota > 0f && quota >= hitpoint.penetrationCost){
      quota -= hitpoint.penetrationCost;
      rb.velocity = rb.velocity * Mathf.Clamp(weaken, 0.75f, 1f);
    }else{ AreaDamage(); }
  }

  public Area area;
  protected override void AreaDamage(){
    if(area){ area.DealDamage(damage); }
    Die();
  }

  public float trailDuration;
  protected override void Die(){
    Set(false);
    rb.velocity = Vector3.zero;
    dieTime = time + trailDuration;
  }

  void Set(bool active){
    dead = !active;
    sprite.enabled = active;
    capsule.enabled = active;
  }

  public void HittedByPulse(Vector3 sourcePosition){
    SpawnOnHitEffect(transform.position, false);
    Die();
  }

}
