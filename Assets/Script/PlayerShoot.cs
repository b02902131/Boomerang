using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot:MonoBehaviour {
	public GameObject boomerang;

	public Animation_Controller anim;

	public void shootAnimation(){
		anim.setShoot ();
	}
}


