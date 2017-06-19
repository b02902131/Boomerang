using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class highScoreText : MonoBehaviour {

	public GameObject[] score_groups;
	public List<Text> names = new List<Text>();
	public List<Text> scores = new List<Text>();

	// Use this for initialization
	void Start () {
		foreach (GameObject g in score_groups) {
			names.Add(g.transform.Find ("Text").GetComponent<Text>());
			scores.Add(g.transform.Find("Text (1)").GetComponent<Text>());
		}
		for (int i = 0; i < names.Count; i++) {
//			names [i].text = i.ToString ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateText(string str){
		string[] split = str.Split (',');
		for (int i = 0; i < 10; i++) {
			scores [i].text = split [i + 10];
			names [i].text = split [i];
		}
	}
}
