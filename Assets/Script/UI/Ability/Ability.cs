using System.Collections;
using UnityEngine;

public class Ability : UI{

  public Slot slot;
  public Slot[] slots;

  protected override void Init(){
    Loop(slots.Length, i => {
      Slot slot = slots[i];
      slot.gameObject.SetActive(false);
    });
    slots[0].gameObject.SetActive(true);
  }

  int nextSlot = 1;
  public void UnlockSlot(){
    if(nextSlot >= slots.Length){ return; }
    slots[nextSlot].gameObject.SetActive(true);
    nextSlot++;
  }

  public void SetChangeButtons(bool active){
    Loop(slots.Length, i => {
      Slot slot = slots[i];
      slot.change.gameObject.SetActive(active);
    });
  }

  public void SetSlots(bool active){
    SetChangeButtons(active);
    Loop(slots.Length, i => {
      Slot slot = slots[i];
      slot.SetActive(active);
    });
  }

}
