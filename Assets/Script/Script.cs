using System.Collections;
using UnityEngine;
using System;

public abstract class Script : MonoBehaviour{

  protected GameObject go { get { return gameObject; } }
  protected CapsuleCollider capsule { get { return GetComponent<CapsuleCollider>(); } }

  protected float time { get { return Time.timeSinceLevelLoad; } }
  protected float deltaTime { get { return Time.deltaTime; } }

  protected Vector2 boundary = new Vector2(22.5f, 40f);
  protected bool IsOutOfBoundary(Vector2 position){
    return Mathf.Abs(position.y) > boundary.y;
  }

  protected Center center;
  protected abstract void Init();
  protected bool initialized;
  void Start(){
    center = GameObject.FindWithTag("Center").GetComponent<Center>();
    Init();
    initialized = true;
  }
  protected void Loop(int count, Action<int> action){
    for(int i=0;i<count;i++){ action(i); }
  }
  protected void Loop(int count, Action action){
    for(int i=0;i<count;i++){ action(); }
  }

}
