using System.Collections;
using UnityEngine;

public class Recoil : Animation{

  protected override void Init(){
    originalPosition = transform.localPosition;
  }

  public Vector3 deltaPosition;
  public void RecoilIn(){
    transform.localPosition = transform.localPosition + deltaPosition;
  }

  void Update(){
    RecoilBack();
  }

  public float tension;
  void RecoilBack(){
    Vector3 back = (originalPosition - transform.localPosition) * tension * deltaTime;
    transform.localPosition = transform.localPosition + back;
  }

}
