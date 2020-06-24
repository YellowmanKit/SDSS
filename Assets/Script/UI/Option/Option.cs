using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Option : UI{

  public Image icon;
  public bool selected;
  public void OnSelect(){
    selected = !selected;
    cg.alpha = selected? 1f: 0.25f;
    select.slot.icon.sprite = selected? icon.sprite: panel.empty;
    if(selected){
      EquipSkill();
    }else{
      GameObject.Destroy(select.slot.skill);
    }
  }

  public GameObject skillPrefab;
  void EquipSkill(){
    select.slot.skill = Instantiate(skillPrefab, center.player.soul.skill);
    Equip equip = select.slot.skill.GetComponent<Equip>();
    equip.cdIndicator = select.slot.cd;
    equip.skillButton = select.slot.skillButton;
    equip.Set();
    center.panel.next.Activate(true);
  }

}
