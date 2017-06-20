using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public enum EnemyType{chase, archer};

	public float speed = 1;
	public float rotateSpd = 1;
	public Transform target;
	public EnemyType type = EnemyType.chase;

	public int damage = 1;

	public int reward_mutiplier = 1;
	public int blood = 1;
	public Rigidbody rigidbody;

	public float secondsBeforeDead;
	private ParticleSystem fireEffect;
	private bool onFire = false;
	public bool isDead = false;
	public drinkMilk milk_prefab;

	public Animator animator;

	// Use this for initialization
	public virtual void Start () {
//		animator = gameObject.GetComponentInChildren<Animator> ();
		
	}
	
	// Update is called once per frame
	public virtual void Update () {

		if(type == EnemyType.chase){
			float step = speed * Time.deltaTime;
			Vector3 target_pos = target.position;
			Vector3 lookat = this.transform.position + this.transform.forward;
			target_pos = (lookat+target_pos)/2;
			target_pos.y = this.transform.position.y;

			Quaternion neededRotation = Quaternion.LookRotation(target_pos - transform.position);
			Quaternion interpolatedRotation = Quaternion.Slerp(transform.rotation, neededRotation, Time.deltaTime * rotateSpd);

//			this.transform.LookAt (target_pos);
			this.transform.rotation = interpolatedRotation;

			this.transform.Translate ((this.transform.forward).normalized * step, Space.World);
		}
	}

	public void Hit(int count){
		if (!isDead) {
			blood -= count;
			animator.SetTrigger ("hit");
			if (blood <= 0) {
				Dead ();
			} else {
				AfterHit ();
			}
		}
	}

	public virtual void AfterHit(){

	}

	public void Dead(){
		isDead = true;
		animator.SetTrigger ("Dead");
		this.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY;
		BoxCollider[] boxes = GetComponentsInChildren<BoxCollider> ();
		foreach (BoxCollider box in boxes) {
			box.enabled = false;
		}
		this.GetComponent<Enemy> ().enabled = false;
		Rigidbody rb = this.GetComponent<Rigidbody> ();
		rb.velocity = Vector3.zero;
		rb.useGravity = false;

		AfterDead ();
	}

	public virtual void AfterDead(){
		
	}





	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag ("Player")) {
			Player player = collision.gameObject.GetComponent<Player> ();
			player.Hit (damage);
//			print ("enemy hit player");
			// maybe add attack animation
		}

		if (collision.gameObject.CompareTag ("Enermy")) {
			if ( this.onFire ) {
				EnemyWithFire enemy = collision.gameObject.GetComponentInParent<EnemyWithFire> ();
				enemy.Burned ();
			}
		}
	}

	//fire===
	public void Burned(){
//		print ("enemy hit by bonerang");
		fireEffect = this.transform.Find ("Fire effect").GetComponent<ParticleSystem>();

		onFire = true;
		fireEffect.gameObject.SetActive(true);
		StartCoroutine(beforeDead());
	}

	IEnumerator beforeDead(){
		speed = 0;
		yield return new WaitForSeconds(secondsBeforeDead);
		Destroy (this.gameObject);
	}
	//fire===
}
