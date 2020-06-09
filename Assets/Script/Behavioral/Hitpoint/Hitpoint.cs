using System.Collections;
using UnityEngine;

public class Hitpoint : Behavioural{

  public int maxHp,hp;
  void OnEnable(){
    hp = maxHp;
  }

  public bool canDie;
  public Shield shield;
  public Hitpoint under;
  public bool shielded { get { return under && under.hp > 0; } }
  public void TakeDamage(int damage){
    if(shielded){ return; }
    hp -= damage;
    if(shield){ shield.Hitted(hp > 0); }
    if(hp <= 0 && canDie){ go.GetComponent<Death>().Die(); }
  }

}
