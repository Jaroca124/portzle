using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateScore : MonoBehaviour {

    private float nextScoreTime;
    private int scorePeriod = 1;
    private int scoreAmount = 1;

    Text text;
	static public int GAME_score;
	// Use this for initialization
	void Start () {
		text = GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.deltaTime > nextScoreTime)
        {
            GAME_score += scoreAmount;
            nextScoreTime += scorePeriod;
            text.text = "Score: " + GAME_score;
        }

    }
}
