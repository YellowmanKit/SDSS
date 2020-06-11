using System.Collections;
using UnityEngine;

public class Bullet : Projectile{

  public void Fire(float force){
    rb.AddForce(transform.forward * force);
  }

  void Update(){
    if(IsOutOfBoundary(transform.position)){
      Die();
    }
  }

  protected override void OnHit(Hitpoint hitpoint){
    hitpoint.TakeDamage(damage, transform.position);
  }

}
