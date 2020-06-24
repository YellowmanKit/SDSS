using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Equip : Behavioural{

  public int[] usingShotSpawns, usingRecoils;
  public Button skillButton;

  Gun gun { get { return GetComponent<Gun>(); } }
  public void Set(){
    if(gun){
      Loop(usingShotSpawns.Length, i => { gun.shotSpawns[i] = center.player.body.shotSpawns[usingShotSpawns[i]]; });
      Loop(usingRecoils.Length, i => { gun.recoils[i] = center.player.body.recoils[usingRecoils[i]]; });
      skillButton.onClick.AddListener(gun.ActivelyUse);
    }
  }

  public Image cdIndicator;
  void Update(){
    if(gun){ cdIndicator.fillAmount = (gun.nextUse - time) / gun.cd; }
  }

}
