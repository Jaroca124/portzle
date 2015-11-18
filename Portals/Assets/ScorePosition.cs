using UnityEngine;
using System.Collections;

public class ScorePosition : MonoBehaviour {

    public Vector2 screenPosition = new Vector2(0, 0);
    public Camera dark_camera;
    Vector3 v3Pos = new Vector3(0.0F, 1.0F, 5F);

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = dark_camera.ViewportToWorldPoint(v3Pos);
        Debug.Log(transform.position);
        /*
        Vector3 tempScreenPosition = screenPosition;
        tempScreenPosition.z = -Camera.main.transform.position.z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(tempScreenPosition);
        worldPosition.x -= renderer.bounds.size.x * tempScreenPosition.x / Screen.width;
        worldPosition.y += renderer.bounds.size.y * (1 - tempScreenPosition.y / Screen.height);
        transform.position = worldPosition;*/
    }
}
