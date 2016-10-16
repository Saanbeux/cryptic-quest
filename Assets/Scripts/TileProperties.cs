using UnityEngine;
using System.Collections;

public class TileProperties : MonoBehaviour {
	public int tileID = -1;
	public bool occupied = false;
	public bool hasenemy = false;
	public GameObject enemy;
	public void setTileID(int ID) {
		tileID = ID;
		if (ID != 0) 
			occupied = true;
		else
			occupied = false;
	}
}
