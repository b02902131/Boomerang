using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour {

	public Image bloodImg;
	public Camera GameCamera;
	public float CameraShakeDuration;
	public float CameraShakeStrenth;

	private Transform enemyGenFolder;
	private Transform enemyFolder;
	private Transform boomerangFolder;
	private Vector3 player_pos;
	public GameObject player;
	public PlayerAnimationController anim;
	public BloodMgr bloodMgr;
	public ScoreUIMgr scoreMgr;
	public LevelMgr levelMgr;
	public GameTimeUI gameTimeUI;

	public GameState gameState;
	public enum GameState {isPlaying,isGameOver};
	public GameObject ResetUI;
	public SendScore sendScore;

	// Use this for initialization
	void Start () {
		player_pos = player.transform.position;
		anim = player.GetComponent<PlayerAnimationController> ();
		boomerangFolder = GameObject.Find ("boomerangFolder").transform;
		enemyFolder = GameObject.Find ("EnemyFolder").transform;
		enemyGenFolder = GameObject.Find ("EnemyGenFolder").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
//		if (gameState == GameState.isGameOver) {
//			if (Input.GetKeyDown (KeyCode.R)) {
//				GameReset ();
//			}
//		}
	}

	public void GameOver(){
		ResetUI.SetActive (true);
		bloodImg.enabled = true;
		GameCamera.transform.DOShakePosition (CameraShakeDuration, CameraShakeStrenth);

		player.GetComponent<PlayerShoot> ().enabled = false;
		player.GetComponent<PlayerMove> ().enabled = false;
		player.GetComponent<Player> ().enabled = false;
		anim.setIsDead (true);
		bloodMgr.enabled = false;
		gameState = GameState.isGameOver;
		gameTimeUI.Stop ();

		for(int k = 0; k < enemyGenFolder.childCount; k++){
			EnermyGenerator e = enemyGenFolder.GetChild (k).GetComponent<EnermyGenerator>();
			if (e != null) {
				e.enabled = false;
			}
		}

		sendScore.initialize (scoreMgr.GetScore ());
		scoreMgr.Stop ();
	}

	public void GameReset(){
		ResetUI.SetActive (false);
		player.transform.position = player_pos;
		bloodImg.enabled = false;
		for (int k = 0; k < boomerangFolder.childCount; k++) {
			Destroy (boomerangFolder.GetChild (k).gameObject);
		}
		for(int k = 0; k < enemyFolder.childCount; k++){
			Destroy (enemyFolder.GetChild (k).gameObject);
		}
		for(int k = 0; k < enemyGenFolder.childCount; k++){
			EnermyGenerator e = enemyGenFolder.GetChild (k).GetComponent<EnermyGenerator>();
			if (e != null) {
				e.Reset ();
				e.enabled = true;
			}
		}
		player.GetComponent<PlayerMove> ().enabled = true;
		player.GetComponent<PlayerShoot> ().enabled = true;
		player.GetComponent<PlayerShoot> ().Reset();
		player.GetComponent<Player> ().enabled = true;
		anim.setIsDead (false);
		anim.setReset ();
		bloodMgr.enabled = true;
		bloodMgr.Reset ();
		scoreMgr.Reset ();
		levelMgr.Reset ();
		gameState = GameState.isPlaying;
		gameTimeUI.Reset ();
		gameTimeUI.Play ();
	}
}
