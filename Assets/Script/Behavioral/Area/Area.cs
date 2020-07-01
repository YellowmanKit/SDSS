using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : Behavioural{

  public float radius, effectiveness, force, decayRate;
  float Decay(float distance){ return distance / (radius * decayRate); }
  public void DealDamage(float damage){
    List<GameObject> opponents = new List<GameObject>(center.GetOpponents(transform.parent.gameObject.tag.ToString()));
    foreach(GameObject opponent in opponents){
      Hitpoint hitpoint = opponent.GetComponent<Hitpoint>().effectiveHitpoint;
      float distance = (hitpoint.transform.position - transform.position).magnitude;
      if(distance <= radius){
        hitpoint.TakeDamage(damage * effectiveness * Decay(distance), transform.position);
        if(!hitpoint.shield){ ApplyForce(opponent.GetComponent<Rigidbody>(), Decay(distance)); }
      }
    }
    foreach(Rigidbody floatRb in center.floats){
      float distance = (floatRb.transform.position - transform.position).magnitude;
      if(distance <= radius){ ApplyForce(floatRb, Decay(distance)); }
    }
  }

  void ApplyForce(Rigidbody targetRb, float decay){
    Vector3 direction = (targetRb.transform.position - transform.position).normalized;
    Vector3 applyForce = direction * force * decay;
    targetRb.AddForce(applyForce, ForceMode.Impulse);
  }

}
