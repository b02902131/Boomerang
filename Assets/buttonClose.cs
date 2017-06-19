using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonClose : MonoBehaviour {

	public GameObject scoreboard;
	private webRequest wr;

	// Use this for initialization
	void Start () {
		wr = GetComponent<webRequest> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Close(){
		scoreboard.SetActive (false);
	}

	public void Open(){
		wr.GetScore ();
	}
}
