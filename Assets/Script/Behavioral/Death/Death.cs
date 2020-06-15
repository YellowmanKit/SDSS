using System.Collections;
using UnityEngine;

public class Death : Behavioural{

  public GameObject soul;
  void OnEnable(){
    soul.SetActive(true);
    ControlComponents(true);
    engine.Freeze(false);
  }

  public Explode[] explodes;
  void SetExplodes(){ foreach(Explode explode in explodes){ explode.Detonate(); } }
  public Float[] floats;
  void SetFloats(){ foreach(Float floater in floats){ floater.Detach(); } }

  float decay = 3f;
  float decayTime = float.MaxValue;
  public void Die(){
    decayTime = time + decay;
    soul.SetActive(false);
    engine.Freeze(true);
    ControlComponents(false);
    SetExplodes();
    SetFloats();
    DropOrb();
    if(go.CompareTag("Alien")){
      center.AlienDied(go);
    }else{
      center.EarthDied(go);
    }
  }

  public int orbValue;
  void DropOrb(){
    Loop(orbValue, ()=> {
      center.orbCount += 1;
      GameObject orb = center.pool.Spawn(center.orbCount % 2 == 0? Spawnable.ShieldOrb: Spawnable.EnergyOrb, transform.position);
      orb.GetComponent<Float>().Detach();
    });
  }

  void Update(){
    CheckDead();
  }

  void CheckDead(){
    if(time > decayTime){
      go.SetActive(false);
      decayTime = float.MaxValue;
    }
  }

  void ControlComponents(bool active){
    engine.enabled = active;
    capsule.enabled = active;
  }

}
