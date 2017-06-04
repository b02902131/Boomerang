using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyGenerator : MonoBehaviour {

	public Enemy enemy_prefab;
	public Transform player;
	public float interval_min;
	public float interval_max;
	public float timer;
	private float total_time;
	public float RandRange;
	public float Speed;
	public int blood = 1;
	public drinkMilk milk_prefab;

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
		Enemy enemy = Instantiate (enemy_prefab, this.transform.position + new Vector3(Random.Range(-RandRange,RandRange),0,Random.Range(-RandRange,RandRange)), Quaternion.identity, this.transform);
		enemy.target = player;
		enemy.speed = Speed;
		enemy.blood = blood;
		enemy.milk_prefab = milk_prefab;
	}

	public void Reset(){
		total_time = 0;
		timer = interval.Evaluate (total_time);
	}


}
