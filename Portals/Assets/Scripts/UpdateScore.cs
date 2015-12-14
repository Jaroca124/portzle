using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateScore : MonoBehaviour {

	Text scoretext;
	static public int GAME_score;
    private float nextScoreTime;
    private int scorePeriod = 1;
    private int scoreAmount = 1;
    // Use this for initialization

    void Awake()
    {
		scoretext = GetComponent<Text>();
        GAME_score = 0;
		//xloc = 0.52F * Screen.width;
		//float yloc = 0.3478F * Screen.height;
		//scoretext.transform.position.x = xloc;
		//scoretext.transform.position.y = yloc;
	}

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextScoreTime)
        {
            GAME_score += scoreAmount;
            nextScoreTime += scorePeriod;
            scoretext.text = "Score: " + GAME_score;
        }
	}
}
