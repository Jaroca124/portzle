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

		GameObject leftLane = (GameObject) Instantiate(tileTypes[random.Next(0, 3)], new Vector3(-4F, 0F, zPosition), Quaternion.identity);
		GameObject middleLane = (GameObject) Instantiate(tileTypes[random.Next(0, 3)], new Vector3(0F, 0F, zPosition), Quaternion.identity);
		GameObject rightLane = (GameObject) Instantiate(tileTypes[random.Next(0, 3)], new Vector3(4F, 0F, zPosition), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {

		if ((int) marbleTransform.position.z % 6 == 0 && lastSpawned != (int) marbleTransform.position.z) {
			print ("Creating");
			createTileRow((int) marbleTransform.position.z + 42);
			lastSpawned = (int) marbleTransform.position.z;
		}

		/* TODO: fix this
		if (marble.position.z > 18F && !spawned) {
			Transform groundSegment = (Transform) Instantiate(ground, new Vector3(0, 49.3F, 43.6F), Quaternion.identity);
			groundSegment.localScale += new Vector3(0, 0, 1);
			spawned = true;
		}*/
	}
}
