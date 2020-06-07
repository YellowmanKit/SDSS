using System.Collections;
using UnityEngine;

public class Hitpoint : Behavioural{

  public int maxHp,hp;
  public bool canDie;
  void OnEnable(){
    hp = maxHp;
  }

  public void TakeDamage(int damage){
    hp -= damage;
    if(hp <= 0){
      if(canDie){ go.GetComponent<Death>().Die(); }
    }
  }

}
