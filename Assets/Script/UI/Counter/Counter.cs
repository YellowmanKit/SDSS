using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : UI{

  public float targetValue, targetValueMax, reactionSpeed, baseHeight, iconHeight;
  float displayValue;

  public Image maskImage;
  public RectTransform icon;
  public float baseValue, newValue, expandSpeed;
  void Update(){
    UpdateValue();
    UpdateHeight();
  }

  void UpdateValue(){
    displayValue = displayValue + (targetValue - displayValue) * reactionSpeed * deltaTime;
    maskImage.fillAmount = Mathf.Clamp(displayValue / targetValueMax, 0f, 1f);
  }

  void UpdateHeight(){
    if(icon){
      float currentHeight = maskImage.rectTransform.sizeDelta.y;
      float newHeight = baseHeight * newValue / baseValue;
      float delta = newHeight - currentHeight;
      maskImage.rectTransform.sizeDelta = new Vector2(25f, currentHeight + delta * deltaTime * expandSpeed);
      Vector3 iconPosition = icon.position;
      icon.position = new Vector3(iconPosition.x, currentHeight + iconHeight, iconPosition.z);
    }
  }

}
