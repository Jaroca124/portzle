using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScorePosition : MonoBehaviour {

    //public Vector2 screenPosition = new Vector2(0, 0);
    //public Camera dark_camera;
    //Vector3 v3Pos = new Vector3(0.0F, 1.0F, 5F);

    Text text;
    public int score;

    // Use this for initialization
    void Start () {
        text = GetComponent <Text> ();
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        score++;
        text.text = "Score: " + score;
    }
}
