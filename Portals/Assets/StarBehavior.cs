using UnityEngine;
using System.Collections;

public class StarBehavior : MonoBehaviour {

	public float smooth = 100.0F;
	public float tiltAngle = 90.0F;
	public float scale = 0.5F;
	void Start () {
		this.gameObject.transform.Rotate (90, this.gameObject.transform.rotation.y,
		                                 this.gameObject.transform.rotation.z);
		
	}
	void Update() {
		this.gameObject.transform.localScale = new Vector3(0.5F, 0.5F, 0.5F);
		this.gameObject.transform.Rotate(0, 0, 
		                                 200*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		Destroy (this.gameObject);
		//score += 5;
	}
}
