using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile{

  protected override Vector3 HitPosition(Hitpoint hitpoint){ return transform.position; }

  public void Fire(float force){
    quota = penetration;
    rb.AddForce(transform.forward * force, ForceMode.Impulse);
  }

  public float outScale;
  void Update(){ if(OutY(transform.position.y, boundary.y * outScale)){ Die(); } }

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

  protected override void Die(){
    rb.velocity = Vector3.zero;
    go.SetActive(false);
  }

  public void HittedByPulse(Vector3 sourcePosition){
    SpawnOnHitEffect(transform.position, false);
    Die();
  }

}
