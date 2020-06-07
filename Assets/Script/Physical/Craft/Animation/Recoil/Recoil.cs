using System.Collections;
using UnityEngine;

public class Recoil : Animation{

  Vector3 original;
  protected override void Init(){
    original = transform.localPosition;
  }

  public Vector3 recoil;
  public void RecoilIn(){
    transform.localPosition = transform.localPosition + recoil;
  }

  void Update(){
    RecoilBack();
  }

  public float tension;
  void RecoilBack(){
    transform.Translate((original - transform.localPosition) * tension * deltaTime, Space.Self);
  }

}
