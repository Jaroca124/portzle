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

	}

    void Start () {
		scoretext = GetComponent<Text>();
		GAME_score = 0;
		float xloc = Screen.width/2;
		float yloc = Screen.height - (0.05F * Screen.height);
		scoretext.transform.position = new Vector2 (xloc, yloc);

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
