using System.Collections;
using UnityEngine;

public class Death : Behavioural{

  public GameObject skill, particle;
  void OnEnable(){
    skill.SetActive(true);
    particle.SetActive(true);
    capsule.enabled = true;
  }

  public Explode[] explodes;
  void SetExplodes(){ foreach(Explode explode in explodes){ explode.Detonate(); } }
  public Float[] floats;
  void SetFloats(){ foreach(Float floater in floats){ floater.Detach(); } }

  float deathDuration = 3f;
  float deathTime = float.MaxValue;
  public void Die(){
    deathTime = time + deathDuration;
    skill.SetActive(false);
    particle.SetActive(false);
    capsule.enabled = false;
    SetExplodes();
    SetFloats();
    if(go.CompareTag("Alien")){
      center.AlienDied(go.GetComponent<Alien>());
    }
  }

  void Update(){
    CheckDead();
  }

  void CheckDead(){
    if(time > deathTime){
      go.SetActive(false);
      deathTime = float.MaxValue;
    }
  }

}
