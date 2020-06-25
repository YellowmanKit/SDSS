using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class UI : Script{

  protected Panel panel { get { return center.panel; } }
  protected Select select { get { return panel.select; } }
  protected Ability ability { get { return panel.ability; } }

  protected Button button { get { return GetComponent<Button>(); } }
  protected Animator animator { get { return GetComponent<Animator>(); } }
  protected CanvasGroup cg { get { return GetComponent<CanvasGroup>(); } }

  protected override void Init(){}

}
