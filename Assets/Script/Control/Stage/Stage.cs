using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : Control{

  protected override void Init(){
    center.panel.restartButton.Activate(false);
  }

  public int stage;
  public bool started { get { return stage > 0; } }
  public void NextStage(){
    center.panel.nextButton.Activate(false);
    center.player.destination = center.player.transform.position;
    stage++;
    center.panel.stageCount.text = "" + stage;
    Loop(stage, ()=>{ SpawnAlien(Spawnable.AlienWarthog); });
  }

  public void StageEnded(){
    center.panel.nextButton.Activate(true);
  }

  Vector3 alienSpawnPosition { get { return new Vector3(Random.Range(-boundary.x, boundary.x), Random.Range(boundary.y ,boundary.y + 10f), 0f); } }
  void SpawnAlien(Spawnable alienName){
    center.AlienSpawned(center.pool.Spawn(alienName, alienSpawnPosition));
  }

  public void GameOver(){
    center.panel.restartButton.Activate(true);
  }

  public void Restart(){
    SceneManager.LoadScene(0);
  }


}
