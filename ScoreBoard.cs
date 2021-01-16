using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ScoreBoard : MonoBehaviour {

	public static void saveScore(Player player)
	{

			BinaryFormatter format = new BinaryFormatter ();
			string path = Application.persistentDataPath + "/Score.fun";
			FileStream str = new FileStream (path, FileMode.Create);
			PlayerScore data = new PlayerScore (player);

			format.Serialize (str, data);
			str.Close ();


	}
}
