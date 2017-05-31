using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot:MonoBehaviour {
	public GameObject boomerang;

	public PlayerAnimationController anim;

	public void shootAnimation(){
		anim.setShoot ();
	}
}


