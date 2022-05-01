using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {	
	public float runSpeed = 2f;
	public float jumpSpeed = 5f;

	private bool isRunning = false;
	private bool isJumping = false;

	private int horizontalDirection = 1;

	// Start is called before the first frame update
	void Start() {
	
	}

	// Update is called once per frame
	void Update()	{		
		if(isRunning) {
			HandleInput();
			Run();
		}	else {
			HandleIdleInput();
		}
	}

	// Checks for collisions
	void OnCollisionEnter2D(Collision2D collision) {		
		if(collision.collider.tag == "Platform") {
			if(isJumping) {
				GetComponent<Animator>().SetBool("isJumping", false);
				isJumping = false;
			}
		} else if(collision.collider.tag == "Wall") {
			if(horizontalDirection == 1) {
				transform.Rotate(0f, -180f, 0f, Space.Self);
				transform.position -= new Vector3(0.01f, 0f, 0f);
				horizontalDirection = -1;
			} else {
				transform.Rotate(0f, 180f, 0f, Space.Self);
				transform.position += new Vector3(0.01f, 0f, 0f);
				horizontalDirection = 1;
			}
		}
	}

	private void HandleInput() {
		if(Input.GetKeyDown("k")) {
			Jump();
		}
	}

	private void HandleIdleInput() {
		if(Input.GetKeyDown("k")) {
			GetComponent<Animator>().SetBool("isRunning", true);
			isRunning = true;
		}
	}

	private void Run() {		
		transform.position += new Vector3(runSpeed * horizontalDirection * Time.deltaTime, 0f);
	}

	private void Jump() {
		if(!isJumping) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
			GetComponent<Animator>().SetBool("isJumping", true);
			isJumping = true;
		}
	}
}
