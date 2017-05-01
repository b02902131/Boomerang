using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonerang : MonoBehaviour {

	public Follower follower;
	public ScoreUIMgr scoreUIMgr;

	private int hit_counter;

	// Use this for initialization
	void Start () {
		hit_counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag ("Enermy")) {
			if (follower.state != Follower.State.Drop) {
				hit_counter++;
				Enermy enemy = collision.gameObject.GetComponentInParent<Enermy> ();
				print ("bonerang hit: counter = " + hit_counter + ", multiplier = " + enemy.reward_mutiplier);
				scoreUIMgr.AddScoreUI (hit_counter * enemy.reward_mutiplier);
				enemy.Hit ();
			}
		}
	}
}
