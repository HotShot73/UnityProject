using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public int score=0;
	private float timer=2;
	private GUISkin skin;
	public AudioClip backgroundSound;
	//private PlayerScript player;
	//private PlayerScript myPlayer;
	private int coins;
	void Start()
	{
		audio.clip = backgroundSound;
		audio.Play ();
		// Load a skin for the buttons
		//GameObject temp= GameObject.Find("player");
		//PlayerScript myPlayer = GetComponent<PlayerScript> ();
		skin = Resources.Load("GUISkin") as GUISkin;
		//coins = myPlayer.numberOfCoins;

		//skin2= Resources.Load("GUISkin") as GUISkin;
	}

	// Use this for initialization
	void OnGUI(){
		GUI.skin = skin;
		GUI.Label (new Rect (0, 0, Screen.width, Screen.height), score.ToString ());
		//GUI.Label (new Rect (500, 10, Screen.width, Screen.height), coins.ToString());

	}
	
	// Update is called once per frame
	void Update () {
		if(audio.isPlaying)
		if (PowerUpSong.isItPowerUp)
			audio.Pause ();
		if (!audio.isPlaying && !PowerUpSong.isItPowerUp)
			audio.Play ();
	//	coins =myPlayer.numberOfCoins ;
		if (timer > 0)
			timer -= Time.deltaTime;
		if (timer <= 0) {
			score++;
			timer=2;
		}
	}
}
