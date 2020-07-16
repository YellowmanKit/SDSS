using System.Collections;
using UnityEngine;

public abstract class Craft : Physical{

  protected Alien alien { get { return GetComponentInParent<Alien>(); } }

  protected void Tilt(){
    rb.rotation = Quaternion.Euler (transform.eulerAngles.x, 0f, rb.velocity.x * -0.5f);
  }

}
