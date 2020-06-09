using System.Collections;
using UnityEngine;

public class Shield : Behavioural{

  protected CapsuleCollider parentCapsule { get { return go.GetComponentInParent<CapsuleCollider>(); } }

  void OnEnable(){
    Reactivate();
  }

  public ParticleSystem shieldEffect;
  public void Hitted(bool enable){
    shieldEffect.Play();
    parentCapsule.enabled = enable;
  }

  public void Reactivate(){
    parentCapsule.enabled = true;
  }

}
