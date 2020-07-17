using System.Collections;
using UnityEngine;

public abstract class Alert : Behavioural{

  protected ParticleSystem ps { get { return GetComponent<ParticleSystem>(); } }
  protected bool playing;

}
