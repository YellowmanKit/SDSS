using System.Collections;
using UnityEngine;

public class Alien : Pilot{

  public float prepare, randomPrepare, minY, maxY;
  public GameObject skill;
  float activeTime;
  void OnEnable(){
    skill.SetActive(false);
    activeTime = time + prepare + Random.Range(-randomPrepare, randomPrepare);
    transform.localRotation = Quaternion.Euler(90f, 180f, 0f);
    destination = RandomPosition(true);
    engageY = Random.Range(minY, maxY);
  }

  Transform target;
  float engageY;
  void Update(){
    if(!target || !target.gameObject.activeSelf){ target = center.EarthTarget; }
    if(target && time > unfreezeTime){
      destination.x = target.position.x;
      destination.y = engageY;
    }
    if(time > activeTime){ skill.SetActive(true); }
  }

  float unfreezeTime;
  public void Freeze(float freezeTime){
    destination = transform.position;
    unfreezeTime = time + freezeTime;
  }

}
