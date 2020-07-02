using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class OptionBar : UI{

  public Option[] options;
  public void SetOptions(bool active){
    Loop(options.Length, i => {
      if(!options[i].initialized){ options[i].Awake(); }
      options[i].OnSelect(active);
    });
  }

}
