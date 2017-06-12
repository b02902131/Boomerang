using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackground : MonoBehaviour {

	private Transform transform;
	public int threshold;
	public int initialY;
	public float speed;
	// Use this for initialization
	void Start () {
		this.transform = GetComponent<Transform>();
		transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, speed * Time.deltaTime, 0);
		if ( transform.position.y >= threshold ) {
			transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
		}
	}
}
