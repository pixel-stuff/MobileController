using UnityEngine;
using System.Collections;

public class CameraGUI : MonoBehaviour {

	private GUIText m_guiText;
	private int m_score = 0;

	// Use this for initialization
	void Start () {
		m_guiText = gameObject.AddComponent<GUIText> ();
		m_guiText.color = new Color (1.0f, 0.0f, 0.0f);
		m_guiText.font = Font.CreateDynamicFontFromOSFont("Arial", 11);
		m_guiText.text = "";
		m_guiText.enabled = false;
		m_guiText.fontStyle = FontStyle.Bold;
		m_guiText.anchor = TextAnchor.UpperCenter;
		m_guiText.alignment = TextAlignment.Center;
		m_guiText.pixelOffset = Camera.main.WorldToScreenPoint (transform.position) + (new Vector3(-400.0f, 200.0f));
		m_guiText.enabled = true;
	}

	public void setScore(int n) {
		m_score = n;
	}
	
	// Update is called once per frame
	void Update () {
		//m_guiText.text = "Score: "+m_score;
	}
}
