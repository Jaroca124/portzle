using UnityEngine;
using System.Collections;

public class StarBehavior : MonoBehaviour {

	public float smooth = 100.0F;
	public float tiltAngle = 90.0F;
	public float scale = 0.5F;
	public AudioSource aSource;
	public AudioClip pickupSound;

	void Start () {
		aSource = GetComponent<AudioSource>();	
	}

	void Awaker() {
		aSource = GetComponent<AudioSource>();	
	}

	void Update() {
		this.gameObject.transform.Rotate(0, 200*Time.deltaTime, 0);
	}

	void OnTriggerEnter(Collider other){

		if (pickupSound) {
			aSource.PlayOneShot(pickupSound);
		}
		Destroy (this.gameObject);
	}
}
