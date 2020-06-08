using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectName {
  Tap,
  GatlingBullet,
  GatlingBulletOnHit,
  AlienWarthog
}

public class Pool : Control{

  public GameObject[] objects;
  Dictionary<ObjectName, GameObject> objectDictionary = new Dictionary<ObjectName, GameObject>();

  protected override void Init(){
    for(int i=0;i<objects.Length;i++){
      objectDictionary.Add((ObjectName)i, objects[i]);
    }
  }

  public GameObject Spawn(ObjectName objectName, Vector3 position, Quaternion rotation){
    for(int i=0;i<transform.childCount;i++){
      GameObject child = transform.GetChild(i).gameObject;
      if(child.name.Equals(objectName.ToString()) && !child.activeSelf){
        child.SetActive(true);
        child.transform.position = position;
        return child;
      }
    }
    GameObject newChild = Instantiate(objectDictionary[objectName], position, rotation);
    newChild.transform.parent = transform;
    newChild.name = objectName.ToString();
    return newChild;
  }

  public GameObject Spawn(ObjectName objectName, Vector3 position){
    return Spawn(objectName, position, objectDictionary[objectName].transform.rotation);
  }

}
