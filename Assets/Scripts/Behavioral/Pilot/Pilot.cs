using System.Collections;
using UnityEngine;

public abstract class Pilot : Behavioural{

  public Vector2 destination;
  Engine engine { get { return go.GetComponent<Engine>(); } }

  void Update(){
    engine.direction = (destination - V2(transform.position)).normalized;
  }

}
