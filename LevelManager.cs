using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static LevelManager levelManager;


	public Text gameOverText;


	void Awake () {

		levelManager = this;
	}
	

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		Invoke ("ReloadScane" , 2f);
	}
	void ReloadScane()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
