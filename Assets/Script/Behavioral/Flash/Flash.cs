using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : Behavioural{

  Light flash { get { return GetComponent<Light>(); } }
  float deadTime;
  public float intensity, initIntensity, maxIntensity;
  void OnEnable(){
    flash.intensity = initIntensity;
    deadTime = float.MaxValue;
  }

  bool glowing;
  public void GlowForSecond(float second){
    deadTime = time + second;
    glowing = true;
  }

  public void Emit(){
    flash.intensity = intensity;
  }

  public float decayIn, glowIn;
  void FixedUpdate(){
    if(glowing){
      flash.intensity = Mathf.Clamp(flash.intensity + maxIntensity * deltaTime / glowIn, 0f, maxIntensity);
    }else if(decayIn > 0f){
      flash.intensity = Mathf.Clamp(flash.intensity - intensity * deltaTime / decayIn, 0f, float.MaxValue);
    }
    if(time > deadTime){
      flash.intensity = 0f;
      deadTime = float.MaxValue;
      glowing = false;
    }
  }

}
