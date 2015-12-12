using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tilt : MonoBehaviour {

	public static bool tiltOn = true;
	public Toggle tiltObject;

	// Use this for initialization
	void Start () {
		
		tiltObject.onValueChanged.AddListener((value) =>
			{
				changeValue(value);
			});
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeValue(bool value)
	{
		if(value)
		{
			tiltOn = true;
		}else {
			tiltOn = false;
		}

	}

}
