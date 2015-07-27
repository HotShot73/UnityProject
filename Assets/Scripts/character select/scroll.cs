using UnityEngine;
using System.Collections;

public class scroll : MonoBehaviour {
	public Transform[] frames = new Transform[10];
	public Transform bigFace;
	private Vector2 movement;
	double timer1 = 0.65;
	double timer2 = 0.65;
	bool keypressed = false;
	int sign = 1;
	bool cantouch = true;
	public int counter = 0;
	Sprite newSprite;

/*	void OnGUI()
	{
		const int buttonWidth = 84;
		const int buttonHeight = 60;
		
		// Determine the button's place on screen
		// Center in X, 2/3 of the height in Y
		Rect buttonRect = new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			);
		
		// Draw a button to start the game
		if(GUI.Button(buttonRect,"Start!"))
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			Application.LoadLevel("Stage1");
		}
	}
*/





	// Use this for initialization
	void Start () {
		//yield WaitForSeconds(3);
	}

	// Update is called once per frame
	void Update () {
		//Time.timeScale = 0; //pauses the current scene 
		//Application.LoadLevelAdditive("Game"); //loads your desired other scene
		//Vector3 theScale = transform.localScale;
		//theScale.x *= 2;
		//frames [counter].localScale = theScale;
		if (Input.GetKeyDown (KeyCode.R)) {
			GameObject go = (GameObject)Instantiate(Resources.Load("Player"));
		}	 
		if (Input.GetKeyDown (KeyCode.Space)) {
			ApplicationModel.currentPlayer = counter;
			Application.LoadLevel ("Game");
		}


		if (Input.GetKeyDown(KeyCode.UpArrow) && cantouch && counter < 10 && counter >= 0) {
			cantouch = false;
			//if(frames[8].position.y < 0)
				for(int i=0; i < 9 ; i++){
					//for(int j=0; j < 10 ; j++){
					//	frames[i].position = new Vector3(0,frames[i].position.y+1,0);
					//	new WaitForSeconds(3.0f);
					//}
				movement = new Vector2(0,4);
				rigidbody2D.mass = 20;
				rigidbody2D.gravityScale = 2;
				keypressed = true;
				timer1 = 0.65;
				timer2 = 0.65;
				sign = 1;
				}
			counter++;
		}
		if (keypressed) {
			if (timer1 > 0)	
				timer1 -= Time.deltaTime;
			else {
				rigidbody2D.gravityScale = sign*20;
				//movement = new Vector2 (0, 2);
				if (timer2 > 0)
					timer2 -= Time.deltaTime;
				else
				{
					movement = new Vector2 (0, 0);
					cantouch = true;
				}
				rigidbody2D.gravityScale = 0;
			}
			keypressed = true;
		}

		if (Input.GetKeyDown(KeyCode.DownArrow) && cantouch && counter < 10 && counter > 0) {
			cantouch = false;
		//	if(frames[1].position.y > 0)
			for(int i=0; i < 9 ; i++){
				movement = new Vector2(0,-4);
				rigidbody2D.mass = 20;
				rigidbody2D.gravityScale = -2;
				keypressed = true;
				timer1 = 0.65;
				timer2 = 0.65;
				sign = -1;
				//frames[i].position = new Vector3(0,frames[i].position.y-10,0);
			}
			counter--;
		}
	}
	void FixedUpdate () {
		rigidbody2D.velocity = movement;
	}

}

public class ApplicationModel : MonoBehaviour
{
	static public int currentPlayer = 0;
}


public class PowerUpSong : MonoBehaviour
{
	public static bool isItPowerUp;
}







