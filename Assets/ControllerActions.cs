using UnityEngine;
using System.Collections;
using System;

public class ControllerActions : MonoBehaviour {
	#region Singleton
	public static ControllerActions m_instance;
	void Awake(){
		if(m_instance == null){
			//If I am the first instance, make me the Singleton
			m_instance = this;
			DontDestroyOnLoad(this.gameObject);
		}else{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != m_instance)
				Destroy(this.gameObject);
		}
	}
	#endregion Singleton

	#region Actions //Subscrib here to get action
	public Action UpTriggerEnter;
	public Action UpTriggerExit;
	public Action DownTriggerEnter;
	public Action DownTriggerExit;
	public Action RightTriggerEnter;
	public Action RightTriggerExit;
	public Action LeftTriggerEnter;
	public Action LeftTriggerExit;

	public Action ATriggerExit;
	public Action ATriggerEnter;
	public Action BTriggerExit;
	public Action BTriggerEnter;
	public Action XTriggerExit;
	public Action XTriggerEnter;
	public Action ATriggerUp;
	public Action ATriggerDown;
	public Action BTriggerUp;
	public Action BTriggerDown;
	public Action XTriggerUp;
	public Action XTriggerDown;

	#endregion Actions

	#region Controller
	public void UpTrigger(bool isTriggerEnter){
		if (isTriggerEnter) {
			if (UpTriggerEnter != null) {
				UpTriggerEnter ();
			}
		} else {
			if (UpTriggerExit != null) {
				UpTriggerExit ();
			}
		}
	}

	public void RightTrigger(bool isTriggerEnter){
		if (isTriggerEnter) {
			if (RightTriggerEnter != null) {
				RightTriggerEnter ();
			}
		} else {
			if (RightTriggerExit != null) {
				RightTriggerExit ();
			}
		}
	}

	public void DownTrigger(bool isTriggerEnter){
		if (isTriggerEnter) {
			if (DownTriggerEnter != null) {
				DownTriggerEnter ();
			}
		} else {
			if (DownTriggerExit != null) {
				DownTriggerExit ();
			}
		}
	}

	public void LeftTrigger(bool isTriggerEnter){
		if (isTriggerEnter) {
			if (LeftTriggerEnter != null) {
				LeftTriggerEnter ();
			}
		} else {
			if (LeftTriggerExit != null) {
				LeftTriggerExit ();
			}
		}
	}


	public void ATrigger(bool isTriggerEnter){
		if (isTriggerEnter) {
			if (ATriggerEnter != null) {
				ATriggerEnter ();
			}
		} else {
			if (ATriggerExit != null) {
				ATriggerExit ();
			}
		}
	}

	public void BTrigger(bool isTriggerEnter){
		if (isTriggerEnter) {
			if (BTriggerEnter != null) {
				BTriggerEnter ();
			}
		} else {
			if (BTriggerExit != null) {
				BTriggerExit ();
			}
		}
	}

	public void XTrigger(bool isTriggerEnter){
		if (isTriggerEnter) {
			if (XTriggerEnter != null) {
				XTriggerEnter ();
			}
		} else {
			if (XTriggerExit != null) {
				XTriggerExit ();
			}
		}
	}

	public void AButton(bool isTriggerDown){
		if (isTriggerDown) {
			if (ATriggerDown != null) {
				ATriggerDown ();
			}
		} else {
			if (ATriggerUp != null) {
				ATriggerUp ();
			}
		}
	}

	public void BButton(bool isTriggerDown){
		if (isTriggerDown) {
			if (BTriggerDown != null) {
				BTriggerDown ();
			}
		} else {
			if (BTriggerUp != null) {
				BTriggerUp ();
			}
		}
	}

	public void XButton(bool isTriggerDown){
		if (isTriggerDown) {
			if (XTriggerDown != null) {
				XTriggerDown ();
			}
		} else {
			if (XTriggerUp != null) {
				XTriggerUp ();
			}
		}
	}
	#endregion Controller
}
