using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMove : PlayerMove {

	public float speed = 10;
	public float maxDashTime;
	public float dashSpeed;
	public float dashStoppingSpeed;
	private Rigidbody mRigidBody;
	private float currentDashTime;
	// Use this for initialization
	void Start () {
		mRigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 moveDir = Vector3.zero;
		moveDir += new Vector3 (1, 0, 0) * my_signFunc( Input.GetAxis ("Horizontal") );
		moveDir += new Vector3 (0, 0, 1) * my_signFunc( Input.GetAxis ("Vertical") );
		moveDir.Normalize ();
		transform.LookAt (transform.position + moveDir);

		if ( Input.GetKeyDown(KeyCode.Space) ) {
			currentDashTime = 0.0f;
		}
		if (currentDashTime < maxDashTime) {
			currentDashTime += dashStoppingSpeed;
			mRigidBody.velocity = moveDir * dashSpeed;
		} else {
			//transform.Translate (moveDir * speed * Time.deltaTime, Space.World);
			mRigidBody.velocity = moveDir * speed;
		}
	}

	float my_signFunc(float n){
		if (n == 0)
			return 0f;
		else if (n > 0)
			return 1f;
		else
			return -1f;
	}
}
