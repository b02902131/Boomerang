using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationShoot : MonoBehaviour {

	private MouseClickShoot mouseShoot;

	void Start(){
		mouseShoot = GetComponentInParent<MouseClickShoot> ();
	}

	public void triggerShoot(){
		mouseShoot.shoot ();
	}
}
