using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Equipment{
  None,
  TrackMissile,
  NeutronLance,
  GatlingGun,
  ChargeBeam,
  PlasmaCannon,
  MissileBlossom,
  GaussCannon,
  UltraBeam,
  PlasmaNova,
  ElectroMagnecticPulse
}

public class Menu : UI{

  public Option[] options;
  public GameObject[] equipments;
  public void SetOptions(bool active){
    Loop(options.Length, i => {
      if(!options[i].initialized){ options[i].Awake(); }
      options[i].OnSelect(active);
    });
  }

  public List<Option> availableOptions = new List<Option>();
  public void ActivateOptions(bool active, Category category){
    availableOptions.Clear();
    int count = 0;
    Loop(options.Length, i => {
      if(category == options[i].category){
        options[i].gameObject.SetActive(active);
        options[i].keyCode = NumberToKeyCode(count);
        count++;
        availableOptions.Add(options[i]);
      }else{
        options[i].gameObject.SetActive(!active);
      }
    });
  }

}
