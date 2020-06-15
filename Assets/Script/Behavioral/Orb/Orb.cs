using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : Behavioural{

  public float dropForce;
  void FixedUpdate(){
    rb.AddForce(new Vector3(0f, -dropForce * deltaTime, 0f));
  }

}
