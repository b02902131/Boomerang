﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMotion : MonoBehaviour {

	public Vector3 velocity;
	public Vector3 rotate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += velocity * Time.deltaTime;
		this.transform.Rotate (rotate);
	}
}
