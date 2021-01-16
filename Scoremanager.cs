using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoremanager : MonoBehaviour {


	Dictionary <string , Dictionary<string , int >> PlayerScores;

	void Start () {
		SetScore ("quill18", "kills", 9001);

		Debug.Log (GetScore ("quill18", "kills"));
		
	}
	void Init ()
	{
		if (PlayerScores != null)
			return; 

		PlayerScores = new Dictionary<string, Dictionary<string, int>> ();
	}
	
	public int GetScore(string username ,string scoreType)
	{
		Init ();

		if (PlayerScores.ContainsKey (username) == false) {
			return 0;
		}
		if (PlayerScores [username].ContainsKey (scoreType) == false) {
			return 0;
		}
		return PlayerScores [username] [scoreType];
	}

	public void SetScore(string username , string scoreType, int value)
	{
		Init ();

		if (PlayerScores.ContainsKey (username) == false) {
			PlayerScores [username] = new Dictionary<string , int> ();
		}
		PlayerScores [username] [scoreType] = value;
	}

	public void ChangeScore(string username, string scoreType, int amount)
	{
		Init ();
		int currScore = GetScore (username, scoreType);
		SetScore (username, scoreType, currScore + amount);

	}


}
