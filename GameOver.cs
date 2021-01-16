using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {

	public void ReStar(string mainn)
	{
		SceneManager.LoadScene (mainn);
	}
	public void Menu(string maiu)
	{
		SceneManager.LoadScene (maiu);
	}



}
