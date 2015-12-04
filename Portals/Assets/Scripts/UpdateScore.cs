using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateScore : MonoBehaviour {

	Text text;
	public int GAME_score;
	// Use this for initialization
	void Start () {
		text = GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		GAME_score++;
		text.text = "Score: " + GAME_score;
	}
}
