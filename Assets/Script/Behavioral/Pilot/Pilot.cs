using System.Collections;
using UnityEngine;

public abstract class Pilot : Behavioural{

  protected Vector2 pp { get { return  center.player.transform.position; } }

  public Vector2 destination;
  protected override void Init(){
    destination = transform.position;
  }

  void FixedUpdate(){
    Drive();
  }

  public float brakeFactor, outputFactor;
  Engine engine { get { return go.GetComponent<Engine>(); } }
  void Drive(){
    Vector2 delta = BoundaryClamp(destination) - V2(transform.position);
    engine.output = delta.magnitude / outputFactor;
    engine.direction = (OutOfBoundary(transform.position) + (delta * brakeFactor - engine.velocity)).normalized;
  }

}
