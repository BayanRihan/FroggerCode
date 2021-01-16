 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

 
public class KeyEnd : MonoBehaviour {

	// Use this for initialization
	public int lvl;
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.name == "Frog") {
			if (PlayerPrefs.GetInt ("HighestLvl" , 0) < lvl)
			{
				PlayerPrefs.SetInt("HighestLvl" , lvl) ;
			}
			SceneManager.LoadScene ("you win");
		}
	}
}
