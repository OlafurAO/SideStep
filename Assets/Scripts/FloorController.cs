using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {
	public GameObject groundPlatform;

	// Start is called before the first frame update
	void Start() {
			
	}

	// Update is called once per frame
	void Update()	{
			
	}

	public void ActivateGroundPlatformCollider() {
		groundPlatform.GetComponent<BoxCollider2D>().enabled = true;
	}

	public void DeActivateGroundPlatformCollider() {
		groundPlatform.GetComponent<BoxCollider2D>().enabled = false;
	}

	public bool IsGroundPlatformColliderActive() {
		return groundPlatform.GetComponent<BoxCollider2D>().enabled;
	}
}
