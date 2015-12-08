using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu_Script : MonoBehaviour {
    public Texture start_texture;
    public Texture instruction_texture;
	public Texture bgTexture;

	public float native_width = 1920;
	public float native_height = 1080;

    // Use this for initialization
    void Start () {
        if (!PlayerPrefs.HasKey("High_Score"))
        {
            PlayerPrefs.SetInt("High_Score", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    
    void OnGUI()
    {	
		float buttonWidth = Screen.width / 4;
		float buttonHeight = buttonWidth;

		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), bgTexture);
		if (GUI.Button(new Rect(Screen.width/2 - buttonWidth/2, Screen.height * .3f, buttonWidth, buttonHeight), start_texture))
        {
            change_level("name_screen");
        }
		if (GUI.Button(new Rect(Screen.width/2 - buttonWidth/2, Screen.height * .6f, buttonWidth, buttonHeight), instruction_texture))
        {
            change_level("instructions");
        }
    }
    
    /*
    void hide_button(Button but, bool isHidden)
    {
        if (isHidden)
        {
            but.enabled = false;
            but.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
            but.GetComponentInChildren<Text>().color = Color.clear;
        }
        else
        {
            but.enabled = true;
            but.GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
            but.GetComponentInChildren<Text>().color = Color.black;
        }
    }*/

    public void change_level(string level_name)
    {
        Application.LoadLevel(level_name);
    }
}
