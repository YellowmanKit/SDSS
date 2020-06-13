using System.Collections;
using UnityEngine;

public class Shield : Behavioural{

  public float threshold;

  float originalStartRotationX;
  protected override void Init(){
    ParticleSystem.MainModule main = shieldEffect.main;
    originalStartRotationX = main.startRotationX.constantMax;
  }

  void OnEnable(){
    Activate(true);
  }

  public ParticleSystem shieldEffect;
  public void Hitted(bool enable, Vector3 position){
    ParticleSystem.MainModule main = shieldEffect.main;
    main.startRotationX = originalStartRotationX + Mathf.Atan((transform.position.x - position.x)/(transform.position.y - position.y));
    shieldEffect.Play();
    Activate(enable);
  }

  public bool isActive;
  public void Activate(bool activate){
    parentCapsule.enabled = activate;
    isActive = activate;
  }

}
