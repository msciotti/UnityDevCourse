using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	static MusicPlayer _musicPlayer = null;
	
	void GetInstance(){
		if (_musicPlayer == null){
			_musicPlayer = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
		else Destroy(gameObject);
	}
	
	void Awake(){
		GetInstance();
	}
}
