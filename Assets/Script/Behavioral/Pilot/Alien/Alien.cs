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
    destination = RandomPosition();
    engageY = Random.Range(minY, maxY);
  }

  Transform target;
  float engageY;
  void Update(){
    if(!target || !target.gameObject.activeSelf){ target = center.earthTarget; }
    if(target && time > unstopTime){
      destination.x = target.position.x;
      destination.y = engageY;
    }
    if(time > activeTime){ skill.SetActive(true); }
  }

  float unstopTime;
  public void Stop(float stopTime){
    destination = transform.position;
    unstopTime = time + stopTime;
  }

  protected Vector2 RandomPosition(){
    return new Vector2(Random.Range(-boundary.x, boundary.x), Random.Range(0f, boundary.y));
  }

}
