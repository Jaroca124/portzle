using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Instructions_Script : MonoBehaviour
{
    public Texture back_texture;

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
        if (GUI.Button(new Rect(Screen.width * .3f, Screen.height * .6f, 70, 70), back_texture))
        {
            change_level("main_menu");
        }
    }

    public void change_level(string level_name)
    {
        Application.LoadLevel(level_name);
    }
}
