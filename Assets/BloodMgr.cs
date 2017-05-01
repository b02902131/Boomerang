using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodMgr : MonoBehaviour {

	public int bones;
	private int currentBones;
	public GameObject myCanvas;

	private Image[] bloods;

	public void setBlood(int blood) {
		if ( blood >= 0 ) {
			this.currentBones = blood;
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
