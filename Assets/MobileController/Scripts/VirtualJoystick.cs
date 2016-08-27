using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class VirtualJoystick : MonoBehaviour,IDragHandler, IPointerUpHandler, IPointerDownHandler {
	public Image m_joystickBackground;
	public Image m_joystick;

	public Vector3 InputDirection ;
	public Action<Vector2> OnChangeDirection;

	void Start(){

		//m_joystickBackground = GetComponent<Image>();
		//m_joystick = transform.GetChild(0).GetComponent<Image>(); //this command is used because there is only one child in hierarchy
		InputDirection = Vector3.zero;
	}

	public void OnDrag(PointerEventData ped){
		Vector2 position = Vector2.zero;

		//To get InputDirection
		RectTransformUtility.ScreenPointToLocalPointInRectangle
		(m_joystickBackground.rectTransform,
			ped.position,
			ped.pressEventCamera,
			out position);

		position.x = (position.x/m_joystickBackground.rectTransform.sizeDelta.x);
		position.y = (position.y/m_joystickBackground.rectTransform.sizeDelta.y);


		float x = (m_joystickBackground.rectTransform.pivot.x == 1f) ? position.x *2 + 1 : position.x *2 - 1;
		float y = (m_joystickBackground.rectTransform.pivot.y == 1f) ? position.y *2 + 1 : position.y *2 - 1;

		InputDirection = new Vector3 (x,y,0);
		InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;
		if (OnChangeDirection != null) {
			OnChangeDirection(new Vector2(InputDirection.x,InputDirection.y));
		}
		//to define the area in which joystick can move around
		m_joystick.rectTransform.anchoredPosition = new Vector3 (InputDirection.x * (m_joystickBackground.rectTransform.sizeDelta.x/3)
			,InputDirection.y * (m_joystickBackground.rectTransform.sizeDelta.y)/3);

	}

	public void OnPointerDown(PointerEventData ped){

		OnDrag(ped);
	}

	public void OnPointerUp(PointerEventData ped){

		InputDirection = Vector3.zero;
		m_joystick.rectTransform.anchoredPosition = Vector3.zero;
	}
}
