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
	private animation_controller anim_controller;
	// Use this for initialization
	void Start () {
		mRigidBody = GetComponent<Rigidbody> ();
		anim_controller = GetComponent<animation_controller> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 moveDir = Vector3.zero;
		moveDir += new Vector3 (1, 0, 0) * my_signFunc( Input.GetAxis ("Horizontal") );
		moveDir += new Vector3 (0, 0, 1) * my_signFunc( Input.GetAxis ("Vertical") );
		moveDir.Normalize ();


		if (moveDir != Vector3.zero) {
			anim_controller.setIsRunning (true);
			transform.LookAt (transform.position + moveDir);
		} else {
			anim_controller.setIsRunning (false);
		}

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
