using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10;
	public float verticalSpeed = 1;

	private Vector3 portalPosition = new Vector3 (0,0,0);
	private Rigidbody rb;
	private SphereCollider sphereCollider;


	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		sphereCollider = GetComponent<SphereCollider> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		// float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, verticalSpeed);
		rb.AddForce (movement * speed);
	}
	/*
	void Warp ()
	{
		sphereCollider.enabled = true;
		Vector3 newPosition = new Vector3 (portalPosition.x, portalPosition.y + 58, portalPosition.z);
		Vector3 popOut = new Vector3 (0, 100, 0);
		rb.AddForce (popOut);
		rb.MovePosition (newPosition);
	}
	*/
	void OnTriggerEnter (Collider other) {

		Vector3 newPos = new Vector3(transform.position.x, transform.position.y * -1,
		                             transform.position.z + 10);
		Instantiate (this.gameObject, newPos, Quaternion.identity);
		Destroy(this.gameObject);

	}
	
	void OnTriggerExit (Collider other) {
		//if (other.gameObject.name == "Window") {
		//}
	}
}
