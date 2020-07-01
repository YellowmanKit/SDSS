using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center : Control{

  public Player player;
  public List<GameObject> aliens;
  public List<GameObject> earths;
  public List<GameObject> GetOpponents(string side){ if(side == "Alien"){ return earths; } return aliens; }
  public List<Rigidbody> floats;

  public Pool pool;
  public Stage stage;
  public Panel panel;
  public float orbMeter, orbCount;

  public Transform earthTarget{ get { return earths.Count > 0? earths[Random.Range(0, earths.Count)].transform: null; } }
  public Transform alienTarget{ get { return aliens.Count > 0? aliens[Random.Range(0, aliens.Count)].transform: null; } }

  bool IsInLine(Vector2 pos1, Vector2 pos2, bool inFront){
    return (Mathf.Abs(pos1.x - pos2.x) < 5f) && (inFront? pos1.y > pos2.y:pos2.y > pos1.y);
  }
  public bool HasEnemyInLine(Vector2 position, string side, bool inFront){
    if(side == "Earth"){
      foreach(GameObject alien in aliens){
        if(IsInLine(alien.transform.position, position, inFront)){ return true; }
      }
      return false;
    }else{
      foreach(GameObject earth in earths){
        if(IsInLine(position, earth.transform.position, inFront)){ return true; }
      }
      return false;
    }
  }

  public void AlienSpawned(GameObject alien){
    aliens.Add(alien);
    floats.AddRange(alien.GetComponent<Alien>().body.floats);
  }

  public void AlienDied(GameObject alien){
    aliens.Remove(alien);
    if(aliens.Count == 0){
      center.stage.StageCleared();
    }
  }

  public void EarthSpawned(GameObject earth){
    earths.Add(earth);
    //floats.AddRange(earth.GetComponent<Earth>().body.floats);
  }

  public void EarthDied(GameObject earth){
    earths.Remove(earth);
    if(earths.Count == 0){
      center.stage.GameOver();
    }
  }

  public float timeScale;
  void Update(){
    Time.timeScale = timeScale;
  }

}
