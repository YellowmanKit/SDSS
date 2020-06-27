using System.Collections;
using UnityEngine;

public abstract class Pilot : Behavioural{

  public Body body { get { return GetComponentInChildren<Body>(); } }
  public Soul soul { get { return GetComponentInChildren<Soul>(); } }
  public Energy energy { get { return GetComponent<Energy>(); } }

  protected Hitpoint hitpoint { get { return GetComponent<Hitpoint>(); } }
  protected Shield shield { get { return GetComponentInChildren<Shield>(); } }

  protected Death death { get { return GetComponent<Death>(); } }

  public Vector2 destination;

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
