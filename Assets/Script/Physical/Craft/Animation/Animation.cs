using System.Collections;
using UnityEngine;

public abstract class Animation : Craft{

  protected MeshRenderer meshRenderer { get { return go.GetComponent<MeshRenderer>(); } }

  protected void Rotate(Vector3 rotation){
    transform.Rotate(rotation * deltaTime);
  }

}
