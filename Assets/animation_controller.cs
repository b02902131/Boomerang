using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_controller : MonoBehaviour {

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
}
