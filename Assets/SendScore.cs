using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SendScore : MonoBehaviour {

	private string url = "https://morning-thicket-62925.herokuapp.com/showrecord/insert/";

	public string name;
	public int score;

	public InputField nameInput;
	public Text ScoreText;

	public GameObject summitBtn; 
	public GameObject form;
	public Vector3 hidePos;
	public Vector3 showPos;
	public AnimationCurve formMoveCurve;

	// Use this for initialization
	void Start () {
		SetScore (-1);
		hidePos = form.transform.position;

//		initialize (9487);
		//for test
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyUp (KeyCode.Y)) {
//			initialize (945);
//		}
	}

	public void initialize(int newScore){
		name = "";
		nameInput.text = "";
		SetScore (newScore);
		form.SetActive (true);
		form.transform.position = hidePos;
		form.transform.DOMove (showPos, 0.5f, false).SetEase (formMoveCurve);
	}

	public void SetScore(int s){
		if(s!=-1) score = s;
		ScoreText.text = score.ToString ();
		
	}

	public void editName(){
		name = nameInput.text;
		if (name.Length == 0) {
			summitBtn.SetActive (false);
		} else if (name.Length >= 7) {
			nameInput.text = nameInput.text.Substring (0, 6);
			name = nameInput.text;
		}else {
			summitBtn.SetActive (true);
		}
	}

	public void submit(){
		if (name.Length == 0) {
			
		} else {
			string url_long = url + name + "/" + score.ToString ();

			StartCoroutine (WaitForRequest (url_long));
		}
	}

	IEnumerator WaitForRequest(string _url)
	{

		form.SetActive (false);
		WWW www = new WWW (_url);
		yield return www;

		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
			string s = www.text;
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    

	}

	public void Close(){
		form.SetActive (false);
		form.transform.position = hidePos;
	}
}
