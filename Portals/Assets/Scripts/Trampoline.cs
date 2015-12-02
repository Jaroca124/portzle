using UnityEngine;
using System.Collections;

public class Trampoline : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onCollisonEnter(Collider other) {
		Rigidbody rb = other.gameObject.GetComponent<Rigidbody> ();
		float yVelocity = rb.velocity.y;

		if (yVelocity < 0) {
			rb.AddForce (new Vector3(0, -4*yVelocity, 0));
		}
	}
}
