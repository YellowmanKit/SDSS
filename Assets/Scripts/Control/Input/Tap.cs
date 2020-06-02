using System.Collections;
using UnityEngine;

public class Tap : Control{

  void Update(){
    if(Input.GetMouseButtonDown(0)){
      Tapping(Input.mousePosition);
    }
  }

  void Tapping(Vector3 position){
    Ray ray = Camera.main.ScreenPointToRay(position);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit)){
      player.destination = hit.point;
    }
  }

}
