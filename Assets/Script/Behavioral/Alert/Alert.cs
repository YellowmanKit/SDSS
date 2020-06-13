using System.Collections;
using UnityEngine;

public abstract class Alert : Behavioural{

  protected ParticleSystem alertEffect { get { return GetComponent<ParticleSystem>(); } }

}
