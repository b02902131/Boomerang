using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMilk : MonoBehaviour {

	public Enemy_cow enemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Milk(){
		enemy.GenMilk();
	}
}
