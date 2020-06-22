using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Panel : Control{

  public Element next, restart;
  public Text stageCount;
  public Select select;
  public bool selecting { get { return select.gameObject.activeSelf; } }
  public Sprite empty;

  public Slot[] slots;
  public void AllowSkillChange(bool allow){
    Loop(slots.Length, i=>{
      slots[i].change.gameObject.SetActive(allow);
    });
  }


}
