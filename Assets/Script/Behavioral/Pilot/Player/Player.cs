using System.Collections;
using UnityEngine;

public class Player : Pilot{

  void OnEnable(){
    transform.localRotation = Quaternion.Euler(270f, 0f, 0f);
  }

  public ParticleSystem boost;
  public void Tapped(Vector3 position){
    destination = position;
    boost.Play();
  }

}
