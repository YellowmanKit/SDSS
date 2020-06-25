using System.Collections;
using UnityEngine;

public class Select : UI{

  public Slot slot;

  protected override void Init(){
    go.SetActive(false);
  }

  public void Open(Slot slot){
    select.gameObject.SetActive(true);
    SetOptions(false);
    if(slot.option != null){ slot.option.OnSelect(true); }
  }

  public void OnConfirmChange(){
    go.SetActive(false);
    ability.SetSlots(true);
  }

  Transform options { get { return transform.GetChild(0); } }
  public void SetOptions(bool active){
    Loop(options.childCount, i => {
      Option option = options.GetChild(i).GetComponent<Option>();
      options.GetChild(i).GetComponent<Option>().OnSelect(active);
    });
  }

}
