using System.Collections;
using UnityEngine;

public class Hitpoint : Behavioural{

  public float maxHp, hp, penetrationCost;
  void OnEnable(){
    hp = maxHp;
  }

  public bool canDie;
  public Shield shield;
  public Hitpoint under;
  public Hitpoint above;
  public bool shielded { get { return under && under.shield.isActive; } }
  public Hitpoint effectiveHitpoint { get { return shielded? under: this; } }
  public void TakeDamage(float damage, Vector3 position){
    if(hp < 0f){ return; }
    if(shielded){ return; }
    hp -= damage;
    if(shield){ shield.Hitted(hp > 0f, position); }
    if(hp <= 0f && canDie){ GetComponent<Death>().Die(); }
  }

  public void GainHp(float value){
    hp = Mathf.Clamp(hp + value, 0f, maxHp);
  }

  public float regen;
  void Regenerate(){
    GainHp(regen * maxHp * deltaTime);
    if(shield && hp > maxHp * shield.threshold){
      shield.Activate(true);
    }
  }

  void Update(){
    Regenerate();
  }

  public void HittedByPulse(Vector3 sourcePosition){
    if(shield){ shield.Hitted(true, sourcePosition); }
  }

}
