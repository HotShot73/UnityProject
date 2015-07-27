using UnityEngine;
using System.Collections;

public class DamageWithTigh : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D otherCollider){
		Tigh myTigh = otherCollider.gameObject.GetComponent<Tigh> ();
		if (myTigh == null) {
			Destroy(gameObject);
			Destroy(myTigh.gameObject);
		}
	}
}
