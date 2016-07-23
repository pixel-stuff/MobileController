using UnityEngine;
using System.Collections;

public class ParallaxManager : MonoBehaviour {

	public GameObject refGroundMaster;
	public bool isPaused = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		setPause (isPaused);
	}

	public void setPause(bool b) {
		foreach (ParallaxSlider ps in GetComponentsInChildren<ParallaxSlider>()) {
			ps.setPause(b);
		}
	}

	// getGroundSpeed
	public float getGroundSpeedf() {
		return refGroundMaster.GetComponent<ParallaxSlider>().getSpeed().x;
	}
}
