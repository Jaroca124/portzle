using UnityEngine;
using System.Collections;

public class StarBehavior : MonoBehaviour {

	public float smooth = 100.0F;
	public float tiltAngle = 90.0F;
	public float scale = 0.5F;
	private AudioSource aSource;
	public AudioClip pickupSound;

	void Start () {
	}

	void Awake() {
	}


	void Update() {
		this.gameObject.transform.Rotate(0, 200*Time.deltaTime, 0);
	}

	void OnTriggerEnter(Collider other){

		if (pickupSound) {
			AudioSource.PlayClipAtPoint(pickupSound, transform.position);
		}
        UpdateScore.GAME_score += 10;
        Destroy (this.gameObject);
	}
}
