using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Spawnable {
  Tap,
  GatlingBullet,
  GatlingBulletOnHit,
  AlienWarthog,
  NeutronBullet,
  NeutronBulletOnHit,
  LinearAlert
}

public class Pool : Control{

  public GameObject[] objects;
  Dictionary<Spawnable, GameObject> spawnables = new Dictionary<Spawnable, GameObject>();

  protected override void Init(){
    Loop(objects.Length, i=>{ spawnables.Add((Spawnable)i, objects[i]); });
  }

  public GameObject Spawn(Spawnable spawnable, Vector3 position, Quaternion rotation){
    for(int i=0;i<transform.childCount;i++){
      GameObject child = transform.GetChild(i).gameObject;
      if(child.name.Equals(spawnable.ToString()) && !child.activeSelf){
        child.transform.position = position;
        child.transform.rotation = rotation;
        child.SetActive(true);
        return child;
      }
    }
    return NewSpawn(spawnable, position, rotation);
  }

  public GameObject Spawn(Spawnable spawnable, Vector3 position){
    return Spawn(spawnable, position, spawnables[spawnable].transform.rotation);
  }

  GameObject NewSpawn(Spawnable spawnable, Vector3 position, Quaternion rotation){
    GameObject newChild = Instantiate(spawnables[spawnable], position, rotation, transform);
    newChild.name = spawnable.ToString();
    return newChild;
  }

}
