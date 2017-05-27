using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour {

	public enum EnermyType{chase, archer};

	public float speed = 1;
	public Transform target;
	public EnermyType type = EnermyType.chase;

	public int damage = 1;

	public int reward_mutiplier = 1;
	public int blood = 1;
	public Rigidbody rigidbody;

	// Use this for initialization
	public virtual void Start () {
		
	}
	
	// Update is called once per frame
	public virtual void Update () {

		if(type == EnermyType.chase){
			float step = speed * Time.deltaTime;
			this.transform.LookAt (target);
			this.transform.Translate ((target.position - this.transform.position).normalized * step, Space.World);
		}
	}

	public void Hit(int count){
		print ("enemy hit by bonerang");
		blood -= count;
		if(blood<=0)
			Destroy (this.gameObject);
	}


	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag ("Player")) {
			Player player = collision.gameObject.GetComponent<Player> ();
			player.Hit (damage);
			print ("enemy hit player");
			// maybe add attack animation
		}
	}
}
