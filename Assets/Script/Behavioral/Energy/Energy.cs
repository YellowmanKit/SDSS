using System.Collections;
using UnityEngine;

public class Energy : Behavioural{

  public float maxEnergy, energy, regen;

  void OnEnable(){
    energy = maxEnergy;
  }

  void Update(){
    energy =  Mathf.Clamp(energy + regen * deltaTime, -maxEnergy, maxEnergy);
  }

}
