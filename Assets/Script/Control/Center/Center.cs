using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center : Control{

  public Player player;
  public List<Alien> aliens;
  public Pool pool;
  public Stage stage;

  protected override void Init(){
    player = GameObject.FindWithTag("Player").GetComponent<Player>();
  }

  bool IsInFront(float x1, float x2){ return Mathf.Abs(x1 - x2) < 5f; }
  public bool HasEnemyInFront(float x, string side){
    if(side == "Earth"){
      foreach(Alien alien in aliens){
        if(IsInFront(x, alien.transform.position.x)){ return true; }
      }
      return false;
    }else{
      return true;
    }
  }

  public void AlienSpawned(Alien alien){
    aliens.Add(alien);
  }

  public void AlienDied(Alien alien){
    aliens.Remove(alien);
    if(aliens.Count == 0){
      center.stage.NextStage();
    }
  }

}
