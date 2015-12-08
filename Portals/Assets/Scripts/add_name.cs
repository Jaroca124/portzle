using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class add_name : MonoBehaviour {

    public Texture start;
    public static string username;
    public UnityEngine.UI.InputField input;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        username = input.text;
	}

    void OnGUI()
    {   
        if (GUI.Button(new Rect(Screen.width * .4f, Screen.height * .8f, 70, 70), start))
        {
            change_level("Portals");
        }
    }

    public void change_level(string level_name)
    {
        Application.LoadLevel(level_name);
    }
}
