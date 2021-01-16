  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData :MonoBehaviour
{
    public string level;
    public string playerName;

    public int points;
   // public int score ;
   // public int lifes ;
   // public int shileds ;

    public float[] position;
    public PlayerData(Player player)
    {
		points = player.points;
        //score = player.score;
       // lifes = player.lifes;
      //  shileds = player.shileds;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
