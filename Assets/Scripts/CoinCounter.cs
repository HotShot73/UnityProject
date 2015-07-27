using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinCounter : MonoBehaviour {
	public Text counter;
	// Use this for initialization
	void Start () {
		counter.text = ""+Coin.getNumberOfCoins();
	}
	
	// Update is called once per frame
	void Update () {
		counter.text = ""+Coin.getNumberOfCoins();
	}
}
