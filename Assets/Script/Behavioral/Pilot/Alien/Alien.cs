using System.Collections;
using UnityEngine;

public class Alien : Pilot{

  void OnEnable(){
    transform.localRotation = Quaternion.Euler(90f, 180f, 0f);
  }

  public float engageDistance;
  void Update(){
    destination.x = pp.x;
    destination.y = pp.y + engageDistance;
  }

}
