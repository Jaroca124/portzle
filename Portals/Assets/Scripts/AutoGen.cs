using UnityEngine;
using System.Collections;
using System;

public class AutoGen : MonoBehaviour {

	public Transform marbleTransform;
	// public GameObject tileWithPortal;
	public GameObject tile;
	public GameObject portal;
	public GameObject wedgeTile;
	public GameObject holeTile;
	public GameObject darkTile;
	private GameObject wallTile;

	public GameObject portals;
	public GameObject surfaces;


	public GameObject[] tileTypes;
	public System.Random random = new System.Random();


	private double lastMarblePosition = -8;
	private int spawnLocation = 30;
	private int lastSpawned = -100;

	// Use this for initialization
	void Start () {
		marbleTransform = GameObject.Find("marble").transform;
		tile = GameObject.Find("Tile");
		darkTile = GameObject.Find("DarkTile");

		portal = GameObject.Find("Portal");
		wedgeTile = GameObject.Find("WedgeTile");
		holeTile = GameObject.Find ("HoleTile");
		portals = GameObject.Find ("Portals");
		surfaces = GameObject.Find ("Surfaces");
		wallTile = GameObject.Find ("WallTile");

		// tileWithPortal = GameObject.Find("TileWithPortal");
		tileTypes = new GameObject[] {wedgeTile, holeTile, tile, tile, tile, tile, tile, tile, tile, tile,
			tile, tile, tile, tile, tile, tile, tile, tile, tile, tile, tile, tile, tile, tile, tile, tile, tile, tile};
	}

	void createTileRow(float zPosition) {
		int len = tileTypes.Length;

		if (random.Next (0, 10) == 9) {
			GameObject portal1 = (GameObject) Instantiate(portal, new Vector3(0F, 25.2F, zPosition), Quaternion.identity);
			GameObject portal2 = (GameObject) Instantiate(portal, new Vector3(0F, -25.8F, zPosition), Quaternion.identity);
			portal1.transform.SetParent(portals.transform);
			portal2.transform.SetParent(portals.transform);

		}


		GameObject leftLane = (GameObject) Instantiate(tileTypes[random.Next(0, len)], new Vector3(-4F, 25F, zPosition), Quaternion.identity);
		GameObject middleLane = (GameObject) Instantiate(tileTypes[random.Next(0, len)], new Vector3(0F, 25F, zPosition), Quaternion.identity);
		GameObject rightLane = (GameObject) Instantiate(tileTypes[random.Next(0, len)], new Vector3(4F, 25F, zPosition), Quaternion.identity);
		GameObject bottomleftLane = (GameObject) Instantiate(tileTypes[random.Next(0, len)], new Vector3(-4F, -26F, zPosition), Quaternion.identity);
		GameObject bottommiddleLane = (GameObject) Instantiate(tileTypes[random.Next(0, len)], new Vector3(0F, -26F, zPosition), Quaternion.identity);
		GameObject bottomrightLane = (GameObject) Instantiate(tileTypes[random.Next(0, len)], new Vector3(4F, -26F, zPosition), Quaternion.identity);

		leftLane.transform.SetParent (surfaces.transform);
		middleLane.transform.SetParent (surfaces.transform);
		rightLane.transform.SetParent (surfaces.transform);
		bottomleftLane.transform.SetParent (surfaces.transform);
		bottommiddleLane.transform.SetParent (surfaces.transform);
		bottomrightLane.transform.SetParent (surfaces.transform);

	}
	
	// Update is called once per frame
	void Update () {

		double distanceTraveled = (int)(marbleTransform.position.z) - lastMarblePosition;

		int numTilesToGenerate = (int)(distanceTraveled / 6);
		Debug.Log(distanceTraveled, this);

	
		if(numTilesToGenerate > 0) {
			for(int i = 0; i < numTilesToGenerate; i++) {
				spawnLocation += 6;
				createTileRow((int) spawnLocation);
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
