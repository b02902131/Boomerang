using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyGenerator : MonoBehaviour {

	public Enemy enemy_prefab;
	private Transform enemy_folder;
	public Transform player;
//	public float interval_min;
//	public float interval_max;
	public float timer;
	private float total_time;
	public float RandRange;
	public float Speed;
	public int blood = 1;
	public drinkMilk milk_prefab;

	private List<GameObject> enemy_preparing = new List<GameObject>();

	private const int level_num = 3;
	private AnimationCurve interval;
	private bool flag;
	public AnimationCurve[] level_interval = new AnimationCurve[level_num];
	public bool[] level_flag = new bool[level_num];

	// Use this for initialization
	void Start () {
//		timer = Random.Range (interval_min, interval_max);
		total_time = 0;
		timer = interval.Evaluate (total_time);
		enemy_folder = GameObject.Find ("EnemyFolder").transform;
		Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		total_time += Time.deltaTime;

		if (flag) timer -= Time.deltaTime;
		if (timer < 0) {
//			timer = Random.Range (interval_min, interval_max);
			timer = interval.Evaluate (total_time);
			enermyGenerate ();
		}

		// scale enemy
		List<GameObject> enemy_remove_list = new List<GameObject>();
		foreach (GameObject enemy in enemy_preparing) {
			if (enemy != null) {
				Vector3 scale = enemy.transform.localScale;
				scale += Time.deltaTime * Vector3.one;
				enemy.transform.localScale = scale;
				if (scale.magnitude > Vector3.one.magnitude) {

					enemy.GetComponent<Enemy> ().enabled = true;
					enemy_remove_list.Add (enemy);
				}
			}
		}
		foreach (GameObject enemy in enemy_remove_list) {
			if (enemy_preparing.Contains (enemy)) {
				enemy_preparing.Remove (enemy);
			}
		}
		enemy_remove_list.Clear ();
	}

	void enermyGenerate(){
		Enemy enemy = Instantiate (enemy_prefab, this.transform.position + new Vector3(Random.Range(-RandRange,RandRange),0,Random.Range(-RandRange,RandRange)), Quaternion.Euler(0,Random.Range(0,360),0), this.transform);
		enemy.target = player;
		enemy.speed = Speed;
		enemy.blood = blood;
		enemy.milk_prefab = milk_prefab;
		enemy.enabled = false;
		GameObject g = enemy.gameObject;
		g.transform.localScale = 0.1f * Vector3.one;
		enemy_preparing.Add (g);
		enemy.transform.SetParent (enemy_folder);
	}

	public void Reset(){
		total_time = 0;
		interval = level_interval [0];
		flag = level_flag [0];
		timer = interval.Evaluate (total_time);
	}

	public void SetLevel(int level){
		total_time = 0;
		interval = level_interval [level - 1];	// level = 1,2,3,  while index = 0,1,2
		flag = level_flag[level-1];
		timer = interval.Evaluate (total_time);
	}
}
