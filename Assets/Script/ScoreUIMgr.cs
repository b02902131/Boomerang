using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIMgr : MonoBehaviour {

	public Text score_text;
	private int score;
	private int level;
	private LevelMgr levelMgr;
	public int levelTwoScore = 20;
	public int levelThreeScore = 100;

	// Use this for initialization
	void Start () {
		levelMgr = GameObject.Find("LevelMgr").GetComponent<LevelMgr>();
		level = levelMgr.getLevel();
		Debug.Log("Level");
		Debug.Log(level);
	}
	
	// Update is called once per frame
	void Update () {
		checkLevel();
		if (Input.GetKeyUp (KeyCode.P)) {
			AddScoreUI (10);
		}
	}

	private void checkLevel(){
		if ( score >= levelTwoScore && level == 1 ) {
			levelMgr.levelUp();
			level = levelMgr.getLevel();
		} 
		if ( score >= levelThreeScore && level == 2 ) {
			levelMgr.levelUp();
			level = levelMgr.getLevel();
		}
	}

	private void UpdateScoreUI(int score){
		score_text.text = score.ToString ();
	}

	public void AddScoreUI(int num){
		score += num;
		UpdateScoreUI(score);
	}

	public void Reset(){
		score = 0;
		score_text.text = score.ToString ("###0");
		level = 1;
	}

	public int GetScore(){
		return score;
	}
}
