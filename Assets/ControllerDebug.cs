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
		MobileController.m_instance.UpTriggerEnter += UpUpdateEnter;
		MobileController.m_instance.UpTriggerExit += UpUpdateExit;
		MobileController.m_instance.RightTriggerEnter += RightUpdateEnter;
		MobileController.m_instance.RightTriggerExit += RightUpdateExit;
		MobileController.m_instance.DownTriggerEnter += DownUpdateEnter;
		MobileController.m_instance.DownTriggerExit += DownUpdateExit;
		MobileController.m_instance.LeftTriggerEnter += LeftUpdateEnter;
		MobileController.m_instance.LeftTriggerExit += LeftUpdateExit;
		MobileController.m_instance.ATriggerEnter += AUpdateEnter;
		MobileController.m_instance.ATriggerEnter += AUpdateExit;
		MobileController.m_instance.BTriggerEnter += BUpdateEnter;
		MobileController.m_instance.BTriggerExit += BUpdateExit;
		MobileController.m_instance.XTriggerEnter += XUpdateEnter;
		MobileController.m_instance.XTriggerExit += XUpdateExit;
		MobileController.m_instance.ATriggerDown += AUpdateDown;
		MobileController.m_instance.ATriggerUp += AUpdateUp;
		MobileController.m_instance.BTriggerDown += BUpdateDown;
		MobileController.m_instance.BTriggerUp += BUpdateUp;
		MobileController.m_instance.XTriggerDown += XUpdateDown;
		MobileController.m_instance.XTriggerUp += XUpdateUp;
	}
	
	void UpUpdateEnter(){
		m_textdebug.text = "UpEnter";
		Debug.Log ("UpEnter");
	}

	void UpUpdateExit(){
		m_textdebug.text = "UpExit";
		Debug.Log ("UpExit");
	}

	void RightUpdateEnter(){
		m_textdebug.text = "RightEnter";
		Debug.Log ("RightEnter");
	}

	void RightUpdateExit(){
		m_textdebug.text = "RightExit";
		Debug.Log ("RightExit");
	}

	void DownUpdateEnter(){
		m_textdebug.text = "DownEnter";
		Debug.Log ("DownEnter");
	}

	void DownUpdateExit(){
		m_textdebug.text = "DownExit";
		Debug.Log ("DownExit");
	}

	void LeftUpdateEnter(){
		m_textdebug.text = "LeftEnter";
		Debug.Log ("LeftEnter");
	}

	void LeftUpdateExit(){
		m_textdebug.text = "LeftExit";
		Debug.Log ("LeftExit");
	}

	void AUpdateEnter(){
		m_textdebug.text = "AEnter";
		Debug.Log ("AEnter");
	}

	void AUpdateExit(){
		m_textdebug.text = "AExit";
		Debug.Log ("AExit");
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

	void AUpdateDown(){
		m_text2debug.text = "ADown";
		Debug.Log ("ADown");
	}

	void AUpdateUp(){
		m_text2debug.text = "AUp";
		Debug.Log ("AUp");
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
