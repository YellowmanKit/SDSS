using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Element : UI{

  public bool init;
  protected override void Init(){
    Activate(init);
  }

  public bool available;
  public void Activate(bool active){
    available = active;
    button.interactable = active;
    animator.Play(active? "Active":"Inactive");
  }

}
