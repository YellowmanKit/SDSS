using System.Collections;
using UnityEngine;

public class Explode : Animation{

  void OnEnable(){
    meshRenderer.enabled = true;
  }

  public ParticleSystem explosion;
  public void Detonate(){
    meshRenderer.enabled = false;
    explosion.Play();
  }

}
