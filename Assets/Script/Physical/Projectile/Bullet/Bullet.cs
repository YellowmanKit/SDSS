using System.Collections;
using UnityEngine;

public class Bullet : Projectile{

  protected override Vector3 HitPosition(Hitpoint hitpoint){ return transform.position; }

  public void Fire(float force){
    rb.AddForce(transform.forward * force, ForceMode.Impulse);
  }

  void Update(){
    if(IsOutOfBoundary(transform.position)){ Die(); }
  }

  protected override void OnHit(Hitpoint hitpoint){
    hitpoint.TakeDamage(damage, transform.position);
    Die();
  }

  void Die(){
    rb.velocity = Vector3.zero;
    go.SetActive(false);
  }

}
