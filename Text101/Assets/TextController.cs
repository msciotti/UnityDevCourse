using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TextController : MonoBehaviour {

	public Text text;
	private enum State { cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, corridor_2, closet_3, lock_1, captured, mirror_look, corridor_0, floor, closet_0, stairs_0, closet_1, stairs_1, stairs_2, courtyard, closet_2, corridor_1 };
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
		else if (currentState == State.mirror_look){mirror_look();}
		else if (currentState == State.sheets_1){sheets_1();}
		else if (currentState == State.lock_1){lock_1();}
		else if (currentState == State.corridor_0){corridor_0();}
		else if (currentState == State.floor){floor();}
		else if (currentState == State.stairs_0){stairs_0();}
		else if (currentState == State.closet_0){closet_0();}
		else if (currentState == State.corridor_1){corridor_1();}
		else if (currentState == State.corridor_2){corridor_2();}				
		else if (currentState == State.stairs_1){stairs_1();}
		else if (currentState == State.stairs_2){stairs_2();}		
		else if (currentState == State.closet_1){closet_1();}
		else if (currentState == State.closet_2){closet_2();}		
		else if (currentState == State.closet_3){closet_3();}				
		else if (currentState == State.courtyard){courtyard();}
		else if (currentState == State.captured){captured ();}					
	}	
	void cell(){
		text.text = "You are in a prison cell. There are some dirty sheets on the bed. " +
					"There is a mirror on the wall. The door is locked from the outside.\n\n" +
					"Press S to look at the sheets. Press M to look at the mirror. Press L to look at the lock";
		if(Input.GetKeyDown(KeyCode.S)){ currentState = State.sheets_0; sheets_0(); }	
		else if(Input.GetKeyDown(KeyCode.M)){ currentState = State.mirror; mirror(); }			
		if(Input.GetKeyDown(KeyCode.L)){ currentState = State.lock_0; lock_0(); }			
		
	}
	
	void sheets_0(){
		text.text = "Yup. Those are yours. And so is that stain.\n\nPress R to return to your cell";
		if(Input.GetKeyDown(KeyCode.R)){currentState = State.cell; }				
	}
	
	void mirror(){
		text.text = "You look into the mirror. Ah! A monster! Oh wait, that's just you.\n\nPress R to return to your cell, or Press P to pick up the mirror.";
		if(Input.GetKeyDown(KeyCode.P)){currentState = State.cell_mirror; }						
		else if(Input.GetKeyDown(KeyCode.R)){currentState = State.cell; }	
	}
	
	void lock_0(){
		text.text = "It's a button lock. You can almost make out where dirty fingerprints were.\n\nPress R to return to roaming your cell.";
		if(Input.GetKeyDown(KeyCode.R)){currentState = State.cell; }						
	}
	
	void cell_mirror(){
		text.text = "You are in a prison cell. There are some dirty sheets on the bed. " +
					"There is a mirror on the wall. The door is locked from the outside. You have a mirror.\n\n" +
					"Press S to look at the sheets. Press M to look in the mirror. Press L to look at the lock";
		if(Input.GetKeyDown(KeyCode.S)){ currentState = State.sheets_1; sheets_1(); }	
		else if(Input.GetKeyDown(KeyCode.M)){ currentState = State.mirror_look; mirror_look(); }			
		if(Input.GetKeyDown(KeyCode.L)){ currentState = State.lock_1; lock_1(); }	
	}
	
	void mirror_look(){
		text.text = "You're ugly.\n\nPress R to return to your self loathing.";
		if(Input.GetKeyDown(KeyCode.R)){currentState = State.cell_mirror; }								
	}
	
	void sheets_1(){
		text.text = "Even in the beautiful silver glass of the mirror, the sheets still look disgusting.\n\nPress R to return to your cell.";
		if(Input.GetKeyDown(KeyCode.R)){currentState = State.cell_mirror; }								
	}
	
	void lock_1(){
		text.text = "You put the mirror through the bars and turn it around. You can see the fingerprints clearly. After a few tries, you press the buttons, and hear a click. " +
					"\n\nPress O to open the cell door, or R to return to your cell";
		if(Input.GetKeyDown(KeyCode.O)){currentState = State.corridor_0; }						
		else if(Input.GetKeyDown(KeyCode.R)){currentState = State.cell_mirror; }								
	}
	
	void corridor_0(){
		text.text = "You step into the hallway. It's dark and dusty, and a dimly-lit lamp flickers on the wall. You can barely barely make out a door in the distance, and what looks to be a janitor's closet to your right."
		+ "\n\nPress F to inspect the floor, S to go up the stairs, or C to inspect the closet";
		
		if(Input.GetKeyDown(KeyCode.F)){currentState = State.floor; }						
		else if(Input.GetKeyDown(KeyCode.S)){currentState = State.stairs_0; }	
		else if(Input.GetKeyDown(KeyCode.C)){currentState = State.closet_0; }						
	}
	
	void floor(){
		text.text = "You see a dusty paperclip on the floor.\n\nPress P to pick it up, or R to return";
		if(Input.GetKeyDown(KeyCode.P)){currentState = State.corridor_1; }						
		else if(Input.GetKeyDown(KeyCode.R)){currentState = State.corridor_0; }
	
	}
	void corridor_1(){
		text.text = "Paperclip in hand, you take another look around.\n\nPress S to inspect the stairs, or C to inspect the closet";
		if(Input.GetKeyDown(KeyCode.S)){currentState = State.stairs_1; }						
		else if(Input.GetKeyDown(KeyCode.C)){currentState = State.closet_1; }
	}
	void stairs_0(){
		text.text = "The door outside is unlocked. You could try your luck.\n\nPress O to open the door and escape, or R to return to the corridor";
		if(Input.GetKeyDown(KeyCode.O)){currentState = State.captured; }						
		else if(Input.GetKeyDown(KeyCode.R)){currentState = State.corridor_0; }
	
	}
	void closet_0(){
		text.text = "A locked janitor's closet. If only you could open it.\n\nPress R to return";
		if(Input.GetKeyDown(KeyCode.R)){currentState = State.corridor_0; }								
	}
	void stairs_1(){
		text.text = "The door outside is unlocked. You could try your luck; maybe this paperclip will help.\n\nPress O to open the door and escape, or R to return to the corridor";
		if(Input.GetKeyDown(KeyCode.O)){currentState = State.captured; }						
		else if(Input.GetKeyDown(KeyCode.R)){currentState = State.corridor_1; }	
	}
	void closet_1(){
		text.text = "You think you might be able to pick the lock with the paperclip you found.\n\nPress L to pick the lock or R to return";
		if(Input.GetKeyDown(KeyCode.L)){currentState = State.closet_2; }						
		else if(Input.GetKeyDown(KeyCode.R)){currentState = State.corridor_1; }	
	}
	void stairs_2(){
		text.text = "You see the door at the top of the stairs ajar.\n\nPress O to open the door and go outside, or R to return";
		if(Input.GetKeyDown(KeyCode.O)){currentState = State.courtyard; }						
		else if(Input.GetKeyDown(KeyCode.R)){currentState = State.corridor_2; }
	}
	void closet_2(){
		text.text = "Inside, you find a dingy janitor's uniform. You think that with good enough acting, this might fool the guards.\n\nPress C to change clothes, or R to return to the corridor";
		if(Input.GetKeyDown(KeyCode.C)){currentState = State.corridor_2; }						
		else if(Input.GetKeyDown(KeyCode.R)){currentState = State.corridor_1; }
	}
	void closet_3(){
		text.text = "The janitor's uniform doesn't fit very well, and it smells of...something.\n\nPress C to change back into your old clothes or R to return";
		if(Input.GetKeyDown(KeyCode.C)){currentState = State.corridor_1; }						
		else if(Input.GetKeyDown(KeyCode.R)){currentState = State.corridor_2; }
	}
	void corridor_2(){
		text.text = "You stand in the corridor donned in your sweet new threads.\n\nPress S to check the stairs, or C to inspect the closet";
		if(Input.GetKeyDown(KeyCode.S)){currentState = State.stairs_2; }						
		else if(Input.GetKeyDown(KeyCode.C)){currentState = State.closet_3; }
	}
	void courtyard(){
		text.text = "Doing your best to play it cool, you open the door and wave to the large guardsman. He salutes you and turns away.\n\nCongratulations! You have escaped! Press P to play again";
		if (Input.GetKeyDown(KeyCode.P)){currentState = State.cell;}
	}
	void captured(){
		text.text = "You slip out the door, and are immediately greeted by a large man with a nightstick. He knocks you unconscious and leads you back to your cell.\n\nPress R to try again";
		if(Input.GetKeyDown(KeyCode.R)){currentState = State.cell; }								
	}
}
