using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public enum EnemyType{chase, archer};

	public float speed = 1;
	public Transform target;
	public EnemyType type = EnemyType.chase;

	public int damage = 1;

	public int reward_mutiplier = 1;
	public int blood = 1;
	public Rigidbody rigidbody;

	public float secondsBeforeDead;
	private ParticleSystem fireEffect;
	private bool onFire = false;
	public drinkMilk milk_prefab;

	// Use this for initialization
	public virtual void Start () {
		
	}
	
	// Update is called once per frame
	public virtual void Update () {

		if(type == EnemyType.chase){
			float step = speed * Time.deltaTime;
			Vector3 target_pos = target.position;
			target_pos.y = this.transform.position.y;
			this.transform.LookAt (target_pos);
			this.transform.Translate ((target.position - this.transform.position).normalized * step, Space.World);
		}
	}

	public virtual void Hit(int count){
		print ("enemy hit by bonerang");
		blood -= count;
		if ( blood <= 0 ) {
			if ( Random.Range(0, 7) < 1 ) {
				Vector3 milkPos = this.transform.position;
				milkPos.y = 0;
				drinkMilk milk = Instantiate (milk_prefab, milkPos, Quaternion.identity, this.transform);	
				milk.transform.SetParent (this.transform.parent);
			}
			Destroy (this.gameObject);
		}
	}


	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag ("Player")) {
			Player player = collision.gameObject.GetComponent<Player> ();
			player.Hit (damage);
			print ("enemy hit player");
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
		print ("enemy hit by bonerang");
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
