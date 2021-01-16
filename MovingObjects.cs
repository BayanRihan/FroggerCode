using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour {
	public float minSpeed, maxSpeed;

	private Rigidbody rb;

	private Vector3 newVelocity;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		newVelocity = new Vector3 (Random.Range (minSpeed, maxSpeed), 0, 0);

	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = newVelocity;

	}
}
