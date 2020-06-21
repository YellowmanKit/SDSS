using System.Collections;
using UnityEngine;

public class Float : Animation{

  protected override void Init(){
    originalPosition = transform.localPosition;
    originalEulerAngle = transform.localEulerAngles;
  }

  public bool noReset;
  void OnEnable(){
    if(noReset){ return; }
    rb.isKinematic = true;
    capsule.enabled = false;
    if(!initialized){ return; }
    transform.localPosition = originalPosition;
    transform.localEulerAngles = originalEulerAngle;
    if(recoil){ recoil.enabled = true; }
  }

  public Vector3 directionMin, directionMax;
  Vector3 randomDirection { get { return new Vector3(
    Random.Range(directionMin.x, directionMax.x),
    Random.Range(directionMin.y, directionMax.y),
    Random.Range(directionMin.z, directionMax.z)
  ); } }
  public float minForce, maxForce, minTorque, maxTorque;
  Vector3 randomForce{ get { return randomDirection * Random.Range(minForce, maxForce); } }
  Vector3 randomTorque{ get { return randomDirection * Random.Range(minTorque, maxTorque); } }

  public void Detach(){
    rb.isKinematic = false;
    capsule.enabled = true;
    rb.AddRelativeForce(randomForce, ForceMode.Impulse);
    rb.AddRelativeTorque(randomTorque, ForceMode.Impulse);
    if(recoil){ recoil.enabled = false; }
  }

}
