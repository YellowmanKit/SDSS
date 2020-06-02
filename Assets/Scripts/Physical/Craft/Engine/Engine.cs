using System.Collections;
using UnityEngine;

public class Engine : Craft{

  public float thrust;
  public Vector2 direction;

  void FixedUpdate(){
    Push(direction * thrust);
  }

}
