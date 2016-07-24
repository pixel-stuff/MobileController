using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum PressedComportement{
	None,
	SpriteSwap,
	Alpha
}

public class VirtualButton : MonoBehaviour {

	[SerializeField]
	private Sprite m_imagePressed;
	private Sprite m_imageIddle;

	public PressedComportement m_pressedComportement = PressedComportement.None;

	void Start(){
		if (m_pressedComportement == PressedComportement.SpriteSwap) {
			m_imageIddle = this.GetComponent<Image> ().sprite;
		}
	}

	public void PressedVirtualButton(bool isTriggerEnter){
		switch(m_pressedComportement){
		case PressedComportement.SpriteSwap:
			if (isTriggerEnter) {
				this.GetComponent<Image> ().sprite = m_imagePressed;
			} else {
				this.GetComponent<Image> ().sprite = m_imageIddle;
			}
			break;

		case PressedComportement.Alpha:

			break;

		}
	}


}
