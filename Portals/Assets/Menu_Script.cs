using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu_Script : MonoBehaviour {
    public Texture start_texture;
    public Texture instruction_texture;

    // Use this for initialization
    void Start () {
        
	}

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width * .3f, Screen.height * .3f, 100, 100), start_texture))
        {
            Application.LoadLevel("Portals");
        }
        if (GUI.Button(new Rect(Screen.width * .35f, Screen.height * .8f, 75, 75), instruction_texture))
        {
            Application.LoadLevel("instructions");
        }
    }
}

