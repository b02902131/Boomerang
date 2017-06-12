using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public BloodMgr mgr;
	private float injuredInterval = 0.5f;
	private float injureTimer;
	public AudioSource heal;
	public AudioSource kick;
	// Use this for initialization
	void Start () {
		injureTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(injureTimer>0) injureTimer -= Time.deltaTime;
	}

	public void Hit(int damage){
		if (damage > 0) {
			if (injureTimer <= 0) {
				kick.Play ();
				mgr.bloodLoss ();
				mgr.PlayHitAnimation ();
				injureTimer = injuredInterval;
			}
		}
	}

	public void CatchBoomerang(){
		print ("catch");
		mgr.bloodGain ();
		//maybe play catch animation
	}
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag ("Milk")) {
			heal.Play ();
		}
	} 
}
