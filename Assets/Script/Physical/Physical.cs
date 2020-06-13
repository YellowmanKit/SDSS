using System.Collections;
using UnityEngine;

public abstract class Physical : Script{

  protected override void Init(){}

  protected Rigidbody rb { get { return GetComponent<Rigidbody>(); } }

}
