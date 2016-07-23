using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	#region Singleton
	private static AudioManager m_instance;
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

	[SerializeField]
	private string m_backgroundAudioSource;

	private static Transform m_transform;

	// Use this for initialization
	void Start () {
		m_transform = this.transform;
		Play (m_backgroundAudioSource);
	}

	public static void Play(string clipname){
		//Create an empty game object
		GameObject go = new GameObject ("Audio_" +  clipname);
		go.transform.parent = m_transform;
		//Load clip from ressources folder
		AudioClip newClip =  Instantiate(Resources.Load (clipname, typeof(AudioClip))) as AudioClip;

		//Add and bind an audio source
		AudioSource source = go.AddComponent<AudioSource>();
		source.clip = newClip;
		//Play and destroy the component
		source.Play();
		Destroy (go, newClip.length);

	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
