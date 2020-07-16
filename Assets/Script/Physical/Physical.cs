using System.Collections;
using UnityEngine;

public abstract class Physical : Script{

  protected SpriteRenderer sprite { get { return GetComponentInChildren<SpriteRenderer>(); } }

  protected override void Init(){}

}
