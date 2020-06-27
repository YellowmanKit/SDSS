using System.Collections;
using UnityEngine;
using System;

public abstract class Script : MonoBehaviour{

  protected GameObject go { get { return gameObject; } }
  protected Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
  protected Camera cam { get { return GameObject.FindWithTag("MainCamera").GetComponent<Camera>(); } }
  public CapsuleCollider capsule { get { return GetComponent<CapsuleCollider>(); } }
  protected BoxCollider box { get { return GetComponent<BoxCollider>(); } }

  protected float time { get { return Time.timeSinceLevelLoad; } }
  protected float deltaTime { get { return Time.deltaTime; } }

  protected Vector2 boundary = new Vector2(20f, 40f);
  protected bool OutY(float y, float maxY){ return Mathf.Abs(y) > maxY; }

  protected Center center;
  protected abstract void Init();
  protected bool initialized;
  void Awake(){
    center = GameObject.FindWithTag("Center").GetComponent<Center>();
    Init();
    initialized = true;
  }

  protected void Loop(int count, Action<int> action){ for(int i=0;i<count;i++){ action(i); } }
  protected void Loop(int count, Action action){ for(int i=0;i<count;i++){ action(); } }

}
