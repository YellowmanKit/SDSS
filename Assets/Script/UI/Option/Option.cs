using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Option : UI{

  public GameObject skillPrefab;
  public Image icon;
  public bool selected;
  public void OnSelect(){
    selected = !selected;
    cg.alpha = selected? 1f: 0.25f;
    select.slot.icon.sprite = selected? icon.sprite: panel.empty;
    if(selected){
      select.slot.skill = Instantiate(skillPrefab, center.player.soul.skill);
      center.panel.next.Activate(true);
    }else{
      GameObject.Destroy(select.slot.skill);
    }
  }

}
