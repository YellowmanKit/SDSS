using System.Collections;
using UnityEngine;

public abstract class Active : Skill{

  public Transform[] shotSpawns;
  public ParticleSystem[] onUseEffects;
  public float cd, delay;
  protected float nextUse, readyTime;

  void OnEnable(){
    readyTime = time + delay;
  }

  bool canUse { get { return time > readyTime && time > nextUse; } }
  protected abstract bool shouldUse{ get; }
  protected abstract void Use();
  public float freezeOnUse;
  void CheckUse(){
    if(canUse && shouldUse){
      nextUse = time + cd;
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
