using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Active : Skill{

  public Transform[] shotSpawns;
  public ParticleSystem[] onUseEffects;
  public Flash[] flashes;

  public float cd, randomCd, delay, cost;
  protected float nextUse, readyTime;
  protected List<float> shootList = new List<float>();

  void OnEnable(){
    shootList.Clear();
    nextUse = 0f;
    readyTime = delay > 0f? time + delay: 0f;
  }

  bool canUse { get { return time > readyTime && time > nextUse && energy.energy >= cost; } }
  protected abstract bool shouldUse{ get; }
  protected abstract void Use();
  public float freezeOnUse;
  void CheckUse(){
    if(canUse && shouldUse){
      nextUse = time + cd + Random.Range(-randomCd, randomCd);
      energy.energy -= cost;
      Use();
      if(freezeOnUse > 0f){
        GetComponentInParent<Alien>().Freeze(freezeOnUse);
      }
    }
  }

  protected abstract void CheckShoot();
  void Update(){
    CheckUse();
    CheckShoot();
  }

}
