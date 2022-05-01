using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float runSpeed = 5f;
	public float jumpSpeed = 5f;

	private int horizontalDirection = 1;

	// Start is called before the first frame update
	void Start() {
	
	}

	// Update is called once per frame
	void Update()	{
		HandleInput();
		Run();
	}

	private void HandleInput() {
		if(Input.GetKeyDown("k")) {
			Jump();
		}
	}

	private void Run() {
		if(horizontalDirection == 1) {
			if(transform.position.x >= 2.5f) {
				horizontalDirection = -1;
			}
		} else {
			if(transform.position.x <= -2.5f) {
				horizontalDirection = 1;
			}
		}

		transform.position += new Vector3(runSpeed * horizontalDirection * Time.deltaTime, 0f);
	}

	private void Jump() {

	}
}
