using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	#region Singleton
	private static InputManager m_instance;
	void Awake(){
		if(m_instance == null){
			//If I am the first instance, make me the Singleton
			m_instance = this;
			DontDestroyOnLoad(this.gameObject);
		}else{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != m_instance)
				Destroy(this.gameObject);
		}
	}
	#endregion Singleton

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		switch (GameStateManager.getGameState ()) {
		case GameState.Menu:
			UpdateMenuState();
			break;
		case GameState.Playing:
			UpdatePlayingState();
			break;
		case GameState.Pause:
			UpdatePauseState();
			break;
		case GameState.GameOver:
			UpdateGameOverState();
			break;
		}
	}

	void UpdateMenuState(){
		if(Input.GetKeyDown(KeyCode.Return)){
			GameStateManager.setGameState (GameState.Playing);
			Application.LoadLevelAsync ("LevelScene");
		}
	}

	void UpdatePlayingState(){
		if(Input.GetKeyDown("p")){
			Debug.Log("PAUSE ! ");
			GameStateManager.setGameState(GameState.Pause);
		}

		if(Input.GetKeyDown("z") || Input.GetKeyDown("w")){
			PlayerManager.UP();
		}
		
		if(Input.GetKeyDown("q") || Input.GetKeyDown("a")){
			PlayerManager.LEFT();
		}
		
		if(Input.GetKeyDown("s")){
			PlayerManager.DOWN ();
		}
		
		if(Input.GetKeyDown("d")){
			PlayerManager.RIGHT();
		}
	}

	void UpdatePauseState(){
		if(Input.GetKeyDown("p")){
			Debug.Log("DÉPAUSE ! ");
			GameStateManager.setGameState(GameState.Playing);
		}
	}

	void UpdateGameOverState(){

	}

}
