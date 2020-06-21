using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Option : UI{

  public Image icon;
  public bool selected;
  public void OnSelect(){
    selected = !selected;
    cg.alpha = selected?1f: 0.25f;
    select.slot.icon.sprite = selected? icon.sprite: panel.empty;
  }

}
