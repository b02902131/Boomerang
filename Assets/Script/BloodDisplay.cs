using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDisplay : MonoBehaviour {
	public GameObject BloodCanvas;
	// Use this for initialization
	void Start () {
		BloodCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			BloodCanvas.SetActive(true);
		}
	}
}
