using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public float shakeSpeedX = 0.01f;
	public float shakeAmplitudeX = 0.1f;
	public float shakeSpeedY = 0.01f;
	public float shakeAmplitudeY = 0.1f;

	public GameObject gameOverScreenSprite;

	public Font screenFont;

	public bool m_isShakingX = false;
	public bool m_isShakingY = false;
	public float m_shakingDuration = 0.0f;
	public bool m_isGameOver = false;

	public float zoom;
	public Rect rectCamera;
	private bool m_isGameOverScreenShowing = false;
	private GUIText m_guiText = null;

	// Use this for initialization
	void Start () {
		m_guiText = gameOverScreenSprite.AddComponent<GUIText> ();
		m_guiText.color = new Color (1.0f, 0.0f, 0.0f);
		m_guiText.font = Font.CreateDynamicFontFromOSFont("Arial", 11);
		m_guiText.text = "";
		m_guiText.enabled = false;
		initSettings();
	}

	private void initSettings() {
		Camera.main.transform.position = new Vector3 (1.0f, 0.0f, -2.0f);
		Camera.main.orthographicSize = zoom;
		Camera.main.rect = rectCamera;//new Rect(0.0f, 0.25f, 1.0f, 0.55f);
		m_guiText.transform.position = new Vector3 (0.0f, 0.0f, -1.0f);
		gameOverScreenSprite.transform.position = new Vector3 (0.0f, 0.0f, -1.0f);
	}

	private void restartSettings() {
		Camera.main.transform.position = new Vector3 (
			Mathf.SmoothStep (Camera.main.transform.position.x, 1.0f, 0.01f),
			Mathf.SmoothStep (Camera.main.transform.position.y, 0.0f, 0.01f),
			Mathf.SmoothStep (Camera.main.transform.position.z, -2.0f, 0.01f)
			);
		Camera.main.orthographicSize = zoom;
		Camera.main.rect =rectCamera;// new Rect(0.0f, 0.25f, 1.0f, 0.55f);
		m_guiText.transform.position = new Vector3 (0.0f, 0.0f, -1.0f);
		gameOverScreenSprite.transform.position = new Vector3 (0.0f, 0.0f, -1.0f);
	}
	
	private void shakeX (bool brute) {
		if (brute) {
			float x = Random.Range (-shakeAmplitudeX, shakeAmplitudeX);
			Camera.main.transform.position = new Vector3 (x, 0.0f, 0.0f);
		} else {
			if(Camera.main.transform.position.x<-shakeAmplitudeX) {
				shakeSpeedX = Mathf.Abs(shakeSpeedX);
			}else if(Camera.main.transform.position.x>shakeAmplitudeX) {
				shakeSpeedX = -Mathf.Abs(shakeSpeedX);
			}
			Camera.main.transform.Translate(new Vector3 (shakeSpeedX, 0.0f, 0.0f));
		}
	}

	private void shakeY (bool brute) {
		if (brute) {
			float y = Random.Range (-shakeAmplitudeY, shakeAmplitudeY);
			Camera.main.transform.position = new Vector3 (0.0f, y, 0.0f);
		} else {
			if(Camera.main.transform.position.y<-shakeAmplitudeY) {
				shakeSpeedY = Mathf.Abs(shakeSpeedY);
			}else if(Camera.main.transform.position.y>shakeAmplitudeY) {
				shakeSpeedY = -Mathf.Abs(shakeSpeedY);
			}
			Camera.main.transform.Translate(new Vector3 (0.0f, shakeSpeedY, 0.0f));
		}
	}

	private void enableGameOverScreen() {
		if (!m_isGameOverScreenShowing) {
			gameOverScreenSprite.SetActive (true);
			m_isGameOverScreenShowing = true;
			writeOnScreen("GAME OVER", 0.0f, 0.0f);
		}
	}
	
	public void disableGameOverScreen() {
		gameOverScreenSprite.SetActive(false);
		m_isGameOverScreenShowing = false;
		m_guiText.enabled = true;
	}

	public void writeOnScreen(string text, float offsetX, float offsetY) {
		m_guiText.text = text;
		m_guiText.anchor = TextAnchor.MiddleCenter;
		m_guiText.alignment = TextAlignment.Center;
		m_guiText.pixelOffset = Camera.main.WorldToScreenPoint (transform.position)+(new Vector3(offsetX, offsetY, 0.0f));
		m_guiText.enabled = true;

	}

	public void setShakeSpeedX(float sspeed) {
		shakeSpeedX = sspeed;
	}
	
	public void setShakeAmplitudeX(float samp) {
		shakeSpeedX = samp;
	}
	
	public void setShakeSpeedY(float sspeed) {
		shakeSpeedY = sspeed;
	}
	
	public void setShakeAmplitudeY(float samp) {
		shakeSpeedY = samp;
	}

	public void setShaking(bool x, bool y, float duration) {
		m_isShakingX = x;
		m_isShakingY = y;
		m_shakingDuration = duration;
	}
	
	// Update is called once per frame
	void Update () {
		if (m_isShakingX && m_shakingDuration>0.0f) {
			shakeX (false);
		}
		if (m_isShakingY && m_shakingDuration>0.0f) {
			shakeY (false);
		}
		if (m_shakingDuration <= 0.0f) {
			m_isShakingX = false;
			m_isShakingY = false;
			m_shakingDuration = 0.0f;
		}
		if (!m_isShakingX && !m_isShakingY) {
			restartSettings();
		}
		if (m_isGameOver) {
			enableGameOverScreen ();
		} else {
			disableGameOverScreen ();
		}
		if ((m_isShakingX || m_isShakingY) && m_shakingDuration > 0.0f) {
			m_shakingDuration -= Time.deltaTime;
		}
	}
}
