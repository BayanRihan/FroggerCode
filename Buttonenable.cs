using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonenable : MonoBehaviour {

	public GameObject ButtonDisiblere;

	public int buttonlvl;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("HighestLvl") >= buttonlvl) {
			ButtonDisiblere.SetActive (false);
		} 
		else if (PlayerPrefs.GetInt ("HighestLvl") < buttonlvl) 
		{
			ButtonDisiblere.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
