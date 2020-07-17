using System.Collections;
using UnityEngine;

public class Shield : Behavioural{

  public float threshold;
  void OnEnable(){
    Activate(true);
  }

  public ParticleSystem shieldEffect;
  public void Hitted(bool enable, Vector3 position){
    ParticleSystem.MainModule main = shieldEffect.main;
    float deltaX = position.x - transform.position.x;
    float deltaY = position.y - transform.position.y;
    float rotationX = 0f;
    if(deltaX >= 0f && deltaY >= 0f){
      rotationX = 270f - Mathf.Atan(deltaY / deltaX) * Mathf.Rad2Deg;
    }else if(deltaX <= 0f && deltaY >= 0f){
      rotationX = 90f + Mathf.Atan(deltaY / Mathf.Abs(deltaX)) * Mathf.Rad2Deg;
    }else if(deltaX >= 0f && deltaY <= 0f){
      rotationX = 270f + Mathf.Atan(Mathf.Abs(deltaY) / deltaX) * Mathf.Rad2Deg;
    }else{
      rotationX = Mathf.Atan(Mathf.Abs(deltaY) / Mathf.Abs(deltaX)) * Mathf.Rad2Deg;
    }
    main.startRotationX = rotationX * Mathf.Deg2Rad;
    shieldEffect.Play();
    Activate(enable);
  }

  public bool isActive;
  public void Activate(bool activate){
    parentCapsule.enabled = activate;
    isActive = activate;
  }

  public float repulse;
  float frequency = 10f;
  float nextEffect;
  void OnTriggerStay(Collider other){
    if(time < nextEffect){ return; }
    nextEffect = time + 1f / frequency;
    Hitted(true, other.transform.position);
    Hitpoint hitpoint = other.GetComponent<Hitpoint>();
    if(hitpoint && hitpoint.above){
      Vector3 delta =  other.transform.position - transform.position;
      hitpoint.above.GetComponent<Rigidbody>().AddForce(
      delta.normalized * repulse / delta.magnitude, ForceMode.Impulse);
      SpawnOnHitEffect(transform.position + (delta.normalized * capsule.radius));
    }
  }

  public Spawnable onHitEffect;
  void SpawnOnHitEffect(Vector3 position){
    center.pool.Spawn(onHitEffect, position, transform.rotation);
  }

}
