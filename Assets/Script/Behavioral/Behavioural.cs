using System.Collections;
using UnityEngine;

public abstract class Behavioural : Script{

  protected override void Init(){}

  protected Vector2 V2(Vector3 v3){ return new Vector2(v3.x, v3.y); }

  protected Engine engine { get { return GetComponent<Engine>(); } }
  protected Vector2 pp { get { return  center.player.transform.position; } }
  protected CapsuleCollider parentCapsule { get { return GetComponentInParent<CapsuleCollider>(); } }
  public Hitpoint hitpoint { get { return GetComponent<Hitpoint>(); } }

  protected Vector2 BackToArea(Vector2 position){
    return new Vector2(
      position.x > boundary.x? -1f: position.x < -boundary.x? 1f: 0f,
      position.y > boundary.y? -1f: position.y < -boundary.y? 1f: 0f
    );
  }

  protected Vector2 BoundaryClamp(Vector2 position){
    return new Vector2(
      Mathf.Clamp(position.x, -boundary.x, boundary.x),
      Mathf.Clamp(position.y, -boundary.y, boundary.y)
    );
  }

}
