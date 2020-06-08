using System.Collections;
using UnityEngine;

public class Stage : Control{

  public int stage;

  Vector3 alienSpawnPosition { get { return new Vector3(Random.Range(-boundary.x, boundary.x), Random.Range(boundary.y ,boundary.y + 10f), 0f); } }

  protected override void Init(){
    NextStage();
  }

  public void NextStage(){
    stage++;
    for(var i=0;i<stage;i++){
      SpawnAlien(ObjectName.AlienWarthog);
    }
  }

  void SpawnAlien(ObjectName alienName){
    GameObject alien = center.pool.Spawn(alienName, alienSpawnPosition);
    center.AlienSpawned(alien.GetComponent<Alien>());
  }

}
