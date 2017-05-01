using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public BloodMgr mgr;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Hit(int damage){
		if (damage > 0) {
			mgr.bloodLoss (damage);
		}
	}
}
