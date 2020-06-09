using System.Collections;
using UnityEngine;

public class Gun : Active{

  protected override bool shouldUse { get { return center.HasEnemyInFront(transform.position.x); } }

  public float force;
  int shotCount;
  protected override void Use(){
    Fire();
    Recoil();
    OnUseEffect();
  }

  public int damage, bulletPerShot;
  public Spawnable bulletType;
  void Fire(){
    Loop(bulletPerShot, ()=>{
      Bullet bullet = center.pool.Spawn(bulletType, shotSpawns[shotCount].position).GetComponent<Bullet>();
      shotCount = (shotCount + 1) % shotSpawns.Length;
      bullet.damage = damage;
      bullet.Fire(force);
    });
  }

  public Recoil[] recoils;
  void Recoil(){
    recoils[shotCount].RecoilIn();
  }

  void OnUseEffect(){
    onUseEffects[shotCount].Play();
  }

}
