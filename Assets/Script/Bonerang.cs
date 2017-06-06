using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonerang : MonoBehaviour {

	public Follower follower;
	public ScoreUIMgr scoreUIMgr;

	private int hit_counter;
	public  GameObject last_hit_obj = null;

	// Use this for initialization
	void Start () {
		hit_counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FlyBack(){
		last_hit_obj = null;
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag ("Enermy")) {
			if (follower.state != Follower.State.Drop) {
				if (last_hit_obj == null || last_hit_obj != collision.gameObject) {
					last_hit_obj = collision.gameObject;
					hit_counter++;
					Enemy enemy = collision.gameObject.GetComponentInParent<Enemy> ();
					print (this.gameObject.name + " bonerang hit: counter = " + hit_counter + ", multiplier = " + enemy.reward_mutiplier+", isFlyBack = "+(follower.state == Follower.State.flyBack));
					int addScore = hit_counter * enemy.reward_mutiplier;
					if (follower.state == Follower.State.flyBack) {
						addScore += 1;
					}
					scoreUIMgr.AddScoreUI (addScore);
					enemy.Hit (hit_counter);
				
				}
			}
		}
		else if (collision.gameObject.CompareTag ("Player")) {
			if (last_hit_obj == null || last_hit_obj != collision.gameObject) {
				if (follower.state == Follower.State.flyBack || follower.state == Follower.State.Drop) {
					last_hit_obj = collision.gameObject;
					collision.gameObject.GetComponent<Player> ().CatchBoomerang ();
					Destroy (this.gameObject);
				}
			}
		}
	}
}
