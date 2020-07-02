using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum Category{
  Auto,
  Guard
}

public class CategoryBar : UI{

  public CanvasGroup[] categories;
  public Category selectedCategory;
  public void Select(Category categoryName){
    selectedCategory = categoryName;
    Loop(categories.Length, i => {
      categories[i].alpha = (Category)i == selectedCategory? 1f: 0.25f;
    });
  }

  public void Select(int index){ Select((Category)index); }

}
