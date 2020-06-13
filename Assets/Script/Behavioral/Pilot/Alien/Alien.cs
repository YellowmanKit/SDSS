using System.Collections;
using UnityEngine;

public class Alien : Pilot{

  public float prepareTime;
  public GameObject skill;
  float activeTime;
  void OnEnable(){
    skill.SetActive(false);
    activeTime = time + prepareTime;
    transform.localRotation = Quaternion.Euler(90f, 180f, 0f);
  }

  public float engageDistance;
  void Update(){
    if(time > unfreezeTime){
      destination.x = pp.x;
      destination.y = pp.y + engageDistance;
    }
    if(time > activeTime){
      skill.SetActive(true);
    }
  }

  float unfreezeTime;
  public void Freeze(float freezeTime){
    destination = transform.position;
    unfreezeTime = time + freezeTime;
  }

}
