using System.Collections;
using UnityEngine;

public class Stage : Control{

  protected override void Init(){
    NextStage();
  }

  public int stage;
  public void NextStage(){
    stage++;
    Loop(stage, ()=>{ SpawnAlien(Spawnable.AlienWarthog); });
  }

  Vector3 alienSpawnPosition { get { return new Vector3(Random.Range(-boundary.x, boundary.x), Random.Range(boundary.y ,boundary.y + 10f), 0f); } }
  void SpawnAlien(Spawnable alienName){
    GameObject alien = center.pool.Spawn(alienName, alienSpawnPosition);
    center.AlienSpawned(alien.GetComponent<Alien>());
  }

}
