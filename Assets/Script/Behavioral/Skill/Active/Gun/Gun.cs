using System.Collections;
using UnityEngine;

public class Gun : Active{

  protected override bool shouldUse { get { return center.HasEnemyInLine(transform.position, go.tag, true); } }

  public float useDelay, shootDelay;
  public int bulletPerShot;
  int shotCount;
  protected override void Use(){
    onUseEffects[shotCount].Play();
    Alert();
    Loop(bulletPerShot, i=>{
      shootList.Add(time + useDelay + shootDelay * i);
    });
  }

  public float alertDuration;
  public Spawnable alertName;
  void Alert(){
    if(alertDuration > 0f){
      GameObject alert = center.pool.Spawn(alertName, transform.position, transform.rotation);
      Linear linear = alert.GetComponent<Linear>();
      if(linear != null){ linear.Play(alertDuration); }
    }
  }

  protected override void CheckShoot(){
    if(shootList.Count > 0 && time > shootList[0]){
      shootList.Remove(shootList[0]);
      Shoot();
      CheckShoot();
    }
  }

  void Shoot(){
    Fire();
    Recoil();
  }

  public float force;
  public int damage;
  public Spawnable bulletType;
  void Fire(){
    Transform shotSpawn = shotSpawns[shotCount];
    Bullet bullet = center.pool.Spawn(bulletType, shotSpawn.position, shotSpawn.rotation).GetComponent<Bullet>();
    bullet.gameObject.layer = go.layer + 2;
    shotCount = (shotCount + 1) % shotSpawns.Length;
    bullet.damage = damage;
    bullet.Fire(force);
  }

  public Recoil[] recoils;
  void Recoil(){
    recoils[shotCount].RecoilIn();
  }

}
