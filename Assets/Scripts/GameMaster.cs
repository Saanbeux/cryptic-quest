using UnityEngine;
using System.Collections.Generic;
public class GameMaster : MonoBehaviour 
{
	public static GameMaster GM;
	public int mapMaxWidth = 153;
	public int mapMaxHeight = 153;
	public const int roomDimensions = 9;
	public const int tileSize = 32;
	public int roomCount = 0;
	public List<List<List<int>>> roomList = new List<List<List<int>>>();
	public int totalRooms = 10;
	public GameObject gridSquare;
	public Sprite[] tileSet = new Sprite[11];
	private int[] roomArray = new int[81] {5,7,7,7,7,7,7,7,10,4,0,0,0,0,0,0,0,9,4,0,0,1,1,1,1,0,9,4,0,0,0,0,0,0,0,9,4,0,1,1,1,1,0,0,9,4,0,0,0,0,0,0,0,9,4,0,0,1,1,1,1,0,9,4,0,0,0,0,0,0,0,9,3,6,6,6,6,6,6,6,8};
	private int[] roomArray2 = new int[81] {5,7,7,7,7,7,7,7,10,4,0,0,0,0,0,0,0,9,4,0,1,1,1,1,1,0,9,4,0,0,0,0,0,0,0,9,4,0,1,1,1,1,1,0,9,4,0,1,1,1,1,1,0,9,4,0,0,0,0,0,0,0,9,4,0,0,0,0,0,0,0,9,3,6,6,6,6,6,6,6,8};
	private int[] roomArray3 = new int[81] {5,7,7,7,7,7,7,7,10,4,0,0,0,0,0,0,0,9,4,0,0,1,0,0,0,0,9,4,0,0,0,0,1,1,0,9,4,0,1,1,0,0,0,0,9,4,0,0,0,0,1,0,0,9,4,0,1,0,0,1,1,0,9,4,0,0,0,0,0,0,0,9,3,6,6,6,6,6,6,6,8};
	private int[] roomArray4 = new int[81] {5,7,7,7,7,7,7,7,10,4,0,0,0,0,0,0,0,9,4,0,1,0,0,1,0,0,9,4,0,1,0,0,1,0,0,9,4,0,1,0,1,1,0,0,9,4,0,1,1,0,1,0,0,9,4,0,1,0,0,1,0,0,9,4,0,0,0,0,0,0,0,9,3,6,6,6,6,6,6,6,8};
	private int[] roomArray5 = new int[81] {5,7,7,7,7,7,7,7,10,4,0,0,0,0,0,0,0,9,4,0,0,0,1,0,1,0,9,4,0,0,1,0,1,0,0,9,4,0,0,1,0,1,0,0,9,4,0,0,0,0,1,0,0,9,4,0,1,1,0,0,1,0,9,4,0,0,0,0,0,0,0,9,3,6,6,6,6,6,6,6,8};
	private int[] roomArray6 = new int[81] {5,7,7,7,7,7,7,7,10,4,0,0,0,0,0,0,0,9,4,0,0,0,1,0,0,0,9,4,0,0,1,0,0,1,0,9,4,0,0,0,0,0,0,0,9,4,0,1,0,1,0,0,0,9,4,0,0,0,0,0,1,0,9,4,0,0,0,0,0,0,0,9,3,6,6,6,6,6,6,6,8};
	private int[] roomArray7 = new int[81] {5,7,7,7,7,7,7,7,10,4,0,0,0,0,0,0,0,9,4,0,0,0,0,0,0,0,9,4,0,0,0,0,0,1,0,9,4,0,1,0,0,0,0,0,9,4,0,1,0,1,0,0,0,9,4,0,0,0,0,0,1,0,9,4,0,0,0,0,0,0,0,9,3,6,6,6,6,6,6,6,8};
	private int[] roomArray8 = new int[81] {5,7,7,7,7,7,7,7,10,4,0,0,0,0,0,0,0,9,4,0,0,1,1,0,0,0,9,4,0,0,0,0,0,1,0,9,4,0,1,0,1,0,0,0,9,4,0,0,0,0,1,0,0,9,4,0,1,0,0,0,0,0,9,4,0,0,0,0,0,0,0,9,4,6,6,6,6,6,6,6,8};
	private int[] roomArray9 = new int[81] {5,7,7,7,7,7,7,7,10,4,0,0,0,0,0,0,0,9,4,0,0,0,1,0,0,0,9,4,0,0,0,0,0,1,0,9,4,0,1,0,0,0,0,0,9,4,0,0,0,0,0,0,0,9,4,0,0,1,0,0,1,0,9,4,0,0,0,0,0,0,0,9,3,6,6,6,6,6,6,6,8};
	private int[] roomArray10 = new int[81] {5,7,7,7,7,7,7,7,10,4,0,0,0,0,0,0,0,9,4,0,0,0,0,0,1,0,9,4,0,1,1,0,1,0,0,9,4,0,0,0,0,0,0,0,9,4,0,0,1,0,0,0,0,9,4,0,0,0,0,1,0,0,9,4,0,1,0,0,0,1,0,9,3,6,6,6,6,6,6,6,8};
	private int[] roomArray11 = new int[81] {5,7,7,7,7,7,7,7,10,4,0,0,0,0,0,0,0,9,4,0,0,0,0,0,0,0,9,4,0,0,0,0,0,0,0,9,4,0,0,0,0,0,0,0,9,4,0,0,0,0,0,0,0,9,4,0,0,0,0,0,0,0,9,4,0,0,0,0,0,0,0,9,3,6,6,6,6,6,6,6,8};
	public List<List<List<int>>> roomsHardCoded2 = new List<List<List<int>>>();
	public GameObject[,] tileMap = new GameObject[153,153];
	public GameObject player;
	public GameObject mainplayer;
	public GameObject enemy;
	Transform Map;
	Transform ParentMap;
	void Awake()
	{
		if(GM != null)
			GameObject.Destroy(GM);
		else
			GM = this;
		Map = GameObject.FindGameObjectWithTag ("MapObject").transform;
		ParentMap = GameObject.FindGameObjectWithTag("MapParent").transform;
		DontDestroyOnLoad(this);
	}
	void Start() {
		//(int)45/2f - 9/2f Calculate Center Room Position
		LoadRoomList();
		Debug.Log ("Moyoyoyo");
	}
	void addRoomIDs(int[] arrayToUse) {
		List<List<int>> roomsHardCoded1 = new List<List<int>>();
		for (int i = 0; i < roomDimensions; i++) {
			roomsHardCoded1.Add (new List<int> ());
			for (int j = roomDimensions*i; j < roomDimensions*(i+1); j++) {
				roomsHardCoded1[i].Add(arrayToUse[j]);
			}
		}
		roomsHardCoded2.Add (roomsHardCoded1);
	}
	void LoadRoomList() {
		roomCount = 0;
		addRoomIDs (roomArray);
		addRoomIDs (roomArray2);
		addRoomIDs (roomArray3);
		addRoomIDs (roomArray4);
		addRoomIDs (roomArray5);
		addRoomIDs (roomArray6);
		addRoomIDs (roomArray7);
		addRoomIDs (roomArray8);
		addRoomIDs (roomArray9);
		addRoomIDs (roomArray10);
		addRoomIDs (roomArray11);
		int middlerow = (int) (mapMaxHeight / 2f - roomDimensions / 2f);
		int middlecol = (int) (mapMaxWidth / 2f - roomDimensions / 2f);
		GenerateRoom (roomCount, (int)(Random.Range (0, roomsHardCoded2.Count)), middlerow, middlecol);
		Map.parent = ParentMap;
		int randomRoom = 0;
		while (roomCount < totalRooms && roomList.Count > 0) {
			randomRoom = (int)(Random.Range (0, roomList.Count));
			if (roomList [randomRoom] [1].Count > 0) {
				createRoomPassage (randomRoom);
			}
		}
		int randX = 0;
		int randY = 0;
		int roomRow = 0;
		int roomCol = 0;
		while (true) {
			randomRoom = (int)(Random.Range (0, roomList.Count));
			randX = (int)(Random.Range(1,8));
			randY = (int)(Random.Range(1,8));
			roomRow = roomList [randomRoom] [0] [0];
			roomCol = roomList [randomRoom] [0] [1];
			if (tileMap [roomRow + randX, roomCol + randY].GetComponent<TileProperties> ().tileID == 0) {
				//tileMap [roomRow + randX, roomCol + randY].GetComponent<TileProperties> ().occupied = true;
				break;
			}
		}
		createPlayer (roomRow + randX, roomCol + randY);
		createEnemies ();
	}
	void createEnemies() {
		for (int x = 0; x < roomList.Count; x++) {
			int roomRow = roomList [x] [0] [0];
			int roomCol = roomList [x] [0] [1];
			while (true) {
				int randX = roomRow + (int)(Random.Range(2,7));
				int randY = roomCol + (int)(Random.Range(2,7));
				if (!tileMap [randX,randY].GetComponent<TileProperties> ().occupied) {
					Debug.Log ("RandX" + randX + " RandY" + randY);
					tileMap [randX, randY].GetComponent<TileProperties> ().occupied = true;
					tileMap [randX, randY].GetComponent<TileProperties> ().hasenemy = true;

					GameObject enemy1 = Instantiate (enemy) as GameObject;
					enemy1.transform.position = new Vector2 (((randX) * (tileSize))/100f, ((randY) * (tileSize))/100f);
					tileMap [randX, randY].GetComponent<TileProperties> ().enemy = enemy1;
					//enemy1.GetComponent<CharacterClass> ().posX = randX;
					//enemy1.GetComponent<CharacterClass> ().posY = randY;
					break;
				}
			}
		}
		Debug.Log ("Creating Enemies");
	}
	void createPlayer(int row, int col) {
		mainplayer = Instantiate (player) as GameObject;
		mainplayer.transform.position = new Vector2 (((row) * (tileSize))/100f, ((col) * (tileSize))/100f);
		mainplayer.GetComponent<CharacterClass> ().posX = row;
		mainplayer.GetComponent<CharacterClass> ().posY = col;
		Camera.main.GetComponent<CompleteCameraController> ().setPlayer(mainplayer);

		//Camera.main.transform.position = new Vector2 (((row+tileSize*roomDimensions/2))/100f, ((col+tileSize*roomDimensions)/2)/100f);
		//Camera.main.transform.position = new Vector2 ((row)/100f, (col)/100f);
		//player.transform.position = player.transform.position + Vector3.forward;
	}
	public void destroyEnemy(int row, int col) {
		Debug.Log ("DESTROYING");
		tileMap [row, col].GetComponent<TileProperties> ().hasenemy = false;
		Destroy (tileMap [row, col].GetComponent<TileProperties> ().enemy);
		tileMap [row, col].GetComponent<TileProperties> ().occupied = false;
	}
	void roomDirections(int roomNumber, int row, int col) {
		roomList.Add (new List<List<int>> ());
		roomList [roomNumber].Add (new List<int>());
		roomList [roomNumber].Add (new List<int>());
		roomList [roomNumber][0].Add (row);
		roomList [roomNumber][0].Add (col);
		roomList [roomNumber][1].Add (0);
		roomList [roomNumber][1].Add (1);
		roomList [roomNumber][1].Add (2);
		roomList [roomNumber][1].Add (3);
	}
	void createRoomPassage(int roomNumber) {
		int dir = (int)Random.Range (0, roomList [roomNumber][1].Count);
		int rRow = roomList [roomNumber] [0] [0];
		int rCol = roomList [roomNumber] [0] [1];
		for (int x = 0; x < roomList.Count; x++) {
			if (x != roomNumber) {
				if (dir == 0) {
					if (roomList [x] [0] [0] == rRow && roomList [x] [0] [1] == rCol + roomDimensions) {
						dirRemove (roomNumber, 0);
						dirRemove (x, 2);
						return;
					}
				}
				else if (dir == 1) {
					if (roomList [x] [0] [0] == rRow - roomDimensions && roomList [x] [0] [1] == rCol) {
						dirRemove (roomNumber, 1);
						dirRemove (x, 3);
						return;
					}
				}
				else if (dir == 2) {
					if (roomList [x] [0] [0] == rRow && roomList [x] [0] [1] == rCol - roomDimensions) {
						dirRemove (roomNumber, 2);
						dirRemove (x, 0);
						return;
					}
				}
				else {
					if (roomList [x] [0] [0] == rCol + roomDimensions && roomList [x] [0] [1] == rCol) {
						dirRemove (roomNumber, 3);
						dirRemove (x, 1);
						return;
					}
				}
			}
		}
		List<int> passageRand = new List<int>(7) { 1, 2, 3, 4, 5, 6, 7 };
		int tileChosen = (int)(Random.Range (0, passageRand.Count));
		roomCount++;
		if (dir == 0) {
			if (GenerateRoom (roomCount, (int)(Random.Range (0, roomsHardCoded2.Count)), rRow, rCol + roomDimensions, rRow + passageRand [tileChosen], rCol + roomDimensions)) {
				tileMap [rRow + passageRand [tileChosen], rCol + roomDimensions - 1].GetComponent<TileProperties> ().setTileID(0);
				tileMap [rRow + passageRand [tileChosen], rCol + roomDimensions - 1].GetComponent<SpriteRenderer> ().sprite = tileSet [0];
				dirRemove (roomCount, 2);
			} else {
				roomList.RemoveAt (roomCount);
				roomCount--;
			}
		} else if (dir == 1) {
			if (GenerateRoom (roomCount, (int)(Random.Range (0, roomsHardCoded2.Count - 1)), rRow - roomDimensions, rCol, rRow-1, rCol + passageRand [tileChosen])) {
				tileMap [rRow, rCol + passageRand [tileChosen]].GetComponent<TileProperties> ().setTileID(0);
				tileMap [rRow, rCol + passageRand [tileChosen]].GetComponent<SpriteRenderer> ().sprite = tileSet [0];
				dirRemove (roomCount, 3);
			} else {
				roomList.RemoveAt (roomCount);
				roomCount--;
			}
		} else if (dir == 2) {
			if (GenerateRoom (roomCount, (int)(Random.Range (0, roomsHardCoded2.Count)), rRow, rCol-roomDimensions, rRow + passageRand [tileChosen], rCol-1)) {
				tileMap [rRow + passageRand [tileChosen], rCol].GetComponent<TileProperties> ().setTileID(0);
				tileMap [rRow + passageRand [tileChosen], rCol].GetComponent<SpriteRenderer> ().sprite = tileSet [0];
				dirRemove (roomCount, 0);
			} else {
				roomList.RemoveAt (roomCount);
				roomCount--;
			}
		} else {
			if (GenerateRoom (roomCount, (int)(Random.Range (0, roomsHardCoded2.Count)), rRow + roomDimensions, rCol, rRow + roomDimensions, rCol + passageRand [tileChosen])) {
				tileMap [rRow + roomDimensions-1, rCol + passageRand [tileChosen]].GetComponent<TileProperties> ().setTileID(0);
				tileMap [rRow + roomDimensions-1, rCol + passageRand [tileChosen]].GetComponent<SpriteRenderer> ().sprite = tileSet [0];
				dirRemove (roomCount, 1);
			} else {
				roomList.RemoveAt (roomCount);
				roomCount--;
			}
		}
	}
	bool GenerateRoom(int currentRoom, int roomSelected, int row, int col, int passageRow = -1, int passageCol = -1) {
		roomDirections (currentRoom, row, col); //roomList[currentRoom][row,col][0,1,2,3]
		if (row == -9)
			return false;
		else if (row == mapMaxHeight)
			return false;
		if (col == -9)
			return false;
		else if (col == mapMaxWidth)
			return false;
		if (row == 0) { //
			dirRemove (currentRoom, 2);
		} 
		else if (row == mapMaxHeight-9) {
			dirRemove (currentRoom, 0);
		}
		if (col == 0) {
			dirRemove (currentRoom, 1);
		} 
		else if (col == mapMaxWidth-9) {
			dirRemove (currentRoom, 3);
		}

		for (int x = 0; x < roomDimensions; x++) {
			for (int y = 0; y < roomDimensions; y++) {
				GameObject newGO = Instantiate(gridSquare) as GameObject;
				newGO.AddComponent<SpriteRenderer> ();
				int roomID = roomsHardCoded2 [roomSelected] [x] [y];
				newGO.GetComponent<SpriteRenderer> ().sprite = tileSet[roomID];
				newGO.GetComponent<TileProperties> ().setTileID(roomID);
				newGO.transform.position = new Vector2 (((row + x) * (tileSize))/100f, ((col + y) * (tileSize))/100f);
				tileMap [row + x, col + y] = newGO;
				newGO.transform.parent = Map;
			}
		}
		if (passageRow != -1 && passageCol != -1) {
			tileMap [passageRow, passageCol].GetComponent<TileProperties> ().setTileID(0);
			tileMap [passageRow, passageCol].GetComponent<SpriteRenderer> ().sprite = tileSet [0];
		}
		return true;
	}
	void dirRemove(int currentRoom, int target) {
		int resultForLoop = -1;
		for (int i = 0; i < roomList [currentRoom] [1].Count; i++) {
			if (roomList [currentRoom] [1] [i] == target) {
				resultForLoop = i;
				break;
			}
		}
		if (resultForLoop != -1)
			roomList [currentRoom] [1].RemoveAt (resultForLoop);
	}
}