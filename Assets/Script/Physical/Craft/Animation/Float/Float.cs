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
  Vector3 direction { get { return new Vector3(
    Random.Range(directionMin.x, directionMax.x),
    Random.Range(directionMin.y, directionMax.y),
    Random.Range(directionMin.z, directionMax.z)
  ); } }
  public float minForce, maxForce, minTorque, maxTorque;
  float randomTorque{ get { return Random.Range(minTorque, maxTorque); } }
  public void Detach(){
    rb.isKinematic = false;
    capsule.enabled = true;
    Push(direction * Random.Range(minForce, maxForce));
    Spin(new Vector3(randomTorque, randomTorque, randomTorque));
  }

}
