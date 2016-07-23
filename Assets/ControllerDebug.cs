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
		ControllerActions.m_instance.UpTriggerEnter += UpUpdateEnter;
		ControllerActions.m_instance.UpTriggerExit += UpUpdateExit;
		ControllerActions.m_instance.RightTriggerEnter += RightUpdateEnter;
		ControllerActions.m_instance.RightTriggerExit += RightUpdateExit;
		ControllerActions.m_instance.DownTriggerEnter += DownUpdateEnter;
		ControllerActions.m_instance.DownTriggerExit += DownUpdateExit;
		ControllerActions.m_instance.LeftTriggerEnter += LeftUpdateEnter;
		ControllerActions.m_instance.LeftTriggerExit += LeftUpdateExit;
		ControllerActions.m_instance.ATriggerEnter += AUpdateEnter;
		ControllerActions.m_instance.ATriggerEnter += AUpdateExit;
		ControllerActions.m_instance.BTriggerEnter += BUpdateEnter;
		ControllerActions.m_instance.BTriggerExit += BUpdateExit;
		ControllerActions.m_instance.XTriggerEnter += XUpdateEnter;
		ControllerActions.m_instance.XTriggerExit += XUpdateExit;
		ControllerActions.m_instance.ATriggerDown += AUpdateDown;
		ControllerActions.m_instance.ATriggerUp += AUpdateUp;
		ControllerActions.m_instance.BTriggerDown += BUpdateDown;
		ControllerActions.m_instance.BTriggerUp += BUpdateUp;
		ControllerActions.m_instance.XTriggerDown += XUpdateDown;
		ControllerActions.m_instance.XTriggerUp += XUpdateUp;
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
