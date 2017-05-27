using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BloodMgr : MonoBehaviour {

	private int bones;
	public int initial_bones;
	private int currentBones;
	public GameObject myCanvas;

	private Image[] bloods;

	public GameManager gameMgr;

	public Image BloodBlur;

	public void bloodGain(){
		if (currentBones < 7) {
			currentBones++;
		}
	}

	public void bloodLoss(){
		if (currentBones > 0) {
			currentBones--;
		}
	}

	void Start () {
		bones = initial_bones;
		bloods = myCanvas.GetComponentsInChildren<Image>();
		for ( int i = this.bones; i < 7; i++ ) {
			bloods[i].enabled = false;
		}
		currentBones = this.bones;
	}	

	Tweener tweenAnimation;
	public void PlayHitAnimation()
	{
		if (tweenAnimation != null)
			tweenAnimation.Kill ();

		BloodBlur.color = Color.white;
		tweenAnimation = DOTween.To (() => BloodBlur.color, (x) => BloodBlur.color = x, new Color (1, 1, 1, 0), 0.5f);
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

		if (bones <= 0) {
			gameMgr.GameOver ();
		}
	}

	public void Reset(){
		for ( int i = this.bones; i < 7; i++ ) {
			bloods[i].enabled = true;
		}
		bones = initial_bones;
		currentBones = bones;
		for ( int i = this.bones; i < 7; i++ ) {
			bloods[i].enabled = false;
		}
	}
}
