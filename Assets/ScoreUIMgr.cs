using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIMgr : MonoBehaviour {

	public Text score_text;
	private int score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void UpdateScoreUI(int score){
		score_text.text = score.ToString ();
	}

	public void AddScoreUI(int num){
		score += num;
		UpdateScoreUI(score);
	}
}
