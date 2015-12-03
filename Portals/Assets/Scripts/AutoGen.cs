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
	private GameObject wallTile;
	private GameObject trampolineTile;
	private GameObject rockTile;

	public GameObject portals;
	public GameObject surfaces;


	public GameObject[] tileTypes;
	public System.Random random = new System.Random();


	private double lastMarblePosition = -8;
	private int spawnLocation = 30;
	private int lastSpawned = -100;

	private static float tileWidth = 4f;
	private static float worldXPos = 50f;
	private static float worldYPos = 0f;
	private static float worldHeight = 1f;

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
		float portalXLoc = 2;
		if(Random.Range (0,200) % 10 == 0) {
			portalXLoc = random.Next(-1, 1) * tileWidth + worldXPos;
			GameObject portal1 = (GameObject)Instantiate (portal, 
			                                              new Vector3 (portalXLoc, worldYPos + .5f, zPosition), 
			                                              Quaternion.identity);
			GameObject portal2 = (GameObject)Instantiate (portal, 
			                                              new Vector3 (-portalXLoc, worldYPos + .5f, zPosition), 
			                                              Quaternion.identity);
			portal1.GetComponent<Portal>().toPortalId = 1;
			portal2.GetComponent<Portal>().toPortalId = 0;
			GameObject portalPair = new GameObject();
			portal1.transform.SetParent (portalPair.transform);
			portal2.transform.SetParent (portalPair.transform);
			portalPair.transform.SetParent(portals.transform);
				
		}
		for (int w = -1; w <= 1; w += 2) {
			for (int x = -1; x <= 1; x++) {
				GameObject lane;
				int rand = Random.Range (0, 200);
				if(portalXLoc == worldXPos + x * 4) {
					lane = (GameObject)Instantiate (tile,
					                                new Vector3 (portalXLoc, worldYPos, zPosition), 
					                                Quaternion.identity);
				}
				float tileXPos = (worldXPos * w) + (x * tileWidth);
				if (rand % 15 == 0) {
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
					lane = (GameObject)Instantiate (tile,
					                                new Vector3 (tileXPos, worldYPos, zPosition), 
					                                Quaternion.identity);
				}
				lane.transform.SetParent (surfaces.transform);
			}
		}
	}
	

	// Update is called once per frame
	void Update () {

		double distanceTraveled = (int)(marbleTransform.position.z) - lastMarblePosition;

		int numTilesToGenerate = (int)(distanceTraveled / 6);

		if(numTilesToGenerate > 0) {
			for(int i = 0; i < numTilesToGenerate; i++) {
				spawnLocation += 6;
				CreateTileRow((int) spawnLocation);
				lastSpawned = (int) marbleTransform.position.z;
			}

			double remainder = distanceTraveled - (distanceTraveled/6)*5.5;
			lastMarblePosition = marbleTransform.position.z - remainder;
		}

	}

		/* TODO: fix this
		if (marble.position.z > 18F && !spawned) {
			Transform groundSegment = (Transform) Instantiate(ground, new Vector3(0, 49.3F, 43.6F), Quaternion.identity);
			groundSegment.localScale += new Vector3(0, 0, 1);
			spawned = true;
		}*/
}
