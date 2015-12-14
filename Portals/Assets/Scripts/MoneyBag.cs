using UnityEngine;
using System.Collections;

public class MoneyBag : MonoBehaviour {

	public AudioClip kaChing;
	public GameObject coin;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter() {
		AudioSource.PlayClipAtPoint (kaChing, transform.position);
		Destroy (this.gameObject);
	}
}
