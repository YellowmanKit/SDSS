using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Active : Skill{

  public Transform[] shotSpawns;
  public ParticleSystem[] onUseEffects;
  public Flash[] flashes;
  public Flash[] glows;

  public bool alwaysUse, autoUse;
  public float cd, randomCd, delay, cost, useDelay, nextUse;
  protected float readyTime;
  protected List<float> shootList = new List<float>();

  void OnEnable(){
    shootList.Clear();
    nextUse = 0f;
    readyTime = delay > 0f? time + delay: 0f;
  }

  bool canUse { get { return time > readyTime && time > nextUse && energy.energy >= cost; } }
  protected abstract bool shouldUse{ get; }
  protected abstract void Use();
  public float stopOnUse;
  void CheckUse(){
    if(canUse && shouldUse){
      ConfirmUse();
    }
  }

  public void ActivelyUse(){ if(canUse){ ConfirmUse(); } }

  void ConfirmUse(){
    nextUse = time + cd + Random.Range(-randomCd, randomCd);
    energy.energy -= cost;
    if(stopOnUse > 0f){ GetComponentInParent<Alien>().Stop(stopOnUse); }
    Use();
  }

  protected abstract void CheckShoot();
  void Update(){
    CheckUse();
    CheckShoot();
  }

}
