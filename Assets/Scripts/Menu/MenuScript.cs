using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	private GUISkin skin;
	void Start(){
		skin = Resources.Load("GUISkin") as GUISkin;
	}
	void OnGUI()
	{
		const int buttonWidth = 100;
		const int buttonHeight = 50;
		GUI.skin = skin;
		// Determine the button's place on screen
		// Center in X, 2/3 of the height in Y
		Rect buttonRect = new Rect (Screen.width / 2 - (buttonWidth / 2),
		                       (2 * Screen.height / 3) - (buttonHeight / 2 + 20),
		                       buttonWidth,
		                       buttonHeight);
		Rect exitButtonRect = new Rect (Screen.width / 2 - (buttonWidth / 2),
		                               (2 * Screen.height / 3) - (buttonHeight / 2 -35),
		                               buttonWidth,
		                               buttonHeight);
		Rect soundButtonRect = new Rect (40, 250, 50, 50);

		// Draw a button to start the game
		if(GUI.Button(buttonRect,"Start!"))
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			Application.LoadLevel("Characters");
		}
		if(GUI.Button(exitButtonRect,"Exit"))
		{
		//exit
		}
		if (GUI.Button (soundButtonRect, "sound")) {
		//sound on or off
		}
	}
}
