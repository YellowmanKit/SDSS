using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Equip : Behavioural{

  public int[] usingShotSpawns, usingRecoils;
  public Slot slot;

  public Launcher launcher { get { return GetComponent<Launcher>(); } }
  public void Set(){
    center.keyboard.equips.Add(this);
    if(launcher){
      Loop(usingShotSpawns.Length, i => { launcher.shotSpawns[i] = center.player.body.shotSpawns[usingShotSpawns[i]]; });
      Loop(usingRecoils.Length, i => { launcher.recoils[i] = center.player.body.recoils[usingRecoils[i]]; });
      slot.skillButton.onClick.AddListener(launcher.ActivelyUse);
    }
  }

  void Update(){
    if(launcher){ slot.cd.fillAmount = (launcher.nextUse - time) / launcher.cd; }
  }

}
