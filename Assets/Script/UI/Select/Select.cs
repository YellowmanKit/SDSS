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
    optionBar.SetOptions(false);
    if(option != null){ option.OnSelect(true); }
    categoryBar.Select(slot.defaultCategory);
  }

  public void OnConfirmChange(){
    go.SetActive(false);
    ability.SetSlots(true);
  }

}
