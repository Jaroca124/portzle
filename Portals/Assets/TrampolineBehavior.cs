using UnityEngine;
using System.Collections;

public class TrampolineBehavior : MonoBehaviour {
	private bool bounce;
	public Transform player;
	private float bounceAmount = 20;
	// Use this for initialization
	void Start () {
		bounce = false;
	}
	void OnTriggerEmpty(Collider other){
		bounce = true;
	}


	// Update is called once per frame
	void Update () {
		this.gameObject.transform.localScale = new Vector3(0.5F, 0.5F, 0.5F);
		if (bounce) {
			player.transform.position = new Vector3(player.transform.position.x,
			                                        player.transform.position.y + 5, 
			                                        player.transform.position.z);
			        
			bounce = false;
		}
	
	}	
}
