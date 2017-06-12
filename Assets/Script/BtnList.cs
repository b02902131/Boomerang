using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnList : MonoBehaviour {

	public float heightInterval;
	public float width;
	public float height;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < transform.childCount; i++) {
			
			RectTransform r = transform.GetChild (i).GetComponent<RectTransform>();
			r.rect.Set(0, -(heightInterval * i + width * (i - 1)), width, height);
		}
	}
}
