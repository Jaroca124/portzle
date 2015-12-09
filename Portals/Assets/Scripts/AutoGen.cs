﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


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

	private static int MAX_ROWS = 20;
	private int drawDistance = 60;
	public BoxCollider[] laneColliders;

	public GameObject portals;
	public GameObject surfaces;
	public GameObject colliders;

	public GameObject[] tileTypes;
	public System.Random random = new System.Random();
	
	private double lastMarblePosition = -8;
	private int spawnLocation = 30;
	private int lastSpawned = -100;

	private int rowsSpawnedSinceCleanup = 0;

	private Queue<GameObject> garbageTiles = new Queue<GameObject>();
	private Queue<GameObject> garbageColliders = new Queue<GameObject>(); 

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
		colliders = GameObject.Find ("Colliders");
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
			garbageTiles.Enqueue(portal1);
			garbageTiles.Enqueue(portal2);
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

				if(rand % 15 == 0 && laneColliders[colliderIndex] != null) {
					garbageColliders.Enqueue(laneColliders[colliderIndex].gameObject);				
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
						laneCollider.gameObject.transform.SetParent (colliders.transform);
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
				garbageTiles.Enqueue(lane);
			}
		}

		rowsSpawnedSinceCleanup++;
	}

	void Cleanup() {
		print ("taking out the trash....");

		BoxCollider bc = garbageColliders.Peek ().GetComponent<BoxCollider>();
		while((bc.bounds.center.z + (bc.bounds.extents.z/2)) < marbleTransform.position.z - 1) {
			print ("DESTROYING COLLIDER");
			Destroy (garbageColliders.Dequeue());
			if(garbageColliders.Count == 0) {
				break;
			}
			bc = garbageColliders.Peek ().GetComponent<BoxCollider>();
		}

		while (garbageTiles.Peek ().transform.position.z <= marbleTransform.position.z - 6) {
			Destroy(garbageTiles.Dequeue());
			if(garbageColliders.Count == 0) {
				break;
			}
		}

		GameObject everything = GameObject.Find("Everything");
		//everything.transform.Translate (new Vector3(0, 0, -rowsSpawnedSinceCleanup*tileLength));
		//spawnLocation -= (int)(rowsSpawnedSinceCleanup * tileLength);
		rowsSpawnedSinceCleanup = 0;
	}

	// Update is called once per frame
	void Update () {
		if (garbageTiles.Count > 0 && garbageColliders.Count > 0) {
			//Cleanup();
		}

		if (marbleTransform.position.z >= spawnLocation - drawDistance) {
			spawnLocation += 6;
			CreateTileRow ((int)spawnLocation);
		}
	}
}
