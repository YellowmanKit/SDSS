using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : Control{

  public int stage;
  public bool started { get { return stage > 0; } }
  public bool battling;
  public void NextStage(){
    battling = true;
    ClosePenal();
    center.player.destination = center.player.transform.position;
    stage++;
    center.panel.stageCount.text = "" + stage;
    Loop(stage * 3, ()=>{ SpawnAlien(Spawnable.AlienWarthog); });
  }

  void ClosePenal(){
    center.panel.next.Activate(false);
    center.panel.select.OnConfirmChange();
    center.panel.ability.SetChangeButtons(false);
  }

  public void StageCleared(){
    battling = false;
    center.panel.next.Activate(true);
    center.panel.ability.SetChangeButtons(true);
    center.player.soul.shield.hitpoint.GainHp(float.MaxValue);
    center.player.energy.GainEnergy(float.MaxValue);
    center.panel.ability.UnlockSlot();
  }

  Vector3 alienSpawnPosition { get { return new Vector3(Random.Range(-boundary.x, boundary.x), Random.Range(boundary.y ,boundary.y + 10f), 0f); } }
  void SpawnAlien(Spawnable alienName){
    center.AlienSpawned(center.pool.Spawn(alienName, alienSpawnPosition));
  }

  public bool gameOvered;
  public void GameOver(){
    gameOvered = true;
    center.panel.restart.Activate(true);
  }

  public void Restart(){
    SceneManager.LoadScene(0);
  }

}
