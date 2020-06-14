using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : UI{

  public float targetValue, targetValueMax, reactionSpeed;
  float displayValue;

  public Image maskImage;
  void Update(){
    displayValue = displayValue + (targetValue - displayValue) * reactionSpeed * deltaTime;
    maskImage.fillAmount = Mathf.Clamp(displayValue / targetValueMax, 0f, 1f);
  }

}
