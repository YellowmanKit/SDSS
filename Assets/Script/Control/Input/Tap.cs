using System.Collections;
using UnityEngine;

public class Tap : Control{

  void Update(){
    CheckMouse();
  }

  float nextCheck;
  void CheckMouse(){
    if(Input.GetMouseButton(0) && time > nextCheck){
      nextCheck = time + 0.2f;
      Tapping(Input.mousePosition);
    }
  }

  void Tapping(Vector3 position){
    Ray ray = Camera.main.ScreenPointToRay(position);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit)){
      center.player.Tapped(hit.point);
      center.pool.Spawn(Spawnable.Tap, hit.point);
    }
  }

}
