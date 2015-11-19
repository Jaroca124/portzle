using UnityEngine;
using System.Collections;
using System;

public class AutoGen : MonoBehaviour {

	public Transform marbleTransform;
	// public GameObject tileWithPortal;
	public GameObject tileRed;
	public GameObject tileGreen;
	public GameObject tileBlue;
	public GameObject[] tileTypes;
	public System.Random random = new System.Random();


	private double lastMarblePosition = -8;
	private int spawnLocation = 30;
	private int lastSpawned = -100;

	// Use this for initialization
	void Start () {
		marbleTransform = GameObject.Find("marble").transform;
		tileBlue = GameObject.Find("TileBlue");
		tileRed = GameObject.Find("RedTile");
		tileGreen = GameObject.Find("TileGreen");
		// tileWithPortal = GameObject.Find("TileWithPortal");
		tileTypes = new GameObject[] {tileRed, tileGreen, tileBlue};
		print (tileBlue);
	}

	void createTileRow(float zPosition) {

		GameObject leftLane = (GameObject) Instantiate(tileTypes[random.Next(0, 3)], new Vector3(-4F, 25F, zPosition), Quaternion.identity);
		GameObject middleLane = (GameObject) Instantiate(tileTypes[random.Next(0, 3)], new Vector3(0F, 25F, zPosition), Quaternion.identity);
		GameObject rightLane = (GameObject) Instantiate(tileTypes[random.Next(0, 3)], new Vector3(4F, 25F, zPosition), Quaternion.identity);
		GameObject bottomleftLane = (GameObject) Instantiate(tileTypes[random.Next(0, 3)], new Vector3(-4F, -25F, zPosition), Quaternion.identity);
		GameObject bottommiddleLane = (GameObject) Instantiate(tileTypes[random.Next(0, 3)], new Vector3(0F, -25F, zPosition), Quaternion.identity);
		GameObject bottomrightLane = (GameObject) Instantiate(tileTypes[random.Next(0, 3)], new Vector3(4F, -25F, zPosition), Quaternion.identity);
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
