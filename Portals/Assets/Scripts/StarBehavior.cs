using UnityEngine;
using System.Collections;

public class StarBehavior : MonoBehaviour {

	public float smooth = 100.0F;
	public float tiltAngle = 90.0F;
	public float scale = 0.5F;
	void Start () {
		
	}
	void Update() {
		this.gameObject.transform.Rotate(0, 0, 
		                                 200*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		Destroy (this.gameObject);
		//score += 5;
	}
}
