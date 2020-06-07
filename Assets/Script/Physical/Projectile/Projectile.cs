using System.Collections;
using UnityEngine;

public abstract class Projectile : Physical{

  public int damage;

  protected void Die(){
    Freeze();
    go.SetActive(false);
  }

  public ObjectName onHitEffect;
  protected abstract void OnHit(Hitpoint hitpoint);
  void OnTriggerEnter(Collider other){
    center.pool.Spawn(onHitEffect, transform.position);
    OnHit(other.GetComponent<Hitpoint>());
    Die();
  }

}
