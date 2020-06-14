using System.Collections;
using UnityEngine;

public abstract class Skill : Behavioural{

  protected Energy energy { get { return GetComponentInParent<Energy>(); } }

}
