using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum Equipment{
  None,
  AntimatterMissile,
  NeutronLance,
  GatlingGun,
  ChargeBeam,
  PlasmaCannon,
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

  public void ActivateOptions(bool active, Category category){
    Loop(options.Length, i => {
      if(category == options[i].category){
        options[i].gameObject.SetActive(active);
      }else{
        options[i].gameObject.SetActive(!active);
      }
    });
  }

}
