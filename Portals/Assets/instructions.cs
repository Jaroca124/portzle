using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class instructions : MonoBehaviour
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
        if (GUI.Button(new Rect(Screen.width * .3f, Screen.height * .3f, 100, 100), back_texture))
        {
            Application.LoadLevel("main_menu");
        }
    }
}