using UnityEngine;
using System.Collections;
using System;

public enum GameState{
	Menu,
	Playing,
	Pause,
	GameOver
}

public class GameStateManager : MonoBehaviour {

	#region Singleton
	public static GameStateManager m_instance;
	void Awake(){
		if(m_instance == null){
			//If I am the first instance, make me the Singleton
			m_gameState = GameState.Menu;
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

	private static GameState m_gameState;
	
	public static Action<GameState> onChangeStateEvent;

	// Use this for initialization
	void Start () {
	}


	
	// Update is called once per frame
	void Update () {
		Debug.Log ("GAME STATE : " + m_gameState);
	}

	public static GameState getGameState(){
		return m_gameState;
	}

	public static void setGameState(GameState state){

		m_gameState = state;
		if(onChangeStateEvent != null){
			onChangeStateEvent(state);
		}
	}
}
