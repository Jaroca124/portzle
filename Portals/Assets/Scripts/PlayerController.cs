using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

	private static float MAX_VELOCITY = 20;
	public float speed = 5; 
	public float counter = -100;
	public float popOutY = 200;
	public Rigidbody rb;


	private SphereCollider playerCollider;
	private GameObject cloneMarble;
	private bool inPortalTransition = false;

	public GameObject darkCamera, lightCamera;
	
	public bool darkTop = true;
	public bool grounded = false;

	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		playerCollider = GetComponent<SphereCollider> ();
		darkCamera = GameObject.Find("Dark Camera");
		lightCamera = GameObject.Find ("Light Camera");

	}

	// Move the marble here
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		bool jump = Input.GetButton ("Jump");

		Vector3 movementVertical = new Vector3 (0, 0, 3);
		Vector3 movementHorizontal = new Vector3 (moveHorizontal, 0, 0);
		
		if (rb.velocity.z < MAX_VELOCITY) {
			rb.AddForce (movementVertical * speed);
		}

		rb.AddForce (movementHorizontal * speed);

		if (jump && grounded) {
			rb.AddForce(new Vector3(0, 200, 0));
		}
		
	}

	// On portal collision, warp the player from one portal to another
	void Warp() {
		inPortalTransition = true; 
		GameObject dummy = GameObject.Find ("Dummy"); 
		cloneMarble = (GameObject)Instantiate (dummy, transform.position, Quaternion.identity);
	   	SphereCollider cloneCollider = cloneMarble.GetComponent<SphereCollider> (); 
		Vector3 newPosition = new Vector3 (transform.position.x, transform.position.y * -1 + 1,
		                              transform.position.z);

		transform.position = newPosition;
		Vector3 popOut = new Vector3 (0, popOutY, 0);
		rb.AddForce(popOut);
		Collisions.IgnoreCollisionWithGroup (playerCollider, "Surfaces", true);
		Collisions.IgnoreCollisionWithGroup (playerCollider, "Portals", true);

		cloneCollider.enabled = false;
		Destroy(cloneMarble, 2); 

		/*
		 * Code fragment to flip the cameras.
		 * This works fine but we are deciding 
		 * whether or not to actually flip the cameras
		 * 
		if (darkTop) {
			flipCameras (darkCamera, lightCamera);
			darkTop = false;
		} else {
			flipCameras (lightCamera, darkCamera);
			darkTop = true;
		}
		*/
	}

	void OnCollisionEnter (Collision other) {

		if (other.contacts[0].normal.y > 0) {
			grounded = true;
		}

		if (other.gameObject.name == "Wedge") {
			rb.AddForce(new Vector3(0, 0, 100));
		} else if (other.gameObject.name == "trampoline") {
			rb.AddForce(new Vector3(0, 100, 0));
		}
	}

	void OnCollisionExit (Collision other) {
		grounded = false;
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

		if (other.gameObject.name == "EntranceWindow") {
			Warp ();
		}


	}

	private void flipCameras(GameObject topCamera, GameObject bottomCamera) {
		topCamera.GetComponent<Camera>().rect = new Rect(0f, 0f, 1f, 0.5f);
		bottomCamera.GetComponent<Camera>().rect = new Rect(0f, 0.5f, 1f, 0.5f);
		topCamera.GetComponent<Camera>().ResetProjectionMatrix ();
		bottomCamera.GetComponent<Camera> ().ResetProjectionMatrix ();
		Destroy (bottomCamera.GetComponent ("InvertCamera"));
		topCamera.AddComponent<InvertCamera> ();

	}

	void OnTriggerExit (Collider other) {

		if (other.gameObject.name == "ExitWindow") {
			Collisions.IgnoreCollisionWithGroup (playerCollider, "Surfaces", false);
			if(!inPortalTransition) {
				Collisions.IgnoreCollisionWithGroup (playerCollider, "Portals", false);
			}
		} 
		 
	}

}
