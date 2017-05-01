using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Follower : MonoBehaviour {

	public Transform player;
	private Rigidbody rb;
	private float timer;
	public float returnTime;
	public float speed;
	public float accerate;
	public AnimationCurve flySpdCurve;
	public AnimationCurve flyBackCurve;

	public  int state; //0: out , 1 : slow down, 2 : return accer, 3 : return
	private Vector3 targetVelocity;
	public MouseClickMove mouseClickMove;
	public float maxDistance ;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody> ();
		state = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > returnTime && state == 0) {
			state = 1;
		}
		if (state == 1) {
//			rb.velocity -= Time.deltaTime * accerate * rb.velocity.normalized;
//			if (rb.velocity.sqrMagnitude < 0.1f) {
//				state = 2;
//				Rigidbody prb = player.GetComponent<Rigidbody> ();
//				Vector3 target = mouseClickMove.target;
//				targetVelocity = (target - transform.position).normalized * speed;
//			}
		}
		if (state == 2) {
//			if (rb.velocity.sqrMagnitude < targetVelocity.sqrMagnitude) {
//				rb.velocity += Time.deltaTime * accerate * rb.velocity;
//			} else {
//				rb.velocity = targetVelocity;	
//			}
		}
	}

	void OnCollisionEnter(Collision collision){
		print ("collision : " + collision.gameObject.tag);
		if (collision.gameObject.CompareTag ("Player")) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			Destroy (this.gameObject);
		}
	}

	public void Flyout(Vector3 target){
		Vector3 d = target - this.transform.position;
		if (d.magnitude > maxDistance) {
			target = this.transform.position + d.normalized * maxDistance;
		}
		this.transform.DOMove (target, returnTime, false).SetEase (flySpdCurve).OnComplete(FlyBack);
	}
	public void FlyBack(){
		Vector3 target = mouseClickMove.target;
		Vector3 d = target - transform.position;
		if (d.magnitude > maxDistance) {
			target = transform.position + d.normalized * maxDistance;
		}
		this.transform.DOMove (target, returnTime, false).SetEase (flyBackCurve).OnComplete(Drop);
	}
	void Drop(){
		this.GetComponent<Rotator> ().enabled = false;
		rb.useGravity = true;
		rb.isKinematic = false;
	}
			
}
