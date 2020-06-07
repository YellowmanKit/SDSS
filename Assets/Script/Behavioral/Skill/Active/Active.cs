using System.Collections;
using UnityEngine;

public abstract class Active : Skill{

  public Transform[] shotSpawns;
  public ParticleSystem[] onUseEffects;
  public float cd;
  protected float nextUse;
  bool canUse { get { return time > nextUse; } }
  protected abstract void Use();
  protected abstract bool shouldUse{ get; }
  void CheckUse(){
    if(canUse && shouldUse){
      nextUse = time + cd;
      Use();
    }
  }
  void Update(){
    CheckUse();
  }

}
