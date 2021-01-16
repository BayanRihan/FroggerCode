using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerRo : MonoBehaviour {

	public GameObject vehicle;
	public Transform spawnPos;
	public float minSparationTime;
	public float maxSparationTime;

	// Use this for initialization
	private void Start () {

		StartCoroutine (SpawnVehicle ());
	}

	// Update is called once per frame
	private IEnumerator SpawnVehicle() 
	{
		while( true )
		{
			yield return new WaitForSeconds (Random.Range(minSparationTime,maxSparationTime));
			Instantiate (vehicle , spawnPos.position, Quaternion.identity);
		}}
}

