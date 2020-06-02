using System.Collections;
using UnityEngine;

public abstract class Script : MonoBehaviour{

  protected GameObject go { get { return gameObject; } }
  protected Vector3 V3(float x, float y){ return new Vector3(x, y, 0f); }
  protected Vector2 V2(Vector3 v3){ return new Vector2(v3.x, v3.y); }

}
