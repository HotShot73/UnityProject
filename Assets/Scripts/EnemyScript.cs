using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);
	private bool hasSpawned=false;
	public Vector2 direction = new Vector2(-1, 0);
	private float walkTime;
	private Vector2 movement;
	private float invisibleTime;
	private bool isHit;
	private Animator animator;
	void Awake(){
		animator = GetComponent<Animator> ();
	}
	// Use this for initialization
	void Start () {
		walkTime = 1.7f;
		invisibleTime = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (ApplicationModel.currentPlayer == 2 && PlayerScript.BabaEPowerUp) {
			animator.SetBool ("babaEPower", true);
			this.gameObject.transform.localScale= new Vector3(.5f,.5f,0);

		} else {
			if(PlayerScript.BabaEPowerUp==false)
				animator.SetBool ("babaEPower", false);
			this.gameObject.transform.localScale= new Vector3(.1f,.1f,0);
		}
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
		if (walkTime > 0)
			walkTime -= Time.deltaTime;
		if(walkTime <=0){
			if(!isHit)
			direction.y*=-1;
			else{
				direction.y=0;
				direction.x=1;
				speed.x=7;
			}
			walkTime=1.7f;
		}
		if (renderer.IsVisibleFrom (Camera.main)&&!hasSpawned)
			hasSpawned = true;
		if (!renderer.IsVisibleFrom (Camera.main)&&hasSpawned)
			Destroy (this.gameObject);
		rigidbody2D.velocity = movement;
	}
//	void FixedUpdate()
	//{
//		rigidbody2D.velocity = movement;
	//}
	void OnCollisionStay2D(Collision2D otherCollider){
		SkandarScript skandar = otherCollider.gameObject.GetComponent<SkandarScript> ();
		BozScript boz= otherCollider.gameObject.GetComponent<BozScript>();
		PlayerScript player = otherCollider.gameObject.GetComponent<PlayerScript> ();
		if (skandar != null) {
			isHit=true;
			direction.y=0;
			direction.x=1;
			speed.x=7;
		//	skandar.gameObject.collider2D.isTrigger=false;
		}
		if (boz != null && BozScript.isPowerUp==true) {
			isHit=true;
			direction.x=1;
			speed.x=7;

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
