using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyGenerator : MonoBehaviour {

	public Enermy enemy_prefab;
	public Transform player;
	public float interval_min;
	public float interval_max;
	private float timer;

	// Use this for initialization
	void Start () {
		timer = Random.Range (interval_min, interval_max);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			timer = Random.Range (interval_min, interval_max);
			enermyGenerate ();
		}
	}

	void enermyGenerate(){
		Enermy enermy = Instantiate (enemy_prefab, this.transform.position, Quaternion.identity);
		enermy.target = player;
	}
}
