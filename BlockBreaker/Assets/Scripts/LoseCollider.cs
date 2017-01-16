using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	public LevelManager _levelmanager;
	void OnCollisionEnter2D(Collision2D collision){
		
	
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		_levelmanager.LoadLevel("Win Screen");
	
	}
}
