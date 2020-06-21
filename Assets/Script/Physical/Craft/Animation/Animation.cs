using System.Collections;
using UnityEngine;

public abstract class Animation : Craft{

  protected Vector3 originalPosition, originalEulerAngle;
  protected MeshRenderer meshRenderer { get { return GetComponent<MeshRenderer>(); } }
  protected Recoil recoil { get { return GetComponent<Recoil>(); } }

}
