using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile{

  protected override Vector3 HitPosition(Hitpoint hitpoint){ return transform.position; }

  public void Fire(float force){
    penetrationQuota = penetration;
    rb.AddForce(transform.forward * force, ForceMode.Impulse);
  }

  void Update(){ if(OutY(transform.position.y, boundary.y * 1.25f)){ Die(); } }

  protected override void OnHit(Hitpoint hitpoint){
    hitpoint.TakeDamage(damage, transform.position);
    if(penetrationQuota > 0f && penetrationQuota >= hitpoint.penetrationCost){
      penetrationQuota -= hitpoint.penetrationCost;
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
