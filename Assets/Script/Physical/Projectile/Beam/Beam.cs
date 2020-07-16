using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Beam : Projectile{

  public float duration, frequency, width;
  Transform parent;
  public void Fire(Transform source){
    dieTime = time + duration;
    box.size = new Vector3(width, box.size.y, box.size.z);
    parent = source;
  }

  public List<Hitpoint> hitting = new List<Hitpoint>();
  protected override void OnHit(Hitpoint hitpoint){
    if(!hitting.Contains(hitpoint)){ hitting.Add(hitpoint); }
  }

  void Update(){
    if(parent){ transform.position = parent.position; }
    CheckIntersect();
    DealDamage();
    Shrink();
    RenderBeam();
    CheckDie();
  }

  public float shrinkIn;
  void Shrink(){
    float newWidth = Mathf.Clamp(box.size.x - (width * deltaTime / shrinkIn), 0f, width);
    box.size = new Vector3(newWidth, box.size.y, box.size.z);
  }

  void CheckIntersect(){
    var remove = new List<Hitpoint>();
    foreach(Hitpoint hitpoint in hitting){
      if(hitpoint.capsule.bounds.Intersects(box.bounds)){ continue; }
      remove.Add(hitpoint);
    }
    foreach(Hitpoint hitpoint in remove){ hitting.Remove(hitpoint); }
  }

  float nextCheck;
  public float distance;
  Vector2 end;
  protected override Vector3 HitPosition(Hitpoint hitpoint){
    Vector3 target = hitpoint.transform.position;
    distance = (hitpoint.transform.position - transform.position).magnitude;
    return DistanceToEnd(distance);
  }

  float decay { get { return box.size.x / width; } }
  public Spawnable onHitEffect2;
  bool blocked;
  void DealDamage(){
    if(time > nextCheck){
      quota = penetration * decay;
      float delta = 1f / frequency;
      nextCheck = time + delta;
      var sortedHitting = hitting.OrderBy(hitpoint => (hitpoint.transform.position - transform.position).magnitude);
      int count = 0;
      Vector3 blockedPosition = Vector3.zero;
      foreach(Hitpoint hitpoint in sortedHitting){
        if(hitpoint.shielded){ continue; }
        if(count == 0 || quota >= hitpoint.penetrationCost){
          quota -= hitpoint.penetrationCost;
          Vector3 hitPosition = HitPosition(hitpoint);
          hitpoint.TakeDamage(damage * weaken * delta / duration, hitPosition);
          SpawnOnHitEffect(hitPosition, false);
          blockedPosition = hitPosition;
          count++;
        }
        if(quota < hitpoint.penetrationCost){
          center.pool.Spawn(onHitEffect2, blockedPosition, transform.rotation);
          blocked = true;
          return;
        }
      }
      blocked = false;
    }
  }

  LineRenderer beam { get { return GetComponentInChildren<LineRenderer>(); } }
  void RenderBeam(){
    end = DistanceToEnd(blocked? distance: 100f);
    float currectWidth = box.size.x;
    beam.widthCurve = AnimationCurve.Linear(0, currectWidth, 1, currectWidth);
    beam.SetPosition(0, new Vector3(transform.position.x, transform.position.y, 0.25f));
    beam.SetPosition(1, new Vector3(end.x, end.y, 0.25f));
  }

  Vector2 DistanceToEnd(float distance){
    return transform.position + transform.TransformDirection(Vector3.forward * distance);
  }

  protected override void AreaDamage(){}
  protected override void Die(){}

}
