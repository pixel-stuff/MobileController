using UnityEngine;
using System.Collections;

public class ParallaxSlider : MonoBehaviour {

	public GameObject prefabBackground;
	public float speedMaxX = -0.1f;
	public float posZ = 0.0f;

	private ArrayList backgroundList;
	private Vector3 size;

	private float m_pausedTime = 0.0f;
	
	private Vector3 m_speed;
	private bool m_pause = false;
	// Use this for initialization
	void Start () {
		backgroundList = new ArrayList();
		m_speed.x = -0.0f;
		backgroundList.Add (((GameObject)Instantiate (prefabBackground)));
		backgroundList.Add (((GameObject)Instantiate (prefabBackground)));
		backgroundList.Add (((GameObject)Instantiate (prefabBackground)));
		size = ((GameObject)backgroundList[0]).GetComponent<Renderer>().bounds.size;
		foreach (GameObject bg in backgroundList) {
			bg.transform.SetParent(gameObject.transform);
		}
		((GameObject)backgroundList[0]).transform.position = new Vector3(-size.x, 0.0f, posZ);
		((GameObject)backgroundList[1]).transform.position = new Vector3(0.0f, 0.0f, posZ);
		((GameObject)backgroundList[2]).transform.position = new Vector3(size.x, 0.0f, posZ);
	}

	public void setPause(bool b) {
		m_pause = b;
	}

	// Update is called once per frame
	void Update () {
		if (!m_pause) {
			float sign = speedMaxX/Mathf.Abs(speedMaxX);
			if(Mathf.Abs(m_speed.x)>Mathf.Abs(speedMaxX)) {
				m_speed.x = speedMaxX;
			}
			foreach (GameObject slide in backgroundList) {
				slide.transform.Translate (m_speed);
				if (slide.transform.position.x <= -1.5f * size.x) {
					slide.transform.Translate (new Vector3 (3.0f * size.x, 0.0f, 0.0f));
				}
			}
			m_pausedTime += Time.deltaTime;
			if(Mathf.Abs(m_speed.x)<Mathf.Abs(speedMaxX)) {
				m_speed.x = sign*m_pausedTime/6.0f;//(-Mathf.Pow(2, -10 * m_pausedTime/2.0f) +1);
				//m_speed.x = sign*(Mathf.Log10(m_pausedTime+80.0f) - 1.90f);
				//m_speed.x = ((m_pausedTime+1.0f)*(m_pausedTime+1.0f)*(m_pausedTime+1.0f) - 1.0f);
			}
		} else {
			m_pausedTime = 0.0f;
			m_speed.x = 0.0f;
		}
	}

	public Vector3 getSpeed() {
		return m_speed;
	}
}
