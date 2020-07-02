using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Option : UI{

  public Image icon;
  public bool equiped;
  public void OnToggle(){
    bool active = !equiped;
    optionBar.SetOptions(false);
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

  public GameObject skillPrefab;
  void EquipSkill(){
    ability.slot.skill = Instantiate(skillPrefab, center.player.soul.skill);
    Equip equip = ability.slot.skill.GetComponent<Equip>();
    equip.cdIndicator = ability.slot.cd;
    equip.skillButton = ability.slot.skillButton;
    equip.Set();
    equiped = true;
    center.panel.next.Activate(true);
  }

}
