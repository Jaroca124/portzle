using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateScore : MonoBehaviour {

	Text text;
	static public int GAME_score;
    private float nextScoreTime;
    private int scorePeriod = 1;
    private int scoreAmount = 1;
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
        if (Time.time > nextScoreTime)
        {
            GAME_score += scoreAmount;
            nextScoreTime += scorePeriod;
            text.text = "Score: " + GAME_score;
        }
	}
}
