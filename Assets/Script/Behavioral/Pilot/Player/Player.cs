using System.Collections;
using UnityEngine;

public class Player : Pilot{

  void OnEnable(){
    transform.localRotation = Quaternion.Euler(270f, 0f, 0f);
    SetCounter();
  }

  Counter hitpointCounter, shieldCounter, energyCounter;
  void SetCounter(){
    Transform counter = GameObject.Find("Counter").transform;
    hitpointCounter = counter.GetChild(0).GetComponent<Counter>();
    shieldCounter = counter.GetChild(1).GetComponent<Counter>();
    energyCounter = counter.GetChild(2).GetComponent<Counter>();
    shieldCounter.baseValue = shield.hitpoint.maxHp;
    shieldCounter.newValue = shield.hitpoint.maxHp;

    energyCounter.baseValue = energy.maxEnergy;
    energyCounter.newValue = energy.maxEnergy;
  }

  public ParticleSystem boost;
  public void Tapped(Vector3 position){
    destination = position;
    boost.Play();
  }

  void Update(){
    UpdateCounter();
  }

  void UpdateCounter(){
    hitpointCounter.targetValue = hitpoint.hp;
    hitpointCounter.targetValueMax = hitpoint.maxHp;

    shieldCounter.targetValue = shield? (shield.isActive? shield.hitpoint.hp: 0f): 0f;
    shieldCounter.targetValueMax = shield? shield.hitpoint.maxHp: float.MaxValue;

    energyCounter.targetValue = shield? energy.energy: 0f;
    energyCounter.targetValueMax = energy.maxEnergy;
  }

  public void UpdateCounterHeight(){
    shieldCounter.newValue = shield.hitpoint.maxHp;
    energyCounter.newValue = energy.maxEnergy;
  }

}
