using System.Collections;
using UnityEngine;

public class Rotate : Animation{

  public Vector3 rotation;

  void Update(){
    transform.Rotate(rotation * deltaTime);
  }

}
