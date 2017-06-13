using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelApproach : MonoBehaviour {


	public float maxY;
	private float initY;
	public float stayTime;
	public int speed;

	private Transform transform;
	private int moveState = 0; // 0 UP, 1 Stay, 2 Down

	private float timer;

	// Use this for initialization
	void Start () {
		this.transform = GetComponent<Transform>();
		initY = this.transform.position.y;
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if ( moveState == 0 ) {
			transform.Translate(0, speed * Time.deltaTime, 0);
			if ( transform.position.y >= maxY ) {
				moveState = 1;
			}
		} else if ( moveState == 1 ) {
			timer += Time.deltaTime;
			if ( timer >= stayTime ) {
				moveState = 2;
			}
		} else if ( moveState == 2 ) {
			transform.Translate(0, -1 * speed * Time.deltaTime, 0);
			if (transform.position.y <= initY) {
				moveState = 0;
				this.gameObject.SetActive (false);
				timer = 0;
			}
		}
	}

}
