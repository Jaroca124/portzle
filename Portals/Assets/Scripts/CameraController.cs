using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () { 

	}


	void LateUpdate() {
			transform.position = new Vector3(transform.position.x,
		                                 transform.position.y,
		                                 player.transform.position.z + offset.z);
	}

}
