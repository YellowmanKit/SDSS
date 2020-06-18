using System.Collections;
using UnityEngine;

public class Energy : Behavioural{

  public float maxEnergy, energy, regen;

  void OnEnable(){
    energy = maxEnergy;
  }

  public void GainEnergy(float value){
    energy = Mathf.Clamp(energy + value, 0f, maxEnergy);
  }

  void Update(){
    GainEnergy(regen * maxEnergy * deltaTime);
  }

}
