using System.Collections;
using UnityEngine;

public class Launcher : Active{

  protected override bool shouldUse { get {
    return ((alwaysUse && center.stage.battling) ||
    (autoUse && center.HasEnemyInLine(transform.position, go.tag, true)) && !center.stage.gameOvered); } }

  public float shootDelay;
  public int bulletPerShot, shotPerUse;
  int shotCount;
  protected override void Use(){
    Alert();
    if(onUseEffects.Length > shotCount)
    onUseEffects[shotCount].Play();
    if(glows.Length > 0){ glows[shotCount].GlowForSecond(useDelay); }
    Loop(shotPerUse, i => {
      Loop(bulletPerShot, ()=>{
        shootList.Add(time + useDelay + shootDelay * i);
      });
    });
  }

  public float alertDuration;
  public Spawnable alertName;
  void Alert(){
    if(alertDuration > 0f){
      GameObject alert = center.pool.Spawn(alertName, transform.position, transform.rotation);
      Linear linear = alert.GetComponent<Linear>();
      if(linear){ linear.Play(alertDuration); }
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
  public Spawnable projectileType;
  public bool isBeam, isPulse;
  void Fire(){
    if(flashes.Length > shotCount){
      flashes[shotCount].Emit();
    }
    Transform shotSpawn = shotSpawns[shotCount];
    shotCount = (shotCount + 1) % shotSpawns.Length;
    GameObject projectile = center.pool.Spawn(projectileType, shotSpawn.position, shotSpawn.rotation);
    projectile.layer = go.layer + (isPulse? 4: 2);
    if(isBeam){ FireBeam(projectile.GetComponent<Beam>(), shotSpawn);
    }else if(isPulse){
    }else{ FireBullet(projectile.GetComponent<Bullet>()); }
  }

  void FireBeam(Beam beam, Transform source){
    beam.damage = damage;
    beam.penetration = penetration;
    beam.Fire(source);
  }

  public float penetration;
  void FireBullet(Bullet bullet){
    bullet.damage = damage;
    bullet.penetration = penetration;
    bullet.tag = go.tag;
    bullet.Fire(force);
  }

  public Recoil[] recoils;
  public float recoil;
  void Recoil(){
    if(recoils.Length > shotCount){ recoils[shotCount].RecoilIn(); }
    GetComponentInParent<Rigidbody>().AddForce(Vector3.up * -recoil, ForceMode.Impulse);
  }

}
