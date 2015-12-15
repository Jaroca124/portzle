using UnityEngine;
using System.Collections;

public class SnowmanBehavior : MonoBehaviour {
		
		void Start () {
		this.gameObject.transform.Rotate(0, 170, 0);
	
		}
		
		void Update() {
			this.gameObject.transform.localScale = new Vector3(3F, 3F, 3F);
			//this.gameObject.transform.Rotate(0, 200*Time.deltaTime, 0);
		}
		
}

