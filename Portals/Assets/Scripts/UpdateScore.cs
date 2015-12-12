using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateScore : MonoBehaviour {

	Text text;
	static public int GAME_score;
    // Use this for initialization

    void Awake()
    {
        text = GetComponent<Text>();
        GAME_score = 0;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GAME_score++;
		text.text = "Score: " + GAME_score;
	}
}
