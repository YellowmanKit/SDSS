using System.Collections;
using UnityEngine;

public abstract class Animation : Craft{

  protected void Rotate(Vector3 rotation){
    transform.Rotate(rotation * deltaTime);
  }

}
