using System.Collections;
using UnityEngine;

public abstract class Script : MonoBehaviour{

  protected GameObject go { get { return gameObject; } }
  protected CapsuleCollider capsule { get { return go.GetComponent<CapsuleCollider>(); } }
  protected MeshRenderer meshRenderer { get { return go.GetComponent<MeshRenderer>(); } }

  protected Vector2 V2(Vector3 v3){ return new Vector2(v3.x, v3.y); }
  protected float time { get { return Time.timeSinceLevelLoad; } }
  protected float deltaTime { get { return Time.deltaTime; } }

  protected Vector2 boundary = new Vector2(22.5f, 35f);
  protected Vector2 OutOfBoundary(Vector2 position){
    return new Vector2(
      position.x > boundary.x? -1f: position.x < -boundary.x? 1f:0f,
      position.y > boundary.y? -1f: position.y < -boundary.y? 1f:0f
    );
  }
  protected Vector2 BoundaryClamp(Vector2 position){
    return new Vector2(
      Mathf.Clamp(position.x, -boundary.x, boundary.x),
      Mathf.Clamp(position.y, -boundary.y, boundary.y)
    );
  }
  protected bool IsOutOfBoundary(Vector2 position){
    return position.x > boundary.x || position.x < -boundary.x || position.y > boundary.y || position.y < -boundary.y;
  }

  protected Center center;
  protected abstract void Init();
  protected bool initialized;
  void Start(){
    center = GameObject.FindWithTag("Center").GetComponent<Center>();
    Init();
    initialized = true;
  }

}
