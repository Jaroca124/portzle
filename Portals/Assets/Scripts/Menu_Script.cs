using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu_Script : MonoBehaviour {

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

    public void change_level(string level_name)
    {
        Application.LoadLevel(level_name);
    }
}
