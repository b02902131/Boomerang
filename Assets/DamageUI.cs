using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUI : MonoBehaviour {

	private float RiseSpd = 5.0f;
	private float DecelerationSPd = 5.0f;
	private float timer;
	public float ExistTime = 2.0f;
	public AnimationCurve RiseSpdCurve;

	// Use this for initialization
	void Start () {
		timer = 0;
		RiseSpd = RiseSpdCurve.Evaluate (timer);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		Rise ();
		if (timer >= ExistTime) {
			Destroy (this.gameObject);
		}
	}

	void Rise(){
		this.transform.position += Vector3.up * Time.deltaTime * RiseSpd;
		RiseSpd = RiseSpdCurve.Evaluate (timer);
	}

	public void setScore(int score){
		this.GetComponent<TextMesh>().text = "+" + score.ToString ();
	}
}
