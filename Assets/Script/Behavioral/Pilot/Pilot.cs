using System.Collections;
using UnityEngine;

public abstract class Pilot : Behavioural{

  public Vector2 destination;
  protected override void Init(){
    destination = transform.position;
  }

  void FixedUpdate(){
    Drive();
  }

  Vector2 delta { get { return BoundaryClamp(destination) - V2(transform.position); } }
  public float brakeFactor, outputFactor;
  void Drive(){
    engine.output = delta.magnitude / outputFactor;
    engine.direction = (BackToArea(transform.position) + (delta * brakeFactor - engine.velocity)).normalized;
  }

}
