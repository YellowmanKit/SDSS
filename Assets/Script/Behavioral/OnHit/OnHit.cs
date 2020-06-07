using System.Collections;
using UnityEngine;

public class OnHit : Behavioural{

  float spawnTime;
  void OnEnable(){
    spawnTime = time;
  }

  public float duration;
  void Update(){
    if(time > spawnTime + duration){
      go.SetActive(false);
    }
  }

}
