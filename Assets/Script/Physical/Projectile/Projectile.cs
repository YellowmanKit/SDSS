using System.Collections;
using UnityEngine;

public abstract class Projectile : Physical{

  public int damage;

  protected bool IsOutOfBoundary(Vector2 position){
    return Mathf.Abs(position.x) > boundary.x || Mathf.Abs(position.y) > boundary.y;
  }

  protected void Die(){
    Freeze();
    go.SetActive(false);
  }

  public Spawnable onHitEffect;
  protected abstract void OnHit(Hitpoint hitpoint);
  void OnTriggerEnter(Collider other){
    Hitpoint hitpoint = other.GetComponent<Hitpoint>();
    if(hitpoint.shielded){ return; }
    center.pool.Spawn(onHitEffect, transform.position, Quaternion.Euler(new Vector3(0f,0f, hitpoint.shield? 180f:0f)));
    OnHit(hitpoint);
    Die();
  }


}
