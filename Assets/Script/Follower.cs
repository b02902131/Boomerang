using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Follower : MonoBehaviour {

	public Transform player;
	public  Rigidbody rb;

	public float returnTime;
	public float speed;
	public float accerate;
	public AnimationCurve flySpdCurve;
	public AnimationCurve flyBackCurve;

	public State state; //0: start , 1 : fly out , 2 : fly back, 3 : drop
	public enum State {Start, flyOut, flyBack, Drop}

	private Vector3 targetVelocity;
	public MouseClickMove mouseClickMove;
	public WASDMove wasdMove;
	public float maxDistance ;
	public float returnDistance;
	private Bonerang bonerang;

	// Use this for initialization
	void Start () {
		state = State.Start;
		bonerang = this.GetComponent<Bonerang> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void GetRB(){
		rb = GetComponent<Rigidbody> ();
	}

	public void Flyout(Vector3 target){
		state = State.flyOut;
		target.y = this.transform.position.y;
		Vector3 d = target - this.transform.position;
		if (d.magnitude > maxDistance) {
			target = this.transform.position + d.normalized * maxDistance;
		}
		print ("follwer46, target = " + target);
		this.transform.DOMove (target, returnTime, false).SetEase (flySpdCurve).OnComplete(FlyBack);
	}
	public void FlyBack(){
		state = State.flyBack;
//		Vector3 target = mouseClickMove.target;
		Vector3 target = player.position + player.GetComponent<Rigidbody>().velocity * 0.5f;
		target.y = this.transform.position.y;
		Vector3 d = target - transform.position;
		if (d.magnitude > returnDistance) {
			target = transform.position + d.normalized * returnDistance;
		}
		this.transform.DOMove (target, returnTime, false).SetEase (flyBackCurve).OnComplete(Drop);
		bonerang.FlyBack ();
	}
	void Drop(){
		state = State.Drop;
		this.GetComponent<Rotator> ().enabled = false;
		rb.useGravity = true;
		rb.isKinematic = false;
	}
			
}
