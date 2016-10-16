using UnityEngine;
using System.Collections;

public class CharacterClass : MonoBehaviour {
	public int posX = -1;
	public int posY = -1;

	public Animator animation;
	bool isMoving = false;
	float speed = 5f;

	void Start () {
		animation = GetComponent<Animator> ();
	}
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (!GameMaster.GM.tileMap [posX, posY + 1].GetComponent<TileProperties> ().occupied) {
				StartCoroutine (Move (new Vector3 (0, 32f / 100f, 0), false, true));
			}
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (!GameMaster.GM.tileMap [posX, posY - 1].GetComponent<TileProperties> ().occupied) {
				StartCoroutine (Move (new Vector3 (0, -32f / 100f, 0), false, false));

			}
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if (!GameMaster.GM.tileMap [posX-1, posY].GetComponent<TileProperties> ().occupied) {
				StartCoroutine (Move (new Vector3 (-32f / 100f, 0, 0), true,false));

			}
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (GameMaster.GM.tileMap [posX+1, posY].GetComponent<TileProperties> ().occupied) {
				StartCoroutine (Move (new Vector3 (32f / 100f, 0, 0),true,true));
			}
		}

		//Set bool( "Condition" , value)

		if(Input.GetKey(KeyCode.LeftAlt)){
			animation.SetBool("AttackU", true);
			if (GameMaster.GM.tileMap [posX, posY + 1].GetComponent<TileProperties> ().hasenemy) {
				GameMaster.GM.destroyEnemy (posX, posY + 1);

			}
		}
		else{
			animation.SetBool ("AttackU", false);
		}
		if(Input.GetKey (KeyCode.LeftCommand)){
			animation.SetBool ("AttackD", true);
			if (GameMaster.GM.tileMap [posX, posY - 1].GetComponent<TileProperties> ().hasenemy) {
				GameMaster.GM.destroyEnemy (posX, posY - 1);
			}
		}
		else{
			animation.SetBool ("AttackD", false);
		}


		if(Input.GetKey (KeyCode.RightCommand)){
			animation.SetBool("AttackL", true);
			if (GameMaster.GM.tileMap [posX-1, posY].GetComponent<TileProperties> ().hasenemy) {
				GameMaster.GM.destroyEnemy (posX-1, posY);
			}
		}
		else{
			animation.SetBool ("AttackL", false);
		}

		if(Input.GetKey (KeyCode.RightAlt)){
			animation.SetBool("AttackR", true);
			if (GameMaster.GM.tileMap [posX + 1, posY].GetComponent<TileProperties> ().hasenemy) {
				GameMaster.GM.destroyEnemy (posX+1, posY);
			}
		}
		else{
			animation.SetBool ("AttackR", false);
		}
	}
	IEnumerator Move(Vector3 offsetFromCurrent, bool alterRow, bool signPos) {
		if ( isMoving ) yield break; // exit function
		isMoving = true;

		if (alterRow) {
			if (signPos) {
				animation.SetBool("StartWR", true);
			}
			else {
				animation.SetBool("StartWL", true);
			}
		} else {
			if (signPos) {
				//up
				animation.SetBool("StartWU", true);

			}
			else {
				animation.SetBool("StartWF", true);
			}
		}
		Vector3 from = transform.position;
		Vector3 to = from + offsetFromCurrent;
		for ( float t = 0f; t < 1f; t += Time.deltaTime * speed ) {
			transform.position = Vector3.Lerp(from,to,t);
			yield return null;
		}
		if (alterRow) {
			if (signPos) {
				posX++;
			}
			else {
				posX--;
			}
		} else {
			if (signPos) {
				//up
				posY++;

			}
			else {
				posY--;
			}
		}
		transform.position = to;
		isMoving = false;
	}
}