using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HitByEnimies : MonoBehaviour {

	public Camera GameCamera;
	public float CameraShakeDuration;
	public float CameraShakeStrenth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameCamera.transform.DOShakePosition (CameraShakeDuration, CameraShakeStrenth);
		}

	}
}
