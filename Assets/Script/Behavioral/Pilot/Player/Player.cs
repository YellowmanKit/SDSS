using System.Collections;
using UnityEngine;

public class Player : Pilot{

  public ParticleSystem boost;
  public void Tapped(Vector3 position){
    destination = position;
    boost.Play();
  }

}
