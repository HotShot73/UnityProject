using UnityEngine;
using System.Collections;

public class mana : MonoBehaviour {
	
	private static float firstXPosition = 0;
	public Transform manaPic;
	// Use this for initialization
	void Start () {
		firstXPosition = manaPic.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		print(Coin.getMana());
		if(manaPic.position.x < firstXPosition+110)
			manaPic.position = new Vector2 (firstXPosition+12*Coin.getMana(),manaPic.position.y);
		if (PowerUp.getUse ()) {
			PowerUp.setUse(false);
			manaPic.position = new Vector2 (firstXPosition,manaPic.position.y);
			Coin.setMana(0);
		}
		
	}
}