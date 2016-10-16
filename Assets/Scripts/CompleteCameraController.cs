using UnityEngine;
using System.Collections;

public class CompleteCameraController : MonoBehaviour {

	private GameObject player;       //Public variable to store a reference to the player game object


	private Vector3 offset;         //Private variable to store the offset distance between the player and camera
	private bool didOffset = false;

	// LateUpdate is called after Update each frame
	void LateUpdate () 
	{
		if (player == null) {
			return;
		}
		if (!didOffset) {
			Debug.Log ("RUNNING");
			//offset = transform.position - player.transform.position;
			didOffset = true;
		}
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10) /*+ offset*/;
	}
	public void setPlayer(GameObject p) {
		player = p;
	}
}