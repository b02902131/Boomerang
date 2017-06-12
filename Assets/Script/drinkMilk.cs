using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drinkMilk : MonoBehaviour {

	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag ("Player")) {
			collision.gameObject.GetComponent<Player> ().mgr.bloodGain();
			Destroy(this.gameObject);
			// maybe add attack animation
		}
	}
}
