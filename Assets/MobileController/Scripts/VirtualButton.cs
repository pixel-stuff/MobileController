using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum PressedComportement{
	None,
	SpriteSwap,
	Alpha
}

public class VirtualButton : MonoBehaviour {

	
	public PressedComportement m_pressedComportement = PressedComportement.None;

	//Use these variable to swap image
	[SerializeField]
	private Sprite m_imagePressed;
	private Sprite m_imageIddle;

	//use this variable to change alpha image
	private float m_alphaIddle = 0f;

	void Start(){
		switch(m_pressedComportement){
		case PressedComportement.SpriteSwap:
			m_imageIddle = this.GetComponent<Image> ().sprite;
			break;
		case PressedComportement.Alpha:
			m_alphaIddle = this.GetComponent<Image> ().color.a;
			Debug.Log("alpha : " + m_alphaIddle);
			break;
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
			Color color = this.GetComponent<Image> ().color;
			if (isTriggerEnter) {
				color.a = 1.0f;
				this.GetComponent<Image> ().color = color;
			} else {
				color.a = m_alphaIddle;
				this.GetComponent<Image> ().color = color;
			}
			break;
		}
	}


}
