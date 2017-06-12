using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSurround : MonoBehaviour {

	public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target);
		transform.Translate(3 * Vector3.left * Time.deltaTime);

	}
}
