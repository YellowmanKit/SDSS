using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : Behavioural{

  public float targetScale;
  void OnEnable(){
    SetOrb(true);
  }

  public float dropForce;
  void FixedUpdate(){
    rb.AddForce(new Vector3(0f, -dropForce * deltaTime, 0f));
  }

  public float shieldValue, energyValue, maxShieldValue, maxEnergyValue;
  void OnTriggerEnter(Collider other){
    Player player = other.GetComponentInParent<Player>();
    if(player != null){
      GrantEnergy(other.GetComponentInParent<Energy>());
      GrantShield(other);
      player.UpdateCounterHeight();
      SetOrb(false);
    }
  }

  void SetOrb(bool active){
    if(active){ effectTransform.localScale = Vector3.one; }
    targetScale = active? 1:0;
    capsule.enabled = active;
    rb.velocity = active? rb.velocity: Vector3.zero;
  }

  void GrantEnergy(Energy energy){
    energy.GainEnergy(energy.maxEnergy * energyValue);
    energy.maxEnergy = energy.maxEnergy + maxEnergyValue;
  }

  void GrantShield(Collider other){
    Hitpoint hitpoint = other.transform.GetComponentInChildren<Hitpoint>();
    if(hitpoint.shield == null){
      hitpoint = other.transform.GetChild(0).GetComponentInChildren<Hitpoint>();
    }
    hitpoint.GainHp(hitpoint.maxHp * shieldValue);
    hitpoint.maxHp = hitpoint.maxHp + maxShieldValue;
  }

  public float shrinkSpeed;
  Transform effectTransform { get { return transform.GetChild(0); } }
  void Update(){
    float currentScale = effectTransform.localScale.x;
    float delta = targetScale - currentScale;
    float newScale = currentScale + delta * deltaTime * shrinkSpeed;
    effectTransform.localScale = new Vector3(newScale, newScale, newScale);
    if(transform.position.y < -boundary.y){ SetOrb(false); }
    if(currentScale < 0.0001f){
      rb.velocity = Vector3.zero;
      go.SetActive(false);
    }
  }

}
