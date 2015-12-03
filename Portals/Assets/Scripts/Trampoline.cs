using UnityEngine;
using System.Collections;

public class Trampoline : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onCollisonEnter(Collision collision) {
		Rigidbody rb = collision.collider.gameObject.GetComponent<Rigidbody> ();
		float yVelocity = rb.velocity.y;
		Debug.Log ("WOOH", this);
		if (yVelocity < 0) {
			rb.AddForce (new Vector3(0, -4*yVelocity, 0));
		}
	}
}
