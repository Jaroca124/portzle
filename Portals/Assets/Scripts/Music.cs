using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Music : MonoBehaviour {
	public AudioClip theme;
	public AudioSource src;
	// Use this for initialization
	void Start () {
		src.clip = theme;
		src.Play ();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
