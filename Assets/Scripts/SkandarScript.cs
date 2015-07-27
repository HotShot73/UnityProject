using UnityEngine;
using System.Collections;

public class SkandarScript : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);

	public Vector2 direction = new Vector2(-1, 0);
	
	private Vector2 movement;
	
	void Update()
	{
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
		this.gameObject.transform.Rotate (0, 0, -1);
		if (!renderer.IsVisibleFrom (Camera.main))
			Destroy (this.gameObject);
	}
	
	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
	}
	void OnTriggerEnter2D(Collider2D otherCollider){
		BuildingScript myBuilding = otherCollider.gameObject.GetComponent<BuildingScript>();
		Tigh myTigh = otherCollider.gameObject.GetComponent<Tigh>();
		EnemyScript bat = otherCollider.gameObject.GetComponent<EnemyScript>();
		if (myBuilding != null)
			Destroy (this.gameObject);
		if (myTigh != null) {
			Destroy (myTigh.gameObject);
			Destroy (this.gameObject);
		}
		if (bat != null) {
			Destroy (bat.gameObject);
			Destroy (this.gameObject);
		}
	}
}
