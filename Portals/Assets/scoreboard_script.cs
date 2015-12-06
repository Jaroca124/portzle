using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreboard_script : MonoBehaviour {

    public Texture main_menu_button;
    public Texture play_again_button;

    public float native_width = 1920;
    public float native_height = 1080;
    public Text score_text;
    public Text name_text;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        float buttonWidth = Screen.width / 4;
        float buttonHeight = buttonWidth;
        
        score_text.text = UpdateScore.GAME_score.ToString();
        //name_text.text = add_name.player_name.ToString();

        if (GUI.Button(new Rect(Screen.width / 2 + buttonWidth / 2, Screen.height * .8f, buttonWidth, buttonHeight), play_again_button))
        {
            change_level("Portals");
        }
        if (GUI.Button(new Rect(Screen.width / 4 - buttonWidth / 2, Screen.height * .8f, buttonWidth, buttonHeight), main_menu_button))
        {
            change_level("main_menu");
        }
    }

    public void change_level(string level_name)
    {
        Application.LoadLevel(level_name);
    }
}
