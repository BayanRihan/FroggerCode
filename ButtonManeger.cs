using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {
	public void NewGamebt(string NewGameLevel)
	{
		SceneManager.LoadScene (NewGameLevel);
	}
	/*public void ExitGamebt()
	{
		Application.Quit ();
	}*/

}