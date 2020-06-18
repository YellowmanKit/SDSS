using System.Collections;
using UnityEngine;

public abstract class Pilot : Behavioural{

  protected Hitpoint hitpoint { get { return GetComponent<Hitpoint>(); } }
  protected Shield shield { get { return GetComponentInChildren<Shield>(); } }
  protected Energy energy { get { return GetComponent<Energy>(); } }

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

  protected Vector2 RandomPosition(bool isAlien){
    return new Vector2(Random.Range(-boundary.x, boundary.x), Random.Range(-boundary.y, boundary.y));
  }
  
}
