using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center : Control{

  public Player player;
  public List<GameObject> aliens;
  public List<GameObject> earths;
  public Pool pool;
  public Stage stage;
  public Panel panel;
  public int orbCount;

  bool IsInFront(float x1, float x2){ return Mathf.Abs(x1 - x2) < 5f; }
  public bool HasEnemyInFront(float positionX, string side){
    if(side == "Earth"){
      foreach(GameObject alien in aliens){
        if(IsInFront(positionX, alien.transform.position.x)){ return true; }
      }
      return false;
    }else{
      foreach(GameObject earth in earths){
        if(IsInFront(positionX, earth.transform.position.x)){ return true; }
      }
      return false;
    }
  }

  public void AlienSpawned(GameObject alien){
    aliens.Add(alien);
  }

  public void AlienDied(GameObject alien){
    aliens.Remove(alien);
    if(aliens.Count == 0){
      center.stage.StageEnded();
    }
  }

  public void EarthSpawned(GameObject earth){
    earths.Add(earth);
  }

  public void EarthDied(GameObject earth){
    earths.Remove(earth);
    if(earths.Count == 0){
      center.stage.GameOver();
    }
  }

}
