using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : Behavioural{

  public int[] usingShotSpawns, usingRecoils;

  protected override void Init(){
    Gun gun = GetComponent<Gun>();
    if(gun){
      Loop(usingShotSpawns.Length, i => {
        gun.shotSpawns[i] = center.player.body.shotSpawns[usingShotSpawns[i]];
      });
      Loop(usingRecoils.Length, i => {
        gun.recoils[i] = center.player.body.recoils[usingRecoils[i]];
      });
    }

  }

}
