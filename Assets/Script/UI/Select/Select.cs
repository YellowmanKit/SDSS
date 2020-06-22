using System.Collections;
using UnityEngine;

public class Select : UI{

  public Slot slot;

  protected override void Init(){
    go.SetActive(false);
  }

  public void OnConfirmChange(){
    go.SetActive(false);
    slot.change.gameObject.SetActive(true);
  }
  
}
