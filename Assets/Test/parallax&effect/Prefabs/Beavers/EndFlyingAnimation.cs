using UnityEngine;
using System.Collections;
using System;

public class EndFlyingAnimation : MonoBehaviour {

	public Action endFlyingAnimationAction;

	public void endFlyingAnimation(){
		if (endFlyingAnimationAction != null) {
			endFlyingAnimationAction();
		}
	}
}
