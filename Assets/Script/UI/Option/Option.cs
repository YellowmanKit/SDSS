using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Option : UI{

  public Category category;
  public Image icon;
  public bool equiped;
  public void OnToggle(){
    bool active = !equiped;
    menu.SetOptions(false);
    OnSelect(active);
  }

  public void OnSelect(bool selected){
    cg.alpha = selected? 1f: 0.25f;
    if(!equiped && selected){
      ability.slot.Assign(this);
      EquipSkill();
    }else if(!selected){
      equiped = false;
      ability.slot.Dismiss();
    }
  }

  public Equipment equipment;
  void EquipSkill(){
    ability.slot.skill = Instantiate(menu.equipments[(int)equipment - 1], center.player.soul.skill);
    Equip equip = ability.slot.skill.GetComponent<Equip>();
    equip.cdIndicator = ability.slot.cd;
    equip.skillButton = ability.slot.skillButton;
    equip.Set();
    equiped = true;
    center.panel.next.Activate(true);
  }

}
