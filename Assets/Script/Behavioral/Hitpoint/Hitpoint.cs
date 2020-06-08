using System.Collections;
using UnityEngine;

public class Hitpoint : Behavioural{

  public int maxHp,hp;
  void OnEnable(){
    hp = maxHp;
  }

  public bool canDie;
  public Shield shield;
  public void TakeDamage(int damage){
    hp -= damage;
    if(shield){ shield.Hitted(hp > 0); }
    if(hp <= 0){
      if(canDie){ go.GetComponent<Death>().Die(); }
    }
  }

  //Need to lock craft hp when shield is on

}
