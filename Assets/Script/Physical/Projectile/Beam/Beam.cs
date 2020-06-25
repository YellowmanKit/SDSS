using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : Projectile{

  public float duration, frequency;

  public void Fire(Transform source){
    transform.parent = source;
    GetComponent<Expire>().duration = duration;
  }

  List<Hitpoint> hitting = new List<Hitpoint>();
  protected override void OnHit(Hitpoint hitpoint){
    hitting.Add(hitpoint);
  }

  void Update(){
    CheckIntersect();
    DealDamage();
  }

  void CheckIntersect(){
    var remove = new List<Hitpoint>();
    foreach(Hitpoint hitpoint in hitting){
      if(hitpoint.capsule.bounds.Intersects(box.bounds)){ continue; }
      remove.Add(hitpoint);
    }
    foreach(Hitpoint hitpoint in remove){ hitting.Remove(hitpoint); }
  }

  float nextCheck;
  protected override Vector3 HitPosition(Hitpoint hitpoint){
    Vector3 target = hitpoint.transform.position;
    return new Vector3(
    transform.position.x,
    target.y + hitpoint.capsule.height * (transform.position.y >target.y? 1f: -1f) / 2f,
    0f);
  }
  void DealDamage(){
    if(time > nextCheck){
      float delta = 1f / frequency;
      nextCheck = time + delta;
      foreach(Hitpoint hitpoint in hitting){
        hitpoint.TakeDamage(damage * delta / duration, HitPosition(hitpoint));
        SpawnOnHitEffect(hitpoint);
      }
    }
  }

}
