using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.name == "Marble") {
			GameObject marble = other.gameObject;
			Vector3 newPos = new Vector3(marble.transform.position.x, marble.transform.position.y * -1,
			                             marble.transform.position.z + 5);
			Instantiate (marble, newPos, Quaternion.identity);
		}
	}
	
	void OnTriggerExit (Collider other) {
		if (other.gameObject.name == "Marble") {
			Destroy (other);
		}
	}
}
