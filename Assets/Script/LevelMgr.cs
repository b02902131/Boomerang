using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMgr : MonoBehaviour {

	private int level = 1; // level can be 1, 2, 3
	private GameObject levelOneUp;
	private GameObject levelTwoUp;

	private Transform enemyGenFolder;
	// Use this for initialization
	void Start () {	
		levelOneUp = GameObject.Find("levelOne");
		levelOneUp.gameObject.SetActive(false);
		levelTwoUp = GameObject.Find("levelTwo");
		levelTwoUp.gameObject.SetActive(false);
		enemyGenFolder = GameObject.Find ("EnemyGenFolder").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int getLevel() {
		return level;
	}

	public void levelUp() {
		Debug.Log("level up");
		switch (level) {
			case 1:
				level++;
				levelOneUp.gameObject.SetActive(true);
				break;
			case 2:
				level++;
				levelTwoUp.gameObject.SetActive(true);
				break;
			default:
				break;
		}

	}

	void UpdateEnemyGen(int L){
		for(int k = 0; k < enemyGenFolder.childCount; k++){
			EnermyGenerator e = enemyGenFolder.GetChild (k).GetComponent<EnermyGenerator>();
			if (e != null) {
				e.SetLevel (L);
			}
		}
	}

	public void Reset(){
		level = 1;
	}
}
