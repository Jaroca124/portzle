using UnityEngine;
using System.Collections;

/**
 * Invert camera script for bottom screen.
 */
public class InvertCamera : MonoBehaviour {

	Camera invertedCamera;
	
	void Start() {
		invertedCamera = GetComponent<Camera>();
	}
	
	void OnPreCull() {
		Debug.Log ("fuck yeah we culling", this.gameObject);
		invertedCamera.ResetWorldToCameraMatrix();
		invertedCamera.ResetProjectionMatrix();
		invertedCamera.projectionMatrix = invertedCamera.projectionMatrix * Matrix4x4.Scale(new Vector3(1, -1, 1));
	}
	
	// Set invertCulling to true so we can watch the flipped Objects
	void OnPreRender() {
		GL.invertCulling = true;
	}
	
	// Set invertCulling to false again because we dont want to affect all other cammeras.
	void OnPostRender() {
		GL.invertCulling = false;
	}
}
