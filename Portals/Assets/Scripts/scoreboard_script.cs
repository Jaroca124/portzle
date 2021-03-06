﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreboard_script : MonoBehaviour {

    public float native_width = 1920;
    public float native_height = 1080;
    public Text score_text;
    public Text name_text;
    public int highscore;
    public UnityEngine.UI.Text highscore_display;
    private int current_score = UpdateScore.GAME_score;

    // Use this for initialization
    void Start()
    {
        highscore = PlayerPrefs.GetInt("High_Score");
        score_text.text = current_score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (current_score > highscore)
        {
            highscore = current_score;
            PlayerPrefs.SetInt("High_Score", current_score);
        }

        highscore_display.text = "High Score: " + highscore;
    }

    void OnGUI()
    {
        float buttonWidth = Screen.width / 4;
        float buttonHeight = buttonWidth;
    }

    public void change_level(string level_name)
    {
        Application.LoadLevel(level_name);
    }
}
