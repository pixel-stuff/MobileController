using UnityEngine;
using System.Collections;

public class ScriptArea : MonoBehaviour {

	private Vector3 m_spawnPosition = new Vector3(10f,0,0);

	// Use this for initialization
	void Start () {
		m_spawnPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Vector3 getSpawnPosition(){
		return m_spawnPosition;
	}
}
