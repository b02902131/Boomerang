using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour {

	public enum EnermyType{chase, archer};

	public float speed;
	public Transform target;
	public EnermyType type = EnermyType.chase;

	public int reward_mutiplier = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(type == EnermyType.chase){
			float step = speed * Time.deltaTime;
			this.transform.LookAt (target);
			this.transform.Translate ((target.position - this.transform.position).normalized * step, Space.World);
		}
	}

	public void Hit(){
		Destroy (this.gameObject);
	}
}
