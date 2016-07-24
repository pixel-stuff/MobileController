using UnityEngine;
using System.Collections;
using System;

public class MobileController : MonoBehaviour {
	#region Singleton
	public static MobileController m_instance;
	void Awake(){
		if(m_instance == null){
			//If I am the first instance, make me the Singleton
			m_instance = this;
			DontDestroyOnLoad(this.gameObject);
			if (m_hideController) {
				m_pad.SetActive (false);
				m_joystick.SetActive (false);
				m_buttons.SetActive (false);
			}
		}else{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != m_instance)
				Destroy(this.gameObject);
		}
	}
	#endregion Singleton

	#region Actions //Subscrib here to get action
	public Action OnUpTriggerEnter;
	public Action OnUpTriggerExit;
	public Action UpTriggered;
	public Action OnDownTriggerEnter;
	public Action OnDownTriggerExit;
	public Action DownTriggered;
	public Action OnRightTriggerEnter;
	public Action OnRightTriggerExit;
	public Action RightTriggered;
	public Action OnLeftTriggerEnter;
	public Action OnLeftTriggerExit;
	public Action LeftTriggered;

	public Action OnATriggerExit;
	public Action OnATriggerEnter;
	public Action ATriggered;
	public Action OnBTriggerExit;
	public Action OnBTriggerEnter;
	public Action BTriggered;
	public Action OnXTriggerExit;
	public Action OnXTriggerEnter;
	public Action XTriggered;
	public Action OnATriggerUp;
	public Action OnATriggerDown;
	public Action OnBTriggerUp;
	public Action OnBTriggerDown;
	public Action OnXTriggerUp;
	public Action OnXTriggerDown;

	private bool m_isABeingPressed = false;
	private bool m_isBBeingPressed = false;
	private bool m_isXBeingPressed = false;
	private bool m_isUpBeingPressed = false;
	private bool m_isRightBeingPressed = false;
	private bool m_isDownBeingPressed = false;
	private bool m_isLeftBeingPressed = false;
	#endregion Actions

	#region Utils
	[SerializeField]
	private bool m_hideController = false;
	[SerializeField]
	private GameObject m_pad;
	[SerializeField]
	private GameObject m_joystick;
	[SerializeField]
	private GameObject m_buttons;

	public void ShowController(){
		m_pad.SetActive (true);
		m_joystick.SetActive (true);
		m_buttons.SetActive (true);
	}
	#endregion Utils

	#region Controller
	public void UpTrigger(bool isTriggerEnter){
		if (isTriggerEnter) {
			if (CanBeTriggerEnter()) {
				m_isUpBeingPressed = isTriggerEnter;
				if (OnUpTriggerEnter != null) {
					OnUpTriggerEnter ();
				}
			}
		} else {
			m_isUpBeingPressed = isTriggerEnter;
			if (OnUpTriggerExit != null) {
				OnUpTriggerExit ();
			}
		}
	}

	public void RightTrigger(bool isTriggerEnter){
		if (isTriggerEnter) {
			if (CanBeTriggerEnter()) {
				m_isRightBeingPressed = isTriggerEnter;
				if (OnRightTriggerEnter != null) {
					OnRightTriggerEnter ();
				}
			}
		} else {
			m_isRightBeingPressed = isTriggerEnter;
			if (OnRightTriggerExit != null) {
				OnRightTriggerExit ();
			}
		}
	}

	public void DownTrigger(bool isTriggerEnter){
		if (isTriggerEnter) {
			if (CanBeTriggerEnter()) {
				m_isDownBeingPressed = isTriggerEnter;
				if (OnDownTriggerEnter != null) {
					OnDownTriggerEnter ();
				}
			}
		} else {
			m_isDownBeingPressed = isTriggerEnter;
			if (OnDownTriggerExit != null) {
				OnDownTriggerExit ();
			}
		}
	}

	public void LeftTrigger(bool isTriggerEnter){
		if (isTriggerEnter) {
			if (CanBeTriggerEnter()) {
				m_isLeftBeingPressed = isTriggerEnter;
				if (OnLeftTriggerEnter != null) {
					OnLeftTriggerEnter ();
				}
			}
		} else {
			m_isLeftBeingPressed = isTriggerEnter;
			if (OnLeftTriggerExit != null) {
				OnLeftTriggerExit ();
			}
		}
	}

	public void ATrigger(bool isTriggerEnter){
		if (isTriggerEnter) {
			if (CanBeTriggerEnter()) {
				m_isABeingPressed = isTriggerEnter;
				if (OnATriggerEnter != null) {
					OnATriggerEnter ();
				}
			}
		} else {
			m_isABeingPressed = isTriggerEnter;
			if (OnATriggerExit != null) {
				OnATriggerExit ();
			}
		}
	}

	public void BTrigger(bool isTriggerEnter){
		if (isTriggerEnter) {
			if (CanBeTriggerEnter()) {
				m_isBBeingPressed = isTriggerEnter;
				if (OnBTriggerEnter != null) {
					OnBTriggerEnter ();
				}
			}
		} else {
			m_isBBeingPressed = isTriggerEnter;
			if (OnBTriggerExit != null) {
				OnBTriggerExit ();
			}
		}
	}

	public void XTrigger(bool isTriggerEnter){
		if (isTriggerEnter) {
			if (CanBeTriggerEnter()) {
				m_isXBeingPressed = isTriggerEnter;
				if (OnXTriggerEnter != null) {
					OnXTriggerEnter ();
				}
			}
		} else {
			m_isXBeingPressed = isTriggerEnter;
			if (OnXTriggerExit != null) {
				OnXTriggerExit ();
			}
		}
	}

	public void AButton(bool isTriggerDown){
		if (isTriggerDown) {
			if (OnATriggerDown != null) {
				OnATriggerDown ();
			}
		} else {
			if (OnATriggerUp != null) {
				OnATriggerUp ();
			}
		}
	}

	public void BButton(bool isTriggerDown){
		if (isTriggerDown) {
			if (OnBTriggerDown != null) {
				OnBTriggerDown ();
			}
		} else {
			if (OnBTriggerUp != null) {
				OnBTriggerUp ();
			}
		}
	}

	public void XButton(bool isTriggerDown){
		if (isTriggerDown) {
			if (OnXTriggerDown != null) {
				OnXTriggerDown ();
			}
		} else {
			if (OnXTriggerUp != null) {
				OnXTriggerUp ();
			}
		}
	}

	void FixedUpdate(){
		if (m_isABeingPressed) {
			if (ATriggered != null) {
				ATriggered ();
			}
		}
		if (m_isBBeingPressed) {
			if (BTriggered != null) {
				BTriggered ();
			}
		}
		if (m_isXBeingPressed) {
			if (XTriggered != null) {
				XTriggered ();
			}
		}
		if (m_isUpBeingPressed) {
			if (UpTriggered != null) {
				UpTriggered ();
			}
		}
		if (m_isRightBeingPressed) {
			if (RightTriggered != null) {
				RightTriggered ();
			}
		}
		if (m_isDownBeingPressed) {
			if (DownTriggered != null) {
				DownTriggered ();
			}
		}
		if (m_isLeftBeingPressed) {
			if (LeftTriggered != null) {
				LeftTriggered ();
			}
		}
	}

	private bool CanBeTriggerEnter(){
		if (Input.touchSupported) {
			if (Input.touchCount != 0) {
				return true;
			} else {
				return false;
			}
		} else {
			return true;
		}
	}
	#endregion Controller
}
