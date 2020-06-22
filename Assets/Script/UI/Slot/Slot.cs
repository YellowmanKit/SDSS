﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Slot : UI{

  public Image icon, cd;
  public Button change;

  public void OnChange(){
    change.gameObject.SetActive(false);
    select.gameObject.SetActive(true);
    select.slot = GetComponent<Slot>();
  }

  public GameObject skill;

}