using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_cow : Enemy {

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}

//	private void updateDirection(){
//		this.transform.LookAt (target);
//		dir = target.position - this.transform.position;
//		dir.y = 0;
//	}
//	
//	// Update is called once per frame
//	public override void Update () {
//		rigidbody.velocity = dir.normalized * speed;
//
//		Vector3 target_pos = this.gameObject.transform.position + dir;
//		target_pos.y = this.transform.position.y;
//
//		Quaternion neededRotation = Quaternion.LookRotation(target_pos - transform.position);
//		Quaternion interpolatedRotation = Quaternion.Slerp(transform.rotation, neededRotation, Time.deltaTime * rotateSpd);
//
//		//			this.transform.LookAt (target_pos);
//		this.transform.rotation = interpolatedRotation;
//
//		sqrdistance = (this.transform.position - target.transform.position).sqrMagnitude;
//		if (sqrdistance > straightRange * straightRange) {
//			updateDirection ();
//		}
//	}
}
