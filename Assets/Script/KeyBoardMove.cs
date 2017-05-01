using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardMove : MonoBehaviour {

	// Use this for initialization
	private Rigidbody myRigidBody;

	void Start () {
		myRigidBody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame

	public float Speed;

	void Update () {
		Debug.Log("Update");
		if ( Input.GetKey (KeyCode.W) ) {
			Debug.Log("W");
			myRigidBody.AddForce(new Vector3(0, 0, Speed));
		}	

		if ( Input.GetKey (KeyCode.S) ) {
			Debug.Log("S");
			myRigidBody.AddForce(new Vector3(0, 0, -Speed));
		}	

		if ( Input.GetKey (KeyCode.A) ) {
			Debug.Log("A");
			myRigidBody.AddForce(new Vector3(-Speed, 0, 0));
		}	

		if ( Input.GetKey (KeyCode.D) ) {
			Debug.Log("D");
			myRigidBody.AddForce(new Vector3(Speed, 0, 0));
		}	
	}
}
