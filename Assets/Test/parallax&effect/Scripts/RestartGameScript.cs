using UnityEngine;
using System.Collections;
using System;

public class RestartGameScript : MonoBehaviour {

	public Action onKeyDown;

	//bool isPush = false;
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Return) /*&& !isPush*/) {
			//isPush = true;
			if(onKeyDown != null){
				//onKeyDown();
			}
		}
	}


}
