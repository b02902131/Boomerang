using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highScoreArragement : MonoBehaviour {

	public float y_interval = 120;

	// Use this for initialization
	void Start () {
		modifyPos();
	}
	
	// Update is called once per frame
	void Update () {
		modifyPos ();
	}

	void modifyPos(){
		for (int i = 0; i < this.transform.childCount; i++) {
			Vector3 pos = this.transform.position;
			pos.y -= y_interval * i;
			this.transform.GetChild (i).position = pos;
		}
	}
}
