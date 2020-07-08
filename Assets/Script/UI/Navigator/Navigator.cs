using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum Category{
  None,
  Auto,
  Guard
}

public class Navigator : UI{

  public CanvasGroup[] categories;
  public Category selected;
  public void Select(Category category){
    selected = category;
    Loop(categories.Length, i => { categories[i].alpha = (Category)(i + 1) == selected? 1f: 0.25f; });
    menu.ActivateOptions(true, category);
  }

  public void Select(int index){ Select((Category)index); }

}
