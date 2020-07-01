using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Equip : Behavioural{

  public int[] usingShotSpawns, usingRecoils;
  public Button skillButton;

  Launcher launcher { get { return GetComponent<Launcher>(); } }
  public void Set(){
    if(launcher){
      Loop(usingShotSpawns.Length, i => { launcher.shotSpawns[i] = center.player.body.shotSpawns[usingShotSpawns[i]]; });
      Loop(usingRecoils.Length, i => { launcher.recoils[i] = center.player.body.recoils[usingRecoils[i]]; });
      skillButton.onClick.AddListener(launcher.ActivelyUse);
    }
  }

  public Image cdIndicator;
  void Update(){
    if(launcher){ cdIndicator.fillAmount = (launcher.nextUse - time) / launcher.cd; }
  }

}
