using UnityEngine;
using System.Collections;

public class choose_level : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void load_level(string level_name)
    {
        Application.LoadLevel(level_name);
    }
}
