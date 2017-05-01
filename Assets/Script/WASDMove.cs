using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMove : MonoBehaviour {

	public float speed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveDir = Vector3.zero;
		moveDir += new Vector3 (1, 0, 0) * Input.GetAxis ("Horizontal");
		moveDir += new Vector3 (0, 0, 1) * Input.GetAxis ("Vertical");
		moveDir.Normalize ();
		transform.LookAt (transform.position + moveDir);
		transform.Translate (moveDir * speed * Time.deltaTime, Space.World);
	}
}
