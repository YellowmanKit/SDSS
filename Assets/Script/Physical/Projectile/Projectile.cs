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
    Hitpoint hitpoint = other.GetComponent<Hitpoint>();
    center.pool.Spawn(onHitEffect, transform.position, Quaternion.Euler(new Vector3(0f,0f, hitpoint.shield? 180f:0f)));
    OnHit(hitpoint);
    Die();
  }

}
