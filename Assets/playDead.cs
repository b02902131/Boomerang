using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playDead : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Dead(){
		Destroy (this.gameObject);
	}
}
