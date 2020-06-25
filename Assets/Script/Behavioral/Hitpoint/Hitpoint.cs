using System.Collections;
using UnityEngine;

public class Hitpoint : Behavioural{

  public float maxHp,hp;
  void OnEnable(){
    hp = maxHp;
  }

  public bool canDie;
  public Shield shield;
  public Hitpoint under;
  public bool shielded { get { return under && under.shield.isActive; } }
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

}
