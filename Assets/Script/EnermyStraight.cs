using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyStraight : Enemy {

	private Vector3 dir;
	private float straightRange = 10;
	public float sqrdistance;

	// Use this for initialization
	public override void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		updateDirection ();
	}

	private void updateDirection(){
		dir = target.position - this.transform.position;
		dir.y = 0;
	}
	
	// Update is called once per frame
	public override void Update () {
		rigidbody.velocity = this.transform.forward.normalized * speed;

		Vector3 target_pos = this.gameObject.transform.position + dir;
		target_pos.y = this.transform.position.y;

		Quaternion neededRotation = Quaternion.LookRotation(target_pos - transform.position);
		Quaternion interpolatedRotation = Quaternion.Slerp(transform.rotation, neededRotation, Time.deltaTime * rotateSpd);

		this.transform.rotation = interpolatedRotation;

		sqrdistance = (this.transform.position - target.transform.position).sqrMagnitude;
		if (sqrdistance > straightRange * straightRange) {
			updateDirection ();
		}
	}
}
