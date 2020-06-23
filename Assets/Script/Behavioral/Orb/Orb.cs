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

  public Spawnable onCollectEffect;
  public float shieldValue, energyValue, maxShieldValue, maxEnergyValue;
  void OnTriggerEnter(Collider other){
    Player player = other.GetComponentInParent<Player>();
    if(player){
      center.pool.Spawn(onCollectEffect, transform.position);
      GrantEnergy(other.GetComponentInParent<Energy>());
      GrantShield(other);
      player.UpdateCounterHeight();
      SetOrb(false);
    }
  }

  void SetOrb(bool active){
    go.SetActive(active);
    targetScale = active? 1:0;
    capsule.enabled = active;
    rb.velocity = active? rb.velocity: Vector3.zero;
  }

  void GrantEnergy(Energy energy){
    if(energyValue == 0f){ return; }
    energy.GainEnergy(energy.maxEnergy * energyValue);
    energy.maxEnergy = energy.maxEnergy + maxEnergyValue;
  }

  void GrantShield(Collider other){
    if(shieldValue == 0f){ return; }
    Hitpoint hitpoint = other.transform.GetComponentInChildren<Hitpoint>();
    if(!hitpoint.shield){
      hitpoint = hitpoint.under;
    }
    hitpoint.GainHp(hitpoint.maxHp * shieldValue);
    hitpoint.maxHp = hitpoint.maxHp + maxShieldValue;
    hitpoint.shield.Hitted(true, transform.position);
  }

  void Update(){ if(transform.position.y < -boundary.y){ SetOrb(false); } }

}
