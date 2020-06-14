using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class UI : Script{

  protected Button button { get { return GetComponent<Button>(); } }
  protected Animator animator { get { return GetComponent<Animator>(); } }

  protected override void Init(){}

}
