﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Slot : UI{

  public Image icon, cd;
  public Button change;
  public Button skillButton { get { return GetComponent<Button>(); } }

  public void OnChange(){
    ability.SetSlots(false);
    ability.slot = GetComponent<Slot>();
    SetActive(true);
    select.Open(this);
  }

  public Option option;
  public void Assign(Option assign){
    option = assign;
    icon.sprite = assign.icon.sprite;
  }

  public GameObject skill;
  public void Dismiss(){
    icon.sprite = panel.empty;
    GameObject.Destroy(skill);
  }

  public void SetActive(bool active){
    cg.alpha = active? 1f: 0.25f;
    cg.interactable = active;
  }

}
