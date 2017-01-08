using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TextController : MonoBehaviour {

	public Text text;
	private enum State { cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom, mirror_look };
	private State currentState;
	
	// Use this for initialization
	void Start () {
		currentState = State.cell;		
	}
	
	// Update is called once per frame
	void Update () {
		if(currentState == State.cell){cell();}
		else if (currentState == State.mirror){mirror();}		
		else if (currentState == State.sheets_0){sheets_0();}
		else if (currentState == State.lock_0){lock_0();}
		else if (currentState == State.cell_mirror){cell_mirror();}
		else if (currentState == State.sheets_1){sheets_1();}
		else if (currentState == State.lock_1){lock_1();}
		else if (currentState == State.freedom){freedom();}
		
	}
	
	void cell(){
		currentState = State.cell;
		text.text = "You are in a prison cell. There are some dirty sheets on the bed. " +
					"There is a mirror on the wall. The door is locked from the outside.\n\n" +
					"Press S to look at the sheets. Press M to look at the mirror. Press L to look at the lock";
		if(Input.GetKeyDown(KeyCode.S)){ currentState = State.sheets_0; sheets_0(); }	
		else if(Input.GetKeyDown(KeyCode.M)){ currentState = State.mirror; mirror(); }			
		if(Input.GetKeyDown(KeyCode.L)){ currentState = State.lock_0; lock_0(); }			
		
	}
	
	void sheets_0(){
		currentState = State.sheets_0;
		text.text = "Yup. Those are yours. And so is that stain.\n\n Press R to return to your cell";
		if(Input.GetKeyDown(KeyCode.R)){currentState = State.cell; }				
	}
	
	void mirror(){
		currentState = State.mirror;
		text.text = "You look into the mirror. Ah! A monster! Oh wait, that's just you.\n\nPress R to return to your cell, or Press P to pick up the mirror.";
		if(Input.GetKeyDown(KeyCode.P)){currentState = State.cell_mirror; }						
		else if(Input.GetKeyDown(KeyCode.R)){currentState = State.cell; }	
	}
	
	void lock_0(){
		currentState = State.lock_0;
		text.text = "It's a button lock. You can almost make out where dirty fingerprints were.\n\n Press R to return to roaming your cell.";
		if(Input.GetKeyDown(KeyCode.R)){currentState = State.cell; }						
	}
	
	void cell_mirror(){
		currentState = State.cell_mirror;
		text.text = "You are in a prison cell. There are some dirty sheets on the bed. " +
					"There is a mirror on the wall. The door is locked from the outside. You have a mirror.\n\n" +
					"Press S to look at the sheets. Press M to look in the mirror. Press L to look at the lock";
		if(Input.GetKeyDown(KeyCode.S)){ currentState = State.sheets_1; sheets_1(); }	
		else if(Input.GetKeyDown(KeyCode.M)){ currentState = State.mirror_look; mirror_look(); }			
		if(Input.GetKeyDown(KeyCode.L)){ currentState = State.lock_1; lock_1(); }	
	}
	
	void mirror_look(){
		currentState = State.mirror_look;
		text.text = "You're ugly.\n\n Press R to return to your self loathing.";
		if(Input.GetKeyDown(KeyCode.R)){currentState = State.cell_mirror; }								
	}
	
	void sheets_1(){
		currentState = State.sheets_1;
		text.text = "Even in the beautiful silver glass of the mirror, the sheets still look disgusting.\n\n Press R to return to your cell.";
		if(Input.GetKeyDown(KeyCode.R)){currentState = State.cell_mirror; }								
	}
	
	void lock_1(){
		currentState = State.lock_1;
		text.text = "You put the mirror through the bars and turn it around. You can see the fingerprints clearly. After a few tries, you press the buttons, and hear a click. " +
					"\n\nPress O to open the cell door, or R to return to your cell";
		if(Input.GetKeyDown(KeyCode.O)){currentState = State.freedom; }						
		else if(Input.GetKeyDown(KeyCode.R)){currentState = State.cell_mirror; }								
	}
	
	void freedom(){
		currentState = State.freedom;
		text.text = "You've escaped! Run you stupid bastard!";		
	}
}
