using System.Collections;
using UnityEngine;

public class Shield : Behavioural{

  float originalStartRotationX;
  protected override void Init(){
    ParticleSystem.MainModule main = shieldEffect.main;
    originalStartRotationX = main.startRotationX.constantMax;
  }

  void OnEnable(){
    Reactivate();
  }

  public ParticleSystem shieldEffect;
  public void Hitted(bool enable, Vector3 position){
    ParticleSystem.MainModule main = shieldEffect.main;
    main.startRotationX = originalStartRotationX + Mathf.Atan((transform.position.x - position.x)/(transform.position.y - position.y));
    shieldEffect.Play();
    parentCapsule.enabled = enable;
  }

  public void Reactivate(){
    parentCapsule.enabled = true;
  }

}
