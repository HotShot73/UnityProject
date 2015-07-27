using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {
	
	public Transform platform;
	public Transform ghost;
	public Transform building2;
	public Transform bat;
	public Transform coin;
	private float xPosition=10f;
	private float yPosition;
	private bool wasItTigh=false;
	public int playerNumber = 0;
	public Transform khers;
	public Transform jimbo;
	public Transform turtle;
	public Transform famil;
	public Transform babaE;
	public Transform gonjishk;
	public Transform bozorgvar;
	public Transform nane;
	public Transform palangsoorati;
	public Transform RoadRunner;

	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", 0, 1.5f);
		playerNumber = ApplicationModel.currentPlayer;
		switch (playerNumber) {
		case 0:
			Instantiate (khers, new Vector3 (-10, -2, 0), new Quaternion (0, 0, 0, 0));
			break;
		case 1:
			Instantiate (bozorgvar, new Vector3 (-10, -2, 0), new Quaternion (0, 0, 0, 0));
			break;
		case 2:
			Instantiate (babaE, new Vector3 (-10, -2, 0), new Quaternion (0, 0, 0, 0));
			break;
		case 3:
			Instantiate (jimbo, new Vector3 (-10, -2, 0), new Quaternion (0, 0, 0, 0));
			break;
		case 4:
			Instantiate (nane, new Vector3 (-10, -1.25f, 0), new Quaternion (0, 0, 0, 0));
			break;
		case 5:
			Instantiate (famil, new Vector3 (-10, -2, 0), new Quaternion (0, 0, 0, 0));
			break;
		case 6:
			Instantiate (gonjishk, new Vector3 (-10, -2, 0), new Quaternion (0, 0, 0, 0));
			break;
		case 7:
			Instantiate (turtle, new Vector3 (-10, -2, 0), new Quaternion (0, 0, 0, 0));
			break;
		case 8:
			Instantiate (RoadRunner, new Vector3 (-10, -2, 0), new Quaternion (0, 0, 0, 0));
			break;
		case 9:
			Instantiate (palangsoorati, new Vector3 (-10, -2, 0), new Quaternion (0, 0, 0, 0));
			break;
		}

	}

	
	void Spawn ()
	{
		// Instantiate a random enemy.
		float x;
		float i;
		i = Random.Range (3.7f, 6f);

		xPosition += i;
		x = Random.Range (0f, 6f);
		yPosition = Random.Range (-4.6f, -3.8f);
	//	if (x >= 5) {
	//		if (!wasItTigh){
	//			xPosition += 0.8f;


	//		Instantiate (tigh, new Vector3 (xPosition, -3, 0), new Quaternion (0, 0, 0, 0));
	//		wasItTigh = true;
	//		}
	//	} else {
	//		if (!wasItTigh)
		//		xPosition += 2;
	//		else
		i = Random.Range (0, 7);
		float j,k;
		k=platform.gameObject.transform.localScale.y*3.5f / 8f ;
				xPosition += 0.8f;
		//if(i>=0 && i<1)
			Instantiate (platform, new Vector3 (xPosition, yPosition, 0), new Quaternion (0, 0, 0, 0));
		if (i >= 3 && i < 6f) {
			j = Random.Range (-0.85f, 0.85f);
			Instantiate (ghost, new Vector3 (xPosition + j, yPosition + k+.3f, 0), new Quaternion (0, 0, 0, 0));
		} else
			if (i >= 2 && i < 3f) {
			j=Random.Range(0,2.5f);
			x=Random.Range(-1.2f,1.2f);
			Instantiate(bat,new Vector3(xPosition+x,3.3f,0),new Quaternion(0,0,0,0));
			}

		//	Instantiate (building2, new Vector3 (xPosition, yPosition, 0), new Quaternion (0, 0, 0, 0));
		wasItTigh = false;
		k = -2.1f;
		for (int l=0; l<5; l++) {
			j=Random.Range(0,2);
			i=Random.Range(0,2);
			if(i>=0 && i<1)
				Instantiate(coin,new Vector3(xPosition+k,yPosition+j+3.5f,0),new Quaternion(0,0,0,0));
			k+=.8f;
		}
	//	}
	}
}