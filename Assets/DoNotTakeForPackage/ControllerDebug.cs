using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControllerDebug : MonoBehaviour {

	[SerializeField]
	private Text m_textdebug;

	[SerializeField]
	private Text m_text2debug;

	// Use this for initialization
	void Start () {
		MobileController.m_instance.OnUpTriggerEnter += UpUpdateEnter;
		MobileController.m_instance.OnUpTriggerExit += UpUpdateExit;
		MobileController.m_instance.OnRightTriggerEnter += RightUpdateEnter;
		MobileController.m_instance.OnRightTriggerExit += RightUpdateExit;
		MobileController.m_instance.OnDownTriggerEnter += DownUpdateEnter;
		MobileController.m_instance.OnDownTriggerExit += DownUpdateExit;
		MobileController.m_instance.OnLeftTriggerEnter += LeftUpdateEnter;
		MobileController.m_instance.OnLeftTriggerExit += LeftUpdateExit;
		MobileController.m_instance.OnATriggerEnter += AUpdateEnter;
		MobileController.m_instance.OnATriggerExit += AUpdateExit;
		MobileController.m_instance.OnBTriggerEnter += BUpdateEnter;
		MobileController.m_instance.OnBTriggerExit += BUpdateExit;
		MobileController.m_instance.OnXTriggerEnter += XUpdateEnter;
		MobileController.m_instance.OnXTriggerExit += XUpdateExit;
		MobileController.m_instance.OnATriggerDown += AUpdateDown;
		MobileController.m_instance.OnATriggerUp += AUpdateUp;
		MobileController.m_instance.OnBTriggerDown += BUpdateDown;
		MobileController.m_instance.OnBTriggerUp += BUpdateUp;
		MobileController.m_instance.OnXTriggerDown += XUpdateDown;
		MobileController.m_instance.OnXTriggerUp += XUpdateUp;

		MobileController.m_instance.ATriggered += AUpdateTriggered;
	}



	void UpUpdateEnter(){
		m_textdebug.text = "UpEnter";
		//Debug.Log ("UpEnter");
	}

	void UpUpdateExit(){
		m_textdebug.text = "UpExit";
		//Debug.Log ("UpExit");
	}

	void RightUpdateEnter(){
		m_textdebug.text = "RightEnter";
		//Debug.Log ("RightEnter");
	}

	void RightUpdateExit(){
		m_textdebug.text = "RightExit";
		//Debug.Log ("RightExit");
	}

	void DownUpdateEnter(){
		m_textdebug.text = "DownEnter";
		//Debug.Log ("DownEnter");
	}

	void DownUpdateExit(){
		m_textdebug.text = "DownExit";
		//Debug.Log ("DownExit");
	}

	void LeftUpdateEnter(){
		m_textdebug.text = "LeftEnter";
		//Debug.Log ("LeftEnter");
	}

	void LeftUpdateExit(){
		m_textdebug.text = "LeftExit";
		//Debug.Log ("LeftExit");
	}



	void AUpdateEnter(){
		m_textdebug.text = "AEnter";
		Debug.Log ("1 - AEnter");
	}

	void AUpdateExit(){
		m_textdebug.text = "AExit";
		Debug.Log ("2 - AExit");
	}

	void AUpdateTriggered(){
		Debug.Log ("0 - A Triggered");
	}


	void AUpdateDown(){
		m_text2debug.text = "ADown";
		Debug.Log ("3 - ADown");
	}

	void AUpdateUp(){
		m_text2debug.text = "AUp";
		Debug.Log ("4 - AUp");
	}

	void BUpdateEnter(){
		m_textdebug.text = "BEnter";
		Debug.Log ("BEnter");
	}

	void BUpdateExit(){
		m_textdebug.text = "BExit";
		Debug.Log ("BExit");
	}

	void XUpdateEnter(){
		m_textdebug.text = "XEnter";
		Debug.Log ("XEnter");
	}

	void XUpdateExit(){
		m_textdebug.text = "XExit";
		Debug.Log ("XExit");
	}


	void BUpdateDown(){
		m_text2debug.text = "BDown";
		Debug.Log ("BDown");
	}

	void BUpdateUp(){
		m_text2debug.text = "BUp";
		Debug.Log ("BUp");
	}

	void XUpdateDown(){
		m_text2debug.text = "XDown";
		Debug.Log ("XDown");
	}

	void XUpdateUp(){
		m_text2debug.text = "XUp";
		Debug.Log ("XUp");
	}
}
