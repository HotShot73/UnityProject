using UnityEngine;
using System.Collections;

public class GhostScript : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);
	private bool hasSpawned=false;
	public Vector2 direction = new Vector2(-1, 0);
	private float walkTime;
	private Vector2 movement;
	private float invisibleTime;
	private bool isInvise;
	private bool shouldInvise;
	private bool isHit;
	private Animator animator;
	void Awake(){
		animator = GetComponent<Animator> ();
	}
	// Use this for initialization
	void Start () {
		//bool babaEPower=PlayerScript.BabaEPowerUp;

		shouldInvise = true;
		isInvise = false;
		walkTime = 4;
		invisibleTime = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (ApplicationModel.currentPlayer == 2 && PlayerScript.BabaEPowerUp) {
			animator.SetBool ("babaEPower", true);
			shouldInvise=false;
		} else {
			if(PlayerScript.BabaEPowerUp==false)
			animator.SetBool ("babaEPower", false);
		}
		if (!shouldInvise)
			renderer.enabled = true;
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
		if (invisibleTime > 0) {
			invisibleTime-=Time.deltaTime;
		}
		if (invisibleTime <= 0) {
			if(shouldInvise)
			renderer.enabled=isInvise;
			else
				renderer.enabled=true;
			if(isInvise){
				isInvise=false;
			}
			else{
				isInvise=true;
			}
			invisibleTime=2;
		}
		if (walkTime > 0)
			walkTime -= Time.deltaTime;
		if(walkTime <=0){
			if(!isHit)
			direction.x*=-1;
			else{
				direction.x=1;
				speed.x=7;
			}
			walkTime=3;
		}
		if (renderer.IsVisibleFrom (Camera.main)&&!hasSpawned)
			hasSpawned = true;
		if (!renderer.IsVisibleFrom (Camera.main)&&hasSpawned)
			Destroy (this.gameObject);
		rigidbody2D.velocity = movement;

	}
	//void FixedUpdate()
//	{
	//	rigidbody2D.velocity = movement;
//	}
	void OnCollisionStay2D(Collision2D otherCollider){
		SkandarScript skandar = otherCollider.gameObject.GetComponent<SkandarScript> ();
		BozScript boz= otherCollider.gameObject.GetComponent<BozScript>();
		PlayerScript player = otherCollider.gameObject.GetComponent<PlayerScript> ();
		if (skandar != null) {
			isHit=true;
			direction.x=1;
			speed.x=7;
			shouldInvise=false;
			//	skandar.gameObject.collider2D.isTrigger=false;
		}
		if (boz != null && BozScript.isPowerUp==true ) {
			isHit=true;
			direction.x=1;
			speed.x=7;
			shouldInvise=false;
			//	skandar.gameObject.collider2D.isTrigger=false;
		}
		if (player != null && ApplicationModel.currentPlayer == 2 && PlayerScript.BabaEPowerUp) {
			player.gameObject.rigidbody2D.velocity=new Vector2(1,0);
			direction.x=1;
			speed.x=7;
			Destroy(this.gameObject);
		}
		
	}
}
