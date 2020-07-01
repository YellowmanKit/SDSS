using System.Collections;
using UnityEngine;

public class Shield : Behavioural{

  public float threshold;
  public Hitpoint hitpoint { get { return GetComponent<Hitpoint>(); } }

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

}
