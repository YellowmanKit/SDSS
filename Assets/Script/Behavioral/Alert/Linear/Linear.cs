using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linear : Alert{

  public void Play(float duration){
    var main = alertEffect.main;
    main.startLifetime = duration;
    playing = true;
  }

  public float speed;
  void FixedUpdate(){
    if(playing && !OutY(transform.position.y, boundary.y)){
      transform.Translate(new Vector3(0f, 0f, playing? speed * deltaTime: 0f));
    }else{
      playing = false;
    }
  }

}
