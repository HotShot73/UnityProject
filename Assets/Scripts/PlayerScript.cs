using UnityEngine;
using System.Collections;


public static class Coin{
	private static int numberOfCoins = 0;
	private static int mana = 0;
	public static void setNumberOfCoins(int coinNum)
	{
		setMana (mana+coinNum - numberOfCoins); 
		numberOfCoins = coinNum;
	}
	public static int getNumberOfCoins()
	{
		return numberOfCoins;
	}
	public static void setMana(int m)
	{
		mana = m;
	}
	public static int getMana()
	{
		return mana;
	}
}
public static class PowerUp{
	private static bool use = false;
	public static void setUse(bool b)
	{
		use = b;
	}
	public static bool getUse()
	{
		return use;
	}

}
public class PlayerScript : MonoBehaviour {

	//private float ySpeed=0;

	//void Start(){
//		StartCoroutine();
	public static PlayerScript Instance;
	//}
	private int numberOfJumps=0;
	public bool isPowerUp=false;
	private float myTimer = 3;
	private float myTimer2=.5f;
	private float powerUpTimer;
	private bool isKilled = false;
	private bool isItSpace = true;
	private Vector2 movement;
	public ParticleSystem fireEffect;
	public ParticleSystem landEffenct;
	public ParticleSystem smokeEffect;
	public AudioClip jump;
	public AudioClip coin;
	public AudioClip amooYadegarPowerUp;
	public AudioClip naneGhamarPowerUp;
	public AudioClip familPowerUp;
	public AudioClip babaEPowerUp;
	public AudioClip turtlePowerUp;
	public AudioClip jimboPowerUp;
	public AudioClip gonjishk;
	private BuildingScript myBuilding;
	private float yPosition;
	private int powerUpBar=0;
	private Animator animator;
	private bool powerUpTimeIsFinished=false;
	private float barDisplay = 0;
	private Vector2 pos = new Vector2(20,40);
	private Vector2 size = new Vector2(60,20);
	private Texture2D progressBarEmpty;
	private Texture2D progressBarFull;
	private GUISkin skin;
	private int playerNumber = 0;
	public Transform skandar;
	private bool naneSkandarPowerUP=false;
	public static bool BabaEPowerUp=false;
	private bool babaEPower;
//	private Coin coins;

	void Start()
	{
//		coin = new Coin();
		isPowerUp = false;
		// Load a skin for the buttons
		//skin = Resources.Load("GUISkin1") as GUISkin;
		playerNumber = ApplicationModel.currentPlayer;

	}

	void Awake()
	{

		
		// Get the animator
		animator = GetComponent<Animator> ();
	}
	//private int coin;
	void Update () {
		int random;
		switch (playerNumber) {
		case 0:		//khers

			if (Input.GetKeyDown(KeyCode.Space) && !isKilled &&!isPowerUp) {
				isItSpace=true;
			animator.SetBool("isJump",true);
				if(numberOfJumps==0 && !isKilled){
					//AmooSoundScript.Instance.NaveAmooYadegarPowerUpSound();
					audio.clip=jump;
					audio.Play();
					numberOfJumps=1;
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					myBuilding.gameObject.collider2D.isTrigger=true;
					//this.gameObject.animation.Stop();
					
				}
				else
				if(numberOfJumps<2 &&!isKilled){
					audio.clip=jump;
					audio.Play();
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					numberOfJumps++;
				}
			}
			if (Input.GetKeyDown (KeyCode.A) && powerUpBar>=10) {
				PowerUp.setUse(true);
				numberOfJumps=0;
				isPowerUp=true;
				instantiate(smokeEffect,new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,0));
				animator.SetBool("isPowerUpped", true);
				powerUpTimeIsFinished=false;
				isItSpace=false;
				powerUpBar=powerUpBar%10;
				powerUpTimer=10;
				movement = new Vector2(0,2);
				myTimer=3;
				audio.Stop();
				//if(!audio.isPlaying)
				audio.clip=amooYadegarPowerUp;
				audio.Play();
				
			}

			if (this.gameObject.transform.position.y>=3f && !isItSpace && !powerUpTimeIsFinished) {
				movement.y = 0;
				rigidbody2D.gravityScale=0;
			}
			if (powerUpTimer > 0 && !isItSpace )
				powerUpTimer -= Time.deltaTime;
			if (powerUpTimer <= 0 && !isItSpace) {
				powerUpTimeIsFinished=true;
				PowerUp.setUse(false);
				rigidbody2D.gravityScale = 1;
				audio.Stop();
				isPowerUp=false;
				animator.SetBool("isPowerUpped", false);
				
			}

			break;
		case 1:		//An Bozorgvar
			if (Input.GetKeyDown(KeyCode.Space) && !isKilled ) {
				BozScript.isPowerUp=false;
				isItSpace=true;
				isPowerUp=false;
				animator.SetBool("isJump",true);
				animator.SetInteger("isPowerUpped",0);
				if(numberOfJumps==0 && !isKilled){
					//AmooSoundScript.Instance.NaveAmooYadegarPowerUpSound();
					audio.clip=jump;
					audio.Play();
					numberOfJumps=1;
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					myBuilding.gameObject.collider2D.isTrigger=true;
					//this.gameObject.animation.Stop();
					
				}
				else
				if(numberOfJumps<2 &&!isKilled){
					audio.clip=jump;
					audio.Play();
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					numberOfJumps++;
				}
			}
			if (Input.GetKeyDown (KeyCode.A) && powerUpBar>=10) {
				BozScript.isPowerUp=true;
				PowerUp.setUse(true);
				isPowerUp=true;
				instantiate(smokeEffect,new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,0));
				random=Random.Range(0,2);
				if(random>=0 && random<1)
					animator.SetInteger("isPowerUpped",1);
				if(random>=1 && random<2)
					animator.SetInteger("isPowerUpped",2);
				animator.SetBool("isJump", false);
				powerUpTimeIsFinished=false;
				isItSpace=false;
				powerUpBar=powerUpBar%10;
				powerUpTimer=1;
				
			}

			if (powerUpTimer > 0 && !isItSpace )
				powerUpTimer -= Time.deltaTime;
			if (powerUpTimer <= 0 && !isItSpace) {
				powerUpTimeIsFinished=true;
				PowerUp.setUse(false);
				BozScript.isPowerUp=false;
				isPowerUp=false;
				animator.SetInteger("isPowerUpped",0);
				
			}
			break;
		case 2:		//babaE

			if (Input.GetKeyDown(KeyCode.Space) && !isKilled) {
				isItSpace=true;
				animator.SetBool("isJump",true);
				if(numberOfJumps==0 && !isKilled){
					//AmooSoundScript.Instance.NaveAmooYadegarPowerUpSound();
					if(!isPowerUp){
					audio.clip=jump;
					audio.Play();
					}
					numberOfJumps=1;
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					myBuilding.gameObject.collider2D.isTrigger=true;
					//this.gameObject.animation.Stop();
					
				}
				else
				if(numberOfJumps<2 &&!isKilled){
					if(!isPowerUp){
					audio.clip=jump;
					audio.Play();
					}
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					numberOfJumps++;
				}
			}
			if(powerUpBar>=15){
				animator.SetBool("isPowerUpped", true);
				//this.gameObject.transform.localScale=new Vector3(1.05f,1.05f,0);
				powerUpBar=0;

				babaEPower=true;
			}
			if (Input.GetKeyDown (KeyCode.A) && babaEPower) {
				babaEPower=false;
				BabaEPowerUp=true;
				myTimer=5;
				isPowerUp=true;
				PowerUp.setUse(true);
				isItSpace=false;
				audio.clip=babaEPowerUp;
				audio.Play();
				//Instantiate(skandar, new Vector3(this.gameObject.transform.position.x+.5f,this.gameObject.transform.position.y,this.gameObject.transform.position.z),new Quaternion(0,0,0,0));
				animator.SetBool("isPowerUpped", false);
				//this.gameObject.transform.localScale=new Vector3(0.8f,0.8f,0);
				//naneSkandarPowerUP=false;
			}
			if (myTimer > 0 && BabaEPowerUp )
				myTimer -= Time.deltaTime;
			if (myTimer <= 0 && BabaEPowerUp) {
				powerUpTimeIsFinished=true;
				//PowerUp.setUse(false);
				BabaEPowerUp=false;
				//isPowerUp=false;
				animator.SetInteger("isPowerUpped",0);
				
			}
			
			break;
			break;
		case 3:		//jimbo
			
			if (Input.GetKeyDown(KeyCode.Space) && !isKilled) {
				isItSpace=true;
				animator.SetBool("isJump",true);
				if(numberOfJumps==0 && !isKilled){
					if(!isPowerUp){
					audio.clip=jump;
					audio.Play();
					}
					numberOfJumps=1;
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					if(isPowerUp)
						numberOfJumps=0;
					
				}
				else
				if(numberOfJumps<2 &&!isKilled){
					if(!isPowerUp){
					audio.clip=jump;
					audio.Play();
					}
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					numberOfJumps++;
					if(isPowerUp){
						numberOfJumps=0;
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.A) && powerUpBar>=10) {
				PowerUp.setUse(true);
				numberOfJumps=0;
				isPowerUp=true;
				animator.SetBool("isPowerUpped", true);
				powerUpTimeIsFinished=false;
				isItSpace=false;
				powerUpBar=powerUpBar%10;
				powerUpTimer=10;
				myTimer=3;
				audio.Stop();
				//if(!audio.isPlaying)
				audio.clip=jimboPowerUp;
				audio.Play();
				
			}
			

			if (powerUpTimer > 0 && !isItSpace )
				powerUpTimer -= Time.deltaTime;
			if (powerUpTimer <= 0 && !isItSpace) {
				powerUpTimeIsFinished=true;
				PowerUp.setUse(false);
				audio.Stop();
				isPowerUp=false;
				animator.SetBool("isPowerUpped", false);
				
			}
			
			break;
		case 4:		//nane
			if (Input.GetKeyDown(KeyCode.Space) && !isKilled ) {
				isItSpace=true;
				animator.SetBool("isJump",true);
				if(numberOfJumps==0 && !isKilled){
					//AmooSoundScript.Instance.NaveAmooYadegarPowerUpSound();
					if(!naneSkandarPowerUP){
					audio.clip=jump;
					audio.Play();
					}
					numberOfJumps=1;
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					myBuilding.gameObject.collider2D.isTrigger=true;
					//this.gameObject.animation.Stop();
					
				}
				else
				if(numberOfJumps<2 &&!isKilled){
					if(!naneSkandarPowerUP){
					audio.clip=jump;
					audio.Play();
					}
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					numberOfJumps++;
				}
			}
			if(powerUpBar>=15){
				animator.SetBool("isPowerUpped", true);
				this.gameObject.transform.localScale=new Vector3(1.05f,1.05f,0);
				powerUpBar=0;
				naneSkandarPowerUP=true;
				audio.clip=naneGhamarPowerUp;
				audio.Play();
				isPowerUp=true;
			}
			if (Input.GetKeyDown (KeyCode.A) && naneSkandarPowerUP) {
				isPowerUp=false;
				PowerUp.setUse(true);
				isItSpace=false;
				Instantiate(skandar, new Vector3(this.gameObject.transform.position.x+.5f,this.gameObject.transform.position.y,this.gameObject.transform.position.z),new Quaternion(0,0,0,0));
				animator.SetBool("isPowerUpped", false);
				this.gameObject.transform.localScale=new Vector3(0.8f,0.8f,0);
				naneSkandarPowerUP=false;
			}
			
			break;
		case 5:		//famildoor
			if (Input.GetKeyDown(KeyCode.Space) && !isKilled ) {
				isItSpace=true;
				animator.SetBool("isJump",true);
				if(numberOfJumps==0 && !isKilled){
					//AmooSoundScript.Instance.NaveAmooYadegarPowerUpSound();
					if(!isPowerUp){
					audio.clip=jump;
						audio.Play();}
					numberOfJumps=1;
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					myBuilding.gameObject.collider2D.isTrigger=true;
					//this.gameObject.animation.Stop();
					
				}
				else
				if(numberOfJumps<2 &&!isKilled){
					if(!isPowerUp){
					audio.clip=jump;
						audio.Play();}
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					numberOfJumps++;
				}
			}
			if (Input.GetKeyDown (KeyCode.A) && powerUpBar>=10) {
				PowerUp.setUse(true);
				isPowerUp=true;
				//instantiate(smokeEffect,new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,0));
				//	animator.SetBool("isPowerUpped", true);
				powerUpTimeIsFinished=false;
				isItSpace=false;
				powerUpBar=powerUpBar%10;
				powerUpTimer=8;
				//	movement = new Vector2(0,2);
				myTimer=5;
				audio.Stop();
				//if(!audio.isPlaying)
				audio.clip=familPowerUp;
				audio.Play();
				
			}
			

			break;
		case 6:		//gonjishk
			
			if (Input.GetKeyDown(KeyCode.Space) && !isKilled) {
				isItSpace=true;
				animator.SetBool("isJump",true);
				if(numberOfJumps==0 && !isKilled){
					if(!isPowerUp){
						audio.clip=jump;
						audio.Play();
					}
					numberOfJumps=1;
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					if(isPowerUp)
						numberOfJumps=0;
					
				}
				else
				if(numberOfJumps<2 &&!isKilled){
					if(!isPowerUp){
						audio.clip=jump;
						audio.Play();
					}
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					numberOfJumps++;
					if(isPowerUp){
						numberOfJumps=0;
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.A) && powerUpBar>=10) {
				PowerUp.setUse(true);
				numberOfJumps=0;
				isPowerUp=true;
				animator.SetBool("isPowerUpped", true);
				powerUpTimeIsFinished=false;
				isItSpace=false;
				powerUpBar=powerUpBar%10;
				powerUpTimer=10;
				myTimer=3;
				audio.Stop();
				//if(!audio.isPlaying)
				audio.clip=gonjishk;
				audio.Play();
				
			}
			
			
			if (powerUpTimer > 0 && !isItSpace )
				powerUpTimer -= Time.deltaTime;
			if (powerUpTimer <= 0 && !isItSpace) {
				powerUpTimeIsFinished=true;
				PowerUp.setUse(false);
				audio.Stop();
				isPowerUp=false;
				animator.SetBool("isPowerUpped", false);
				
			}
			
			break;
		case 7:		//turtle
			if (Input.GetKeyDown(KeyCode.Space) && !isKilled &&!isPowerUp) {
				isItSpace=true;
				isPowerUp=false;
				animator.SetBool("isJump",true);
				if(numberOfJumps==0 && !isKilled){
					//AmooSoundScript.Instance.NaveAmooYadegarPowerUpSound();
					audio.clip=jump;
					audio.Play();
					numberOfJumps=1;
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					myBuilding.gameObject.collider2D.isTrigger=true;
					//this.gameObject.animation.Stop();
					
				}
				else
				if(numberOfJumps<2 &&!isKilled){
					audio.clip=jump;
					audio.Play();
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					numberOfJumps++;
				}
			}
			if (Input.GetKeyDown (KeyCode.A) && powerUpBar>=10) {
				PowerUp.setUse(true);
				this.gameObject.transform.localScale= new Vector3(.8f,.8f,0);
				this.gameObject.GetComponent<BoxCollider2D>().size=new Vector2(3,2);
				this.gameObject.GetComponent<BoxCollider2D>().center= new Vector2(0,5f);
				isPowerUp=true;
				instantiate(smokeEffect,new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,0));
				animator.SetBool("isPowerUpped", true);
				powerUpTimeIsFinished=false;
				isItSpace=false;
				powerUpBar=powerUpBar%10;
				powerUpTimer=10;
				movement = new Vector2(0,2);
				myTimer=3;
				audio.Stop();
				//if(!audio.isPlaying)
				audio.clip=turtlePowerUp;
				audio.Play();
				
			}
			
			if (this.gameObject.transform.position.y>=3f && !isItSpace && !powerUpTimeIsFinished) {
				movement.y = 0;
				rigidbody2D.gravityScale=0;
			}
			if (powerUpTimer > 0 && !isItSpace )
				powerUpTimer -= Time.deltaTime;
			if (powerUpTimer <= 0 && !isItSpace) {
				powerUpTimeIsFinished=true;
				rigidbody2D.gravityScale = 1;
				audio.Stop();
				isPowerUp=false;
				animator.SetBool("isPowerUpped", false);
				this.gameObject.transform.localScale=new Vector3(.2f,.2f,0);
				this.gameObject.GetComponent<BoxCollider2D>().size=new Vector2(5,8);
				this.gameObject.GetComponent<BoxCollider2D>().center= new Vector2(0,0);
				
			}
			break;
		case 8: //Roadrunner
			if (Input.GetKeyDown(KeyCode.Space) && !isKilled &&!isPowerUp) {
				isItSpace=true;
				animator.SetBool("isJump",true);
				if(numberOfJumps==0 && !isKilled){
					//AmooSoundScript.Instance.NaveAmooYadegarPowerUpSound();
					audio.clip=jump;
					audio.Play();
					numberOfJumps=1;
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					myBuilding.gameObject.collider2D.isTrigger=true;
					//this.gameObject.animation.Stop();
					
				}
				else
				if(numberOfJumps<2 &&!isKilled){
					audio.clip=jump;
					audio.Play();
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					numberOfJumps++;
				}
			}


			break;
		case 9: //palangsoorati
		
			if (Input.GetKeyDown(KeyCode.Space) && !isKilled &&!isPowerUp) {
				isItSpace=true;
				animator.SetBool("isJump",true);
				if(numberOfJumps==0 && !isKilled){
					//AmooSoundScript.Instance.NaveAmooYadegarPowerUpSound();
					audio.clip=jump;
					audio.Play();
					numberOfJumps=1;
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					myBuilding.gameObject.collider2D.isTrigger=true;
					//this.gameObject.animation.Stop();
					
				}
				else
				if(numberOfJumps<2 &&!isKilled){
					audio.clip=jump;
					audio.Play();
					rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
					numberOfJumps++;
				}
			}
			
			
			break;
		}
		barDisplay = Coin.getNumberOfCoins ()*0.1f;
	//	if (isKilled)
	//		myTimer2 -= Time.deltaTime;
	//	if (myTimer2 <= 0)
	//		Destroy (this.gameObject);
		if (!renderer.IsVisibleFrom(Camera.main) && !isPowerUp) {
			Destroy(this.gameObject);
		}
	//	if (Input.GetKeyDown (KeyCode.B)) {
		//	for(int i=0;i<Coins.num;i++){
		//		Coins.coinPool[i].transform.position= new Vector3(0,2,0);
		//	}
	//	}
		PowerUpSong.isItPowerUp=isPowerUp;

//		if (transform.position.y.Equals(270)) {
//			movement= new Vector2(0,0);
//		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider){
		isKilled = false;
		myTimer2 = 1;
		Tigh myTigh = otherCollider.gameObject.GetComponent<Tigh> ();
		CoinScript myCoin = otherCollider.gameObject.GetComponent<CoinScript> ();
		BombScript myBomb = otherCollider.gameObject.GetComponent<BombScript> ();
		myBuilding = otherCollider.gameObject.GetComponent<BuildingScript> ();
		EnemyScript bat = otherCollider.gameObject.GetComponent<EnemyScript> ();
		if (myTigh != null) {
				if (isPowerUp) {
					Destroy (myTigh.gameObject);
					return;
				}
				Destroy (this.gameObject);
				//transform.Rotate(90,0,0,Space.Self);
				//	Destroy(myTigh.gameObject);
			}

			if (myCoin != null) {
			Coin.setNumberOfCoins(Coin.getNumberOfCoins()+1);
				this.powerUpBar++;
				if (!isPowerUp ) {
					audio.clip = coin;
					audio.Play ();
				}
				Destroy (myCoin.gameObject);
			}
			
			if (bat != null) {
				if (isPowerUp) {
					Destroy (bat.gameObject);
					return;
				}
				//Destroy (this.gameObject);
			}
		}
	void OnCollisionEnter2D(Collision2D coll){
		//myBuilding = otherCollider.gameObject.GetComponent<BuildingScript> ();
		if (coll.gameObject.tag=="Ground") {
			
			animator.SetBool ("isJump", false);
			
			//	animator.SetBool ("isPowerUpped", false);

			yPosition = this.gameObject.transform.position.y;
			if(numberOfJumps>0)
			instantiate (landEffenct, new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y - 0.9f, 0));
			numberOfJumps = 0;
			myBuilding.gameObject.collider2D.isTrigger = false;
		}
	}

	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate(
			prefab,
			position,
			Quaternion.identity
			) as ParticleSystem;
		
		// Make sure it will be destroyed
		Destroy(
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
			);
		
		return newParticleSystem;
	}
	//void OnGUI(){
	//	GUI.skin = skin;
		//GUI.Label (new Rect (0, 0, Screen.width, Screen.height), score.ToString ());
	//	GUI.Label (new Rect (500, 10, Screen.width, Screen.height), Coin.getNumberOfCoins().ToString());
	//	GUI.BeginGroup (new Rect (pos.x, pos.y, size.x, size.y));
		//GUI.Box (new Rect (0,0, size.x, size.y),progressBarEmpty);

		// draw the filled-in part:
		//GUI.BeginGroup (new Rect (0, 0, size.x * barDisplay, size.y));

		//GUI.Box (new Rect (0,0, size.x, size.y),progressBarFull);
		//GUI.Box(
		//GUI.EndGroup ();
		
		//GUI.EndGroup ();
		
	//}
	void FixedUpdate(){

		if (!isItSpace && !powerUpTimeIsFinished && (playerNumber==0 || playerNumber==7) ) {
		
			rigidbody2D.velocity = movement;
		
			//yield return WaitForSeconds(3);

		//	movement.y=0;
		//	rigidbody2D.velocity=movement;
		}

		//	if (transform.position.y.Equals(70)) {
	//			movement= new Vector2(0,0);
		//	}
	//	if(Time.time>=tempTime + 3)
	//	movement.y = 0;
	}
	void OnDestroy()
	{
		// Game Over.
		// Add the script to the parent because the current game
		// object is likely going to be destroyed immediately.
		transform.parent.gameObject.AddComponent<GameOverScript>();
	}
}


