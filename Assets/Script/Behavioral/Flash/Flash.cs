using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : Behavioural{

  Light flash { get { return GetComponent<Light>(); } }
  public float intensity, initIntensity;
  void OnEnable(){
    flash.intensity = initIntensity;
  }

  public void Emit(){
    flash.intensity = intensity;
  }

  public float decayIn;
  void FixedUpdate(){
    flash.intensity -= intensity * deltaTime / decayIn ;
  }

}
