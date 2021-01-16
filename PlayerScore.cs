using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerScore : MonoBehaviour {

	public int points;
	// Use this for initialization
	public PlayerScore(Player player)
	{
		points = player.points;

	}
}
