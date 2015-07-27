using UnityEngine;
using System.Collections;

public class BombSpawner : MonoBehaviour {

	public Transform bombPrefab;
	// Use this for initialization
	private float xPosition=11;
	void Start () {
		InvokeRepeating ("Spawn", 1, 0.5f);
	}
	void Spawn(){
		float i, j;
		i = Random.Range (0, 4);
		j = Random.Range (-2, 0);
		float k;
		k = Random.Range (0, 10);
		xPosition += i;
		if(k>8)
		Instantiate (bombPrefab, new Vector3 (xPosition, j, 0), new Quaternion (0, 0, 0,0));
	}
}
