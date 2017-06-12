using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToCam : MonoBehaviour {

	private GameObject Camera;

	// Use this for initialization
	void Start () {
		Camera = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 lookat_pos = Camera.transform.forward+this.transform.position;
		this.transform.LookAt (lookat_pos);
	}
}
