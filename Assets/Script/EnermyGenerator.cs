using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyGenerator : MonoBehaviour {

	public Enermy enemy_prefab;
	public Transform player;
	public float interval_min;
	public float interval_max;
	public float timer;
	private float total_time;

	public AnimationCurve interval;

	// Use this for initialization
	void Start () {
//		timer = Random.Range (interval_min, interval_max);
		total_time = 0;
		timer = interval.Evaluate (total_time);
	}
	
	// Update is called once per frame
	void Update () {
		total_time += Time.deltaTime;

		timer -= Time.deltaTime;
		if (timer < 0) {
//			timer = Random.Range (interval_min, interval_max);
			timer = interval.Evaluate (total_time);
			enermyGenerate ();
		}
	}

	void enermyGenerate(){
		Enermy enermy = Instantiate (enemy_prefab, this.transform.position, Quaternion.identity, this.transform);
		enermy.target = player;
	}

	public void Reset(){
		total_time = 0;
		timer = interval.Evaluate (total_time);
	}


}
