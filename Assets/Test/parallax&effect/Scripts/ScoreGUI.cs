using UnityEngine;
using System.Collections;

public class ScoreGUI : MonoBehaviour {

	public int beaverKilled = 0;
	public Font myFont;
	public float yOffset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnGUI(){
		GUIStyle myStyle = new GUIStyle();
		myStyle.font = myFont;
		myStyle.normal.textColor = Color.white;
		Vector2 size = myStyle.CalcSize (new GUIContent ("" +beaverKilled));

		GUI.Label(new Rect((Screen.width)/2, ((Screen.height - size.y)/2) + yOffset, size.x, size.y),""+beaverKilled,myStyle);
	}
}
