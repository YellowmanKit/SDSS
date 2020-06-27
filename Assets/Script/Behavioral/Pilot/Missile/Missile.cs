using System.Collections;
using UnityEngine;

public class Missile : Pilot{

  TrailRenderer tr { get { return GetComponentInChildren<TrailRenderer>(); } }
  public float duration;
  float fuseTime;
  void OnEnable(){
    fuseTime = time + duration;
    Transform target = go.tag == "Alien"? center.player.transform: center.alienTarget;
    if(target){ destination = target.position; }
    else { destination = new Vector3(transform.position.x, go.tag == "Alien"?-100f: 100f, 0f); }
  }

  void OnDisable(){
    tr.Clear();
  }

  Bullet bullet { get { return GetComponent<Bullet>(); } }
  void Update(){
    if(time > fuseTime){ bullet.Explode(); }
  }

}
