﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MouseClickShoot : PlayerShoot {

	public bool isFinishShoot;

	public Transform rightHand;
	private Vector3 target = new Vector3();
	public BloodMgr bloodMgr;
	public ScoreUIMgr scoreUIMgr;
	public float fowardDistance = 1;
	int mask;

	void Start(){
		mask = LayerMask.GetMask ("Plane");
		bloodMgr = GameObject.Find ("BloodMgr").GetComponent<BloodMgr>();
		scoreUIMgr = GameObject.Find ("ScoreUI").GetComponent<ScoreUIMgr> ();
		isFinishShoot = false;	// set this to true everytime after shooting boomerang
		anim = GetComponentInChildren<animation_controller>();
	}

	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);////(1)
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 1000, mask)) {////(2)
			if (Input.GetMouseButtonDown(0) && hit.transform.gameObject.tag == "floor") {
				target = new Vector3 (hit.point.x, this.transform.position.y, hit.point.z);
				if (Vector3.Distance (this.transform.position, target) > 0.1f) {
					// face to target
					this.transform.LookAt (target);
					// play shoot animation
					shootAnimation();

				}

			}
		}
	}

	public void shoot(){
//		target = this.transform.position + this.transform.forward * 10;
		//			this.transform.LookAt (target);
		GameObject br = Instantiate (boomerang, rightHand.position + this.transform.forward*fowardDistance, Quaternion.identity);
		Follower follower = br.GetComponent<Follower> ();
		follower.GetRB ();
		follower.mouseClickMove = GetComponent<MouseClickMove> ();
		follower.wasdMove = GetComponent<WASDMove> ();
		follower.Flyout (target);
		follower.player = this.gameObject.transform;
		Bonerang bonerang = br.GetComponent<Bonerang> ();
		bonerang.scoreUIMgr = scoreUIMgr;
		bloodMgr.bloodLoss ();

		isFinishShoot = true;

	}

}