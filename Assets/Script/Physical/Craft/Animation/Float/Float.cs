using System.Collections;
using UnityEngine;

public class Float : Animation{

  Vector3 originalPosition, originalEulerAngle;
  protected override void Init(){
    originalPosition = transform.localPosition;
    originalEulerAngle = transform.localEulerAngles;
  }

  void OnEnable(){
    if(!initialized){ return; }
    rb.isKinematic = true;
    capsule.enabled = false;
    transform.localPosition = originalPosition;
    transform.localEulerAngles = originalEulerAngle;
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
    rb.AddForce(randomForce);
    rb.AddTorque(randomForce);
  }

}
