using UnityEngine;
using System.Collections;

public class scrollMap : MonoBehaviour {
	public Transform[] frames = new Transform[5];
	private Vector2 movement;
	double timer1 = 0.65;
	double timer2 = 0.65;
	bool keypressed = false;
	int sign = 1;
	bool cantouch = true;
	int counter = 1;
	Sprite newSprite;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 theScale = transform.localScale;
		theScale.x *= 2;
		frames [counter-1].localScale = theScale;
		if (Input.GetKeyDown(KeyCode.RightArrow) && cantouch && counter < 10 && counter >= 0) {
			cantouch = false;
			//if(frames[8].position.y < 0)
			for(int i=0; i < 9 ; i++){
				//for(int j=0; j < 10 ; j++){
				//	frames[i].position = new Vector3(0,frames[i].position.y+1,0);
				//	new WaitForSeconds(3.0f);
				//}
				movement = new Vector2(4,0);
				//rigidbody2D.mass = 20;
				//rigidbody2D.gravityScale = 2;
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
				//rigidbody2D.gravityScale = sign*20;
				movement = new Vector2 (sign*3, 0);
				if (timer2 > 0)
					timer2 -= Time.deltaTime;
				else
				{
					movement = new Vector2 (0, 0);
					cantouch = true;
				}
				//rigidbody2D.gravityScale = 0;
			}
			keypressed = true;
		}
		
		if (Input.GetKeyDown(KeyCode.LeftArrow) && cantouch && counter < 10 && counter > 0) {
			cantouch = false;
			//	if(frames[1].position.y > 0)
			for(int i=0; i < 9 ; i++){
				movement = new Vector2(-4,0);
				//rigidbody2D.mass = 20;
				//rigidbody2D.gravityScale = -2;
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
		//frames [1].localScale = new Vector3 (1,2,3);
	}
}











