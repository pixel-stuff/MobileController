using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class MenuManager : MonoBehaviour {

	private int score = 0;

	public Text scoreText;
	public Button restartBtn;
	public Action restartClicked;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = string.Format ("{0} beaver killed", score);
	}

	public void IncrementScore() {
		score += 1;
	}

	public void Reset() {
		score = 0;
	}

	public void RestartBtnClicked() {
		Debug.Log ("!!! Restart Btn Clicked !!!!");
		if (restartClicked != null) {
			restartClicked ();
		}
	}
}
