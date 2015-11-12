using UnityEngine;
using System.Collections;

public class AutoGen : MonoBehaviour {

	public Transform ground;
	public Transform marble;
	bool spawned = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		/* TODO: fix this
		if (marble.position.z > 18F && !spawned) {
			Transform groundSegment = (Transform) Instantiate(ground, new Vector3(0, 49.3F, 43.6F), Quaternion.identity);
			groundSegment.localScale += new Vector3(0, 0, 1);
			spawned = true;
		}*/
	}
}
