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
	public Transform boomerangFolder;
	public GameObject player;
	public PlayerAnimationController anim;
	public BloodMgr bloodMgr;
	public ScoreUIMgr scoreMgr;
	public GameTimeUI gameTimeUI;

	public GameState gameState;
	public enum GameState {isPlaying,isGameOver};

	// Use this for initialization
	void Start () {
		anim = player.GetComponent<PlayerAnimationController> ();
		boomerangFolder = GameObject.Find ("boomerangFolder").transform;
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
		anim.setIsDead (true);
		bloodMgr.enabled = false;
		gameState = GameState.isGameOver;
		gameTimeUI.Stop ();
	}

	public void GameReset(){
		bloodImg.enabled = false;
		for (int k = 0; k < boomerangFolder.childCount; k++) {
			Destroy (boomerangFolder.GetChild (k).gameObject);
		}
		for(int k = 0; k < enermyGenFolder.childCount; k++){
			EnermyGenerator e = enermyGenFolder.GetChild (k).GetComponent<EnermyGenerator>();
			if (e != null) {
				for (int i = 0; i < e.transform.childCount; i++) {
					Destroy (e.transform.GetChild (i).gameObject);
				}
				e.enabled = false;
			}
		}
		for(int k = 0; k < enermyGenFolder.childCount; k++){
			EnermyGenerator e = enermyGenFolder.GetChild (k).GetComponent<EnermyGenerator>();
			if (e != null) {
				e.Reset ();
				e.enabled = true;
			}
		}
		player.GetComponent<PlayerMove> ().enabled = true;
		player.GetComponent<PlayerShoot> ().enabled = true;
		player.GetComponent<Player> ().enabled = true;
		anim.setIsDead (false);
		anim.setReset ();
		bloodMgr.enabled = true;
		bloodMgr.Reset ();
		scoreMgr.Reset ();
		gameState = GameState.isPlaying;
		gameTimeUI.Reset ();
		gameTimeUI.Play ();
	}
}
