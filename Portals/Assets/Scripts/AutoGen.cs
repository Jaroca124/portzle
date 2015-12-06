using UnityEngine;
using System.Collections;

public class AutoGen : MonoBehaviour {

	public Transform marbleTransform;
	// public GameObject tileWithPortal;
	public GameObject tile;
	public GameObject portal;
	public GameObject wedgeTile;
	public GameObject holeTile;
	public GameObject darkTile;
	public GameObject wallTile;
	public GameObject trampolineTile;
	public GameObject rockTile;

	private int drawDistance = 120;
	public BoxCollider[] laneColliders;


	public GameObject portals;
	public GameObject surfaces;

	public GameObject[] tileTypes;
	public System.Random random = new System.Random();
	
	private double lastMarblePosition = -8;
	private int spawnLocation = 30;
	private int lastSpawned = -100;

	private static float tileWidth = 4f;
	private static float tileLength = 6f;
	private static float worldXPos = 50f;
	private static float worldYPos = 0f;
	private static float worldHeight = 2f;

	// Use this for initialization
	void Start () {
		marbleTransform = GameObject.Find("Marble").transform;
		tile = GameObject.Find("Tile");
		darkTile = GameObject.Find("DarkTile");
		portal = GameObject.Find("Portal");
		wedgeTile = GameObject.Find("WedgeTile");
		holeTile = GameObject.Find ("HoleTile");
		portals = GameObject.Find ("Portals");
		surfaces = GameObject.Find ("Surfaces");
		wallTile = GameObject.Find ("WallTile");
		trampolineTile = GameObject.Find ("TrampolineTile");
		rockTile = GameObject.Find ("RockTile");
	}

	void CreateTileRow(float zPosition) {
		float portalXLoc = -500;
		if(Random.Range (0,200) % 10 == 0) {
			portalXLoc = random.Next(-1, 1) * tileWidth;
			GameObject portal1 = (GameObject)Instantiate (portal, 
			                                              new Vector3 (worldXPos + portalXLoc, worldYPos + .5f, zPosition), 
			                                              Quaternion.identity);
			GameObject portal2 = (GameObject)Instantiate (portal, 
			                                              new Vector3 (-worldXPos + portalXLoc, worldYPos + .5f, zPosition), 
			                                              Quaternion.identity);
			portal1.GetComponent<Portal>().toPortalId = 1;
			portal2.GetComponent<Portal>().toPortalId = 0;
			GameObject portalPair = new GameObject();
			portal1.transform.SetParent (portalPair.transform);
			portal2.transform.SetParent (portalPair.transform);
			portalPair.transform.SetParent(portals.transform);
		}
		for (int world = 0; world < 2; world++) {
			for (int col = 0; col < 3; col++) {
				int x = col - 1; 
		
				GameObject lane;
				GameObject newTile = (world == 0) ? darkTile : tile;
				int rand = Random.Range (0, 200);
				float tileXPos = (worldXPos * (-1 + world*2)) + (x * tileWidth);

				int colliderIndex = world * 3  + col;

				if(rand % 15 == 0) {
					laneColliders[colliderIndex] = null;
				} else {
					if(laneColliders[colliderIndex] == null) {
						GameObject newCollider = (GameObject) GameObject.Instantiate(GameObject.Find("LaneCollider"), 
						                        new Vector3 (tileXPos, worldYPos, zPosition),
						                        Quaternion.identity);
						laneColliders[colliderIndex] = newCollider.GetComponent<BoxCollider>();
					} else {
						BoxCollider laneCollider = laneColliders[colliderIndex];
						laneCollider.center = laneCollider.center + new Vector3(0, 0, .5f);
						laneCollider.extents = laneCollider.extents + new Vector3(0, 0, .5f);
						print ("lane :" + col +  " extents: " + laneCollider.extents);
					}

				}

				if(portalXLoc == tileWidth * x) {
					lane = (GameObject)Instantiate (newTile,
					                                new Vector3 (tileXPos, worldYPos, zPosition), 
					                                Quaternion.identity);
				} else if (rand % 15 == 0) {
					lane = (GameObject)Instantiate (holeTile, 
					                                new Vector3 (tileXPos, worldYPos, zPosition), 
					                                Quaternion.identity);
				}
				else if (rand % 37 == 0) {
					lane = (GameObject)Instantiate (wedgeTile, 
					                                new Vector3 (tileXPos, worldYPos, zPosition),
					                                Quaternion.identity);
				} else if (rand % 23 == 0) {
					lane = (GameObject)Instantiate (trampolineTile, 
					                                new Vector3 (tileXPos, worldYPos, zPosition), 
					                                Quaternion.identity);
				} else if(rand % 29 == 0) {
					lane = (GameObject)Instantiate (rockTile, 
					                                new Vector3 (tileXPos, worldYPos, zPosition), 
					                                Quaternion.identity);
				
				} else {
					lane = (GameObject)Instantiate (newTile,
					                                new Vector3 (tileXPos, worldYPos, zPosition), 
					                                Quaternion.identity);
				}
				lane.transform.SetParent (surfaces.transform);
			}
		}
	}
	

	// Update is called once per frame
	void Update () {
		if (marbleTransform.position.z >= spawnLocation - drawDistance) {
			spawnLocation += 6;
			CreateTileRow ((int)spawnLocation);
		}
	}
}
