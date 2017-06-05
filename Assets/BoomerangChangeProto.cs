using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangChangeProto : MonoBehaviour {

	MouseClickShoot mouseClickShoot;
	public GameObject boomerangNormal;
	public GameObject boomerangUltimate;
	public ScoreUIMgr scoreUIMgr;
	private int pre_score, cur_score;
	public int RewardScoreInterval;

	private ParticleSystem explode;
	// Use this for initialization
	void Start () {
		explode = GetComponentInChildren<ParticleSystem> ();
		//explode.Stop();
		mouseClickShoot = GetComponent<PlayerShoot> () as MouseClickShoot;
		cur_score = scoreUIMgr.GetScore ();
		pre_score = cur_score;
	}
	
	// Update is called once per frame
	void Update () {
		if (mouseClickShoot.isFinishShoot == true) {
			mouseClickShoot.boomerang = boomerangNormal;
			print ("reset boomerang");
		}

		cur_score = scoreUIMgr.GetScore ();
		if (cur_score / RewardScoreInterval - pre_score / RewardScoreInterval >= 1) {
			print ("cur_score= "+ cur_score+" pre_score= "+pre_score +"cur_score % 10 - pre_score % 10 = " +(cur_score % 10 - pre_score % 10));
			explode.Play();
			mouseClickShoot.boomerang = boomerangUltimate;
			mouseClickShoot.isFinishShoot = false;

		}
		pre_score = cur_score;

	}
}
