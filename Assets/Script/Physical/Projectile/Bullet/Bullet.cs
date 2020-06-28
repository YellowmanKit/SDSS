using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile{

  protected override Vector3 HitPosition(Hitpoint hitpoint){ return transform.position; }

  public int penetration;
  int penetrationQuota;
  public void Fire(float force){
    penetrationQuota = penetration;
    rb.AddForce(transform.forward * force, ForceMode.Impulse);
  }

  void Update(){ if(OutY(transform.position.y, boundary.y * 1.25f)){ Die(); } }

  protected override void OnHit(Hitpoint hitpoint){
    hitpoint.TakeDamage(damage, transform.position);
    AreaDamage();
    if(penetrationQuota > 0 && penetrationQuota >= hitpoint.penetrationCost){
      penetrationQuota -= hitpoint.penetrationCost;
    }else{ Die(); }
  }

  public float damageRadius, effectiveness;
  protected override void AreaDamage(){
    if(damageRadius == 0f){ return; }
    List<GameObject> opponents = new List<GameObject>(center.GetOpponents(go.tag.ToString()));
    foreach(GameObject opponent in opponents){
      Hitpoint hitpoint = opponent.GetComponent<Hitpoint>().effectiveHitpoint;
      float distance = (hitpoint.transform.position - transform.position).magnitude;
      if(distance <= damageRadius){
        hitpoint.TakeDamage(damage * effectiveness * distance / damageRadius, transform.position);
      }
    }
  }

  protected override void Die(){
    rb.velocity = Vector3.zero;
    go.SetActive(false);
  }

}
