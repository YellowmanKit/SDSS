using System.Collections;
using UnityEngine;

public abstract class Control : Script{

  protected override void Init(){}

  protected int uiLayer { get { return (1 << 5); } }

}
