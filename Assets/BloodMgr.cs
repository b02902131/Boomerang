using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodMgr : MonoBehaviour {

	public int bones;
	private int currentBones;
	public GameObject myCanvas;

	private Image[] bloods;

	public void bloodGain(int damage){
		if (damage > 0) {
			if (currentBones < 7) {
				currentBones++;
			}
		} else {
			Debug.Log ("ben yeh sai, who call this is too over");
		}
	}

	public void bloodLoss(int damage){
		if (damage > 0) {
			if (currentBones > 0) {
				currentBones--;
			}
		} else {
			Debug.Log ("ben yeh sai, who call this is too over");
		}
	}

	void Start () {
		bloods = myCanvas.GetComponentsInChildren<Image>();
		for ( int i = this.bones; i < 7; i++ ) {
			bloods[i].enabled = false;
		}
		currentBones = this.bones;
	}	
	
	// Update is called once per frame
	void Update () {
		if ( currentBones > bones ) {
			for ( int i = bones; i < currentBones; i++ ) {
				bloods[i].enabled = true;
			}
		} else if ( currentBones < bones ) {
			for ( int i = currentBones; i < bones; i++ ) {
				bloods[i].enabled = false;
			}
		}

		bones = currentBones;
	}
}
