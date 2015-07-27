using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour {

	public Transform coinPrefab;
	// Use this for initialization
	private float xPosition=11;
	void Start () {
		InvokeRepeating ("Spawn", 0, 0.7f);
	}
	void Spawn(){
		float i, j;
		i = Random.Range (0, 4);
		j = Random.Range (-2, 0);
		xPosition += i;

		Coins.coinPool[Coins.num]=Instantiate (coinPrefab, new Vector3 (xPosition, j, 0), new Quaternion (0, 0, 0,0)) as GameObject;
		Coins.num++;
	}
	// Update is called once per frame

}
public class Coins : MonoBehaviour{
	public static GameObject[] coinPool = new GameObject[100];
	public static int num=0;
}