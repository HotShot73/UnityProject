﻿using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour {
	private bool hasSpawned=false;
	void Update(){
		if (renderer.IsVisibleFrom (Camera.main)&&!hasSpawned)
			hasSpawned = true;
		if (!renderer.IsVisibleFrom (Camera.main)&&hasSpawned)
			Destroy (this.gameObject);
	}

}
