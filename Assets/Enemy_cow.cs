using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_cow : Enemy {

	private Vector3 dir;
	public  float timer;
	public float milk_interval = 10;
	public float random_interval = 5;
	public Transform milkGenTransform;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		ResetTime ();
	}

	private void updateDirection(){
		dir = -target.position+this.transform.position/2;
		dir.y = 0;
	}
	
	// Update is called once per frame
	public override void Update () {
		if (!isDead) {
			rigidbody.velocity = this.transform.forward * speed;

			Vector3 target_pos = this.gameObject.transform.position + dir;
			target_pos.y = this.transform.position.y;

			Quaternion neededRotation = Quaternion.LookRotation (target_pos - transform.position);
			Quaternion interpolatedRotation = Quaternion.Slerp (transform.rotation, neededRotation, Time.deltaTime * rotateSpd);

			//			this.transform.LookAt (target_pos);
			this.transform.rotation = interpolatedRotation;

			updateDirection ();

			timer -= Time.deltaTime;
			if (timer <= 0) {
				ResetTime ();
				animator.SetTrigger ("milk");
			}
		}
	}

	void ResetTime(){
		timer = milk_interval + Random.Range (0, random_interval);
	}

	public override void AfterHit(){
		GenMilk ();
	}

	public override void AfterDead(){
		GenMilk ();
	}

	public void GenMilk(){
		Vector3 milkPos = milkGenTransform.position;
		milkPos.y = 0;
		drinkMilk milk = Instantiate (milk_prefab, milkPos, Quaternion.Euler (new Vector3 (0, Random.Range (0, 360), 0)));
		milk.transform.SetParent (this.transform.parent);
	}
}
