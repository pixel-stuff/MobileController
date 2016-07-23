using UnityEngine;
using System.Collections;

public class UILevelManager : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}



	
	// Update is called once per frame
	void Update () {
	
	}


	public void ReturnToSceneMenu(){
		GameStateManager.setGameState (GameState.Menu);
		Application.LoadLevelAsync ("MenuScene");
	}

	public void GoToGameOverScene(){
		GameStateManager.setGameState (GameState.GameOver);
		Application.LoadLevelAsync ("GameOverScene");

	}
}
