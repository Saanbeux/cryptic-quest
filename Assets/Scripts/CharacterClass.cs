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
		Debug.Log ("X " + posX + " Y " + posY);
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (GameMaster.GM.tileMap [posX, posY + 1].GetComponent<TileProperties> ().tileID == 0) {
				StartCoroutine (Move (new Vector3 (0, 32f / 100f, 0), false, true));
			}
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (GameMaster.GM.tileMap [posX, posY - 1].GetComponent<TileProperties> ().tileID == 0) {
				StartCoroutine (Move (new Vector3 (0, -32f / 100f, 0), false, false));

			}
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if (GameMaster.GM.tileMap [posX-1, posY].GetComponent<TileProperties> ().tileID == 0) {
				StartCoroutine (Move (new Vector3 (-32f / 100f, 0, 0), true,false));

			}
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (GameMaster.GM.tileMap [posX+1, posY].GetComponent<TileProperties> ().tileID == 0) {
				StartCoroutine (Move (new Vector3 (32f / 100f, 0, 0),true,true));
			}
		}
	}
	IEnumerator Move(Vector3 offsetFromCurrent, bool alterRow, bool signPos) {
		if ( isMoving ) yield break; // exit function
		isMoving = true;
		Vector3 from = transform.position;
		Vector3 to = from + offsetFromCurrent;
		for ( float t = 0f; t < 1f; t += Time.deltaTime * speed ) {
			transform.position = Vector3.Lerp(from,to,t);
			yield return null;
		}
		transform.position = to;
		if (alterRow) {
			if (signPos)
				posX++;
			else
				posX--;
		} else {
			if (signPos)
				posY++;
			else
				posY--;
		}
		isMoving = false;
	}
		/*if(Input.GetKeyDown(KeyCode.UpArrow) && posY == stepTargetY) //Can only move after previous move is finished
		{
			stepTargetY = (posY*32)/100f; //or whatever number you want
		}

		if(posY < stepTargetY){
			Mathf.Lerp (posY, stepTargetY, 32f * Time.deltaTime);
		}
				//Repeat for other directions
		playerPos = new Vector2((posX*32)/100f, (posY*32)/100f);
		transform.position = playerPos;*/

		//Movements
		/*if (Input.GetKey (KeyCode.RightArrow)) 
		{
			new Vector2 (32 / 100f, 0);
		}

		else if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			transform.Translate(Vector2.left * speed * Time.deltaTime);
		}
		else if (Input.GetKey (KeyCode.UpArrow)) 
		{
			transform.Translate(Vector2.up * speed * Time.deltaTime);
		}
		else if (Input.GetKey (KeyCode.DownArrow)) 
		{
			transform.Translate(Vector2.down * speed * Time.deltaTime);
		//}
		//transform.Translate(vect2D * 32 * Time.deltaTime)*/


		//Set bool( "Condition" , value)
		/*if(Input.GetKey (KeyCode.LeftArrow)){
			animation.SetBool("StartWL", true);


		}

		else{
			animation.SetBool ("StartWL", false);
		}


		if(Input.GetKey (KeyCode.DownArrow)){
			animation .SetBool("StartWF", true);

		}
		else{
			animation.SetBool ("StartWF", false);
		}

		if(Input.GetKey (KeyCode.RightArrow)){
			animation.SetBool("StartWR", true);
		}
		else{
			animation.SetBool ("StartWR", false);
		}


		if(Input.GetKey (KeyCode.UpArrow)){
			animation.SetBool("StartWU", true);
		}
		else{
			animation.SetBool ("StartWU", false);
		}


		if(Input.GetKey(KeyCode.LeftAlt)){
			animation.SetBool("AttackU", true);
		}
		else{
			animation.SetBool ("AttackU", false);
		}
		if(Input.GetKey (KeyCode.LeftCommand)){
			animation.SetBool("AttackD", true);
		}
		else{
			animation.SetBool ("AttackD", false);
		}


		if(Input.GetKey (KeyCode.RightCommand)){
			animation.SetBool("AttackL", true);
		}
		else{
			animation.SetBool ("AttackL", false);
		}

		if(Input.GetKey (KeyCode.RightAlt)){
			animation.SetBool("AttackR", true);
		}
		else{
			animation.SetBool ("AttackR", false);
		}
	*/
}
