using System.Collections;
using UnityEngine;

public class Alien : Pilot{

  public float engageDistance;
  void Update(){
    destination.x = pp.x;
    destination.y = pp.y + engageDistance;
  }

}
