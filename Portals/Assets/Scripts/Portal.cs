using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public int toPortalId = 0;
	// Use this for initialization
	void Start () {
       
    }
	
	public Vector3 getToPortalCoords() {
		Transform toPortal = this.gameObject.transform.parent.GetChild(toPortalId);
		return toPortal.position;
	}

	// Update is called once per frame
	void Update () {
	
	}
}