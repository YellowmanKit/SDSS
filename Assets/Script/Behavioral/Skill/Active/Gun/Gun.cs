using System.Collections;
using UnityEngine;

public class Gun : Active{

  protected override bool shouldUse { get { return center.HasEnemyInFront(transform.position.x, go.tag); } }

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
      Transform shotSpawn = shotSpawns[shotCount];
      Bullet bullet = center.pool.Spawn(bulletType, shotSpawn.position, shotSpawn.rotation).GetComponent<Bullet>();
      bullet.gameObject.layer = go.layer + 2;
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
    onUseEffects[shotCount]?.Play();
  }

}
