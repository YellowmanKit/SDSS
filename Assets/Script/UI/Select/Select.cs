using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Select : UI{

  public Slot slot;

  protected override void Init(){
    go.SetActive(false);
  }

  public void Open(Slot slot){
    select.gameObject.SetActive(true);
    Option option = slot.option;
    menu.SetOptions(false);
    if(option != null){ option.OnSelect(true); }
    navigator.Select(slot.option? slot.option.category: slot.category);
  }

  public void OnConfirmChange(){
    go.SetActive(false);
    ability.SetSlots(true);
  }

}
