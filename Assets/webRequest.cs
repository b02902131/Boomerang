using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webRequest : MonoBehaviour {

	private string url = "https://morning-thicket-62925.herokuapp.com/showrecord/unityparse/";
	private string domain = "https://morning-thicket-62925.herokuapp.com/";
	public GameObject scoreboard;
	private  highScoreText hst;

	public class MyClass
	{
		public string naem;
		public int score;
	}

	// Use this for initialization
	void Start () {
		hst = GetComponent<highScoreText> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetScore(){
		StartCoroutine(WaitForRequest(url));
	}

	void UpdateScoreBoard(){
		scoreboard.SetActive (true);
	}

	IEnumerator WaitForRequest(string _url)
	{
		WWW www = new WWW(_url);
		yield return www;

		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
			string s = www.text;
			hst.UpdateText (s);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    

		UpdateScoreBoard ();
	}



}
