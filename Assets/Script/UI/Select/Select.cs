using System.Collections;
using UnityEngine;

public class Select : UI{

  public Slot slot;

  protected override void Init(){
    go.SetActive(false);
  }

  public void Open(Slot slot){
    select.gameObject.SetActive(true);
    Option option = slot.option;
    SetOptions(false);
    if(option != null){ option.OnSelect(true); }
  }

  public void OnConfirmChange(){
    go.SetActive(false);
    ability.SetSlots(true);
  }

  Transform options { get { return transform.GetChild(0); } }
  public void SetOptions(bool active){
    Loop(options.childCount, i => {
      Option option = options.GetChild(i).GetComponent<Option>();
      if(!option.initialized){ option.Awake(); }
      options.GetChild(i).GetComponent<Option>().OnSelect(active);
    });
  }

}
