using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10; 
	public float verticalSpeed = 1;
	public float popOutY = 200;

	private Rigidbody rb;
	private SphereCollider playerCollider;
	private GameObject cloneMarble;
	private bool inPortalTransition = false;

	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		playerCollider = GetComponent<SphereCollider> ();
	}

	// Move the marble here
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (moveHorizontal, 0, verticalSpeed);
		rb.AddForce (movement * speed);
	}

	// On portal collision, warp the player from one portal to another
	void Warp() {
		inPortalTransition = true; 

		cloneMarble = (GameObject)Instantiate (this.gameObject, transform.position, Quaternion.identity);
		SphereCollider cloneCollider = cloneMarble.GetComponent<SphereCollider> (); 
		Vector3 newPosition = new Vector3 (transform.position.x, transform.position.y * -1,
		                              transform.position.z);

		transform.position = newPosition;
		Vector3 popOut = new Vector3 (0, popOutY, 0);
		rb.AddForce(popOut);
		Collisions.IgnoreCollisionWithGroup (playerCollider, "Surfaces", true);
		Collisions.IgnoreCollisionWithGroup (playerCollider, "Portals", true);

		cloneCollider.enabled = false;
		Destroy(cloneMarble, 2); 
	}

	void OnTriggerEnter (Collider other) {

		// There will be one collision during the portal transition
		// which is the collision with the portal we are warping to,
		// We ignore this collision ENTRANCE to avoid infinite
		// looping between portals.

		if (inPortalTransition) {
			inPortalTransition = false;
			return;
		} 

		if (other.gameObject.name == "Window") {
			Warp ();
		}
	}

	void OnTriggerExit (Collider other) {
		Collisions.IgnoreCollisionWithGroup (playerCollider, "Surfaces", false);
		Collisions.IgnoreCollisionWithGroup (playerCollider, "Portals", false);
	}

}
