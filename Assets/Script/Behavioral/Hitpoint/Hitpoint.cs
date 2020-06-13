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
    if(shielded){ return; }
    hp -= damage;
    if(shield){ shield.Hitted(hp > 0, position); }
    if(hp <= 0 && canDie){ GetComponent<Death>().Die(); }
  }

  public float regen;
  void Regenerate(){
    if(hp < maxHp){
      hp = Mathf.Clamp(hp + regen * deltaTime, -maxHp, maxHp);
      if(shield != null && hp > maxHp * shield.threshold){
        shield.Activate(true);
      }
    }
  }

  void Update(){
    Regenerate();
  }

}
