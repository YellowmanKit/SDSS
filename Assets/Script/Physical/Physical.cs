using System.Collections;
using UnityEngine;

public abstract class Physical : Script{

  protected override void Init(){}
  protected Rigidbody rb { get { return go.GetComponent<Rigidbody>(); } }

  protected void Push(Vector2 force){ rb.AddForce(force); }
  protected void Spin(Vector3 force){ rb.AddTorque(force); }

  protected void Freeze(){ rb.velocity = Vector3.zero; }

}
