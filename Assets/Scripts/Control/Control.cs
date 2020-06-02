using System.Collections;
using UnityEngine;

public abstract class Control : Script{

  protected Player player { get { return GameObject.FindWithTag("Player").GetComponent<Player>(); }}

}
