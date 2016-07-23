using UnityEngine;
using System.Collections;

public class FollowingGroundSpeed : MonoBehaviour {

	private ParallaxManager m_parallaxManager;
	private Vector3 m_directionMouvement = new Vector3(1f,0f,0f);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (m_parallaxManager == null) {
			m_parallaxManager = GameObject.FindGameObjectWithTag("ParallaxManager").GetComponent<ParallaxManager>();

		}
		this.transform.position += m_directionMouvement * m_parallaxManager.getGroundSpeedf ();

	
	}
}
