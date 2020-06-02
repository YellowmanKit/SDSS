using System.Collections;
using UnityEngine;

public abstract class Physical : Script{

  protected Rigidbody rb { get { return go.GetComponent<Rigidbody>(); } }
  protected void Push(Vector2 force){ rb.AddForce(force); }

}
