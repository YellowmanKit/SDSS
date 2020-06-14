using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Element : UI{

  public void Activate(bool active){
    button.interactable = active;
    animator.Play(active? "Active":"Inactive");
  }

}
