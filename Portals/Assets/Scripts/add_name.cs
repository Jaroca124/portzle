using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class add_name : MonoBehaviour {

    public static string username;
    public UnityEngine.UI.InputField input;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        username = input.text;
	}

    public void change_level(string level_name)
    {
        Application.LoadLevel(level_name);
    }
}
