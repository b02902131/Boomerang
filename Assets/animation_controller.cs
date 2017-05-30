using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Controller : MonoBehaviour {

	public Animator animator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setIsRunning(bool b){
		animator.SetBool ("isRunning", b);
	}

	public void setShoot(){
		animator.SetTrigger ("shoot");
	}

	public void setReset(){
		animator.SetTrigger ("reset");
	}

	public void setIsDead(bool b){
		animator.SetBool ("isDead", b);
	}
}
