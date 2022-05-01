using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	public GameObject player;
	public List<GameObject> floors;

	// Start is called before the first frame update
	void Start() {
		
	}

	// Update is called once per frame
	void Update()	{
		
	}

	void FixedUpdate() {
		HandleFloorPlatformActivation();
	}

	private void HandleFloorPlatformActivation() {
		foreach(GameObject floor in floors) {
			if(!floor.GetComponent<FloorController>().IsGroundPlatformColliderActive()) {
				if(IsPlayerAboveFloor(floor)) {
					floor.GetComponent<FloorController>().ActivateGroundPlatformCollider();
				}
			} else {
				if(IsPlayerBelowFloor(floor)) {
					floor.GetComponent<FloorController>().DeActivateGroundPlatformCollider();
				}
			}
		}
	}

	private bool IsPlayerAboveFloor(GameObject floor) {
		return player.transform.position.y 
			- player.GetComponent<BoxCollider2D>().bounds.size.y / 2f > floor.transform.position.y;
	}

	private bool IsPlayerBelowFloor(GameObject floor) {
		return player.transform.position.y
			+ player.GetComponent<BoxCollider2D>().bounds.size.y / 2f < floor.transform.position.y;
	}
}
