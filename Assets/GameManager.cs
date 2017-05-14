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

	public Transform enermyGenFolder;
	public GameObject player;
	public BloodMgr bloodMgr;
	public ScoreUIMgr scoreMgr;

	public GameState gameState;
	public enum GameState {isPlaying,isGameOver};

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (gameState == GameState.isGameOver) {
			if (Input.GetKeyDown (KeyCode.R)) {
				GameReset ();
			}
		}
	}

	public void GameOver(){
		bloodImg.enabled = true;
		GameCamera.transform.DOShakePosition (CameraShakeDuration, CameraShakeStrenth);

		player.GetComponent<PlayerShoot> ().enabled = false;
		player.GetComponent<PlayerMove> ().enabled = false;
		player.GetComponent<Player> ().enabled = false;
		bloodMgr.enabled = false;
		gameState = GameState.isGameOver;
	}

	public void GameReset(){
		bloodImg.enabled = false;
		for(int k = 0; k < enermyGenFolder.childCount; k++){
			EnermyGenerator e = enermyGenFolder.GetChild (k).GetComponent<EnermyGenerator>();
			for (int i = 0; i < e.transform.childCount; i++) {
				Destroy (e.transform.GetChild (i).gameObject);
			}
			e.enabled = false;
		}
		for(int k = 0; k < enermyGenFolder.childCount; k++){
			EnermyGenerator e = enermyGenFolder.GetChild (k).GetComponent<EnermyGenerator>();
			e.Reset ();
			e.enabled = true;
		}
		player.GetComponent<PlayerMove> ().enabled = true;
		player.GetComponent<PlayerShoot> ().enabled = true;
		player.GetComponent<Player> ().enabled = true;
		bloodMgr.enabled = true;
		bloodMgr.Reset ();
		scoreMgr.Reset ();
		gameState = GameState.isPlaying;
	}
}
