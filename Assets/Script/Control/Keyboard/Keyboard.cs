using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : Control{

  void Update(){
    Movement();
    Select();
    Skill();
    Control();
  }

  void Select(){
    if(center.stage.battling){ return; }
    if(Input.GetKey(KeyCode.LeftShift)){
      foreach(Slot slot in center.panel.ability.slots){
        if(Input.GetKeyDown(slot.keyCode)){
          slot.OnChange();
        }
      }
    }
    if(!center.panel.select.gameObject.activeSelf){ return; }
    if(Input.GetKey(KeyCode.LeftShift)){
      Loop(5, i => {
        if(Input.GetKey(NumberToKeyCode(i))){
          center.panel.select.navigator.Select(i + 1);
        }
      });
    }else{
      foreach(Option option in center.panel.select.menu.availableOptions){
        if(Input.GetKeyDown(option.keyCode)){
          option.OnToggle();
        }
      }
    }
  }

  float vertical { get { return Input.GetAxis("Vertical"); } }
  float horizontal { get { return Input.GetAxis("Horizontal"); } }
  public float sensitivity;
  void Movement(){
    if(vertical == 0f && horizontal == 0f){ return; }
    center.player.destination = new Vector2(
    center.player.transform.position.x + horizontal * sensitivity,
    center.player.transform.position.y + vertical * sensitivity);
  }

  public List<Equip> equips = new List<Equip>();
  void Skill(){
    foreach(Equip equip in equips){
      if(Input.GetKey(equip.slot.keyCode)){
        if(equip.launcher){ equip.launcher.ActivelyUse(); }
      }
    }
  }

  void Control(){
    if(Input.GetKey(KeyCode.Space)){
      if(center.panel.next.available){
        center.stage.NextStage();
      }else if(center.panel.restart.available){
        center.stage.Restart();
      }
    }
  }

}
