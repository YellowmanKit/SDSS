using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : Projectile{

  void OnEnable(){
    sphere.radius = 0f;
  }

  public float maxRadius, expandIn;
  void Update(){
    sphere.radius = Mathf.Clamp(sphere.radius + (maxRadius * deltaTime / expandIn), 0f, maxRadius);
    if(sphere.radius >= maxRadius){
      go.SetActive(false);
    }
  }

  void OnTriggerEnter(Collider other){
    other.BroadcastMessage("HittedByPulse", transform.position);
  }

  protected override Vector3 HitPosition(Hitpoint hitpoint){ return hitpoint.transform.position; }
  protected override void OnHit(Hitpoint hitpoint){}
  protected override void AreaDamage(){}
  protected override void Die(){}

}
