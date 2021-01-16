using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {

	private Rigidbody rb;
	public bool isTime;
	public int setTime;
	public int lives = 0;


	public float jumpForce = 112f;
	public float groundCheckDistance = 0.3f;
	private bool isGrounded = false;

	public Text TimeText;
	public float TimeStamp;
	public bool UsingTimer = false;

	public GameObject playerDead;
	public int points = 0;
	public string name;
	public string namee="player";
	public  int coinamount = 0;
	public  int livesCounter = 0;


	public Player(string name,int score)
	{
		this.namee = name;
		this.coinamount = score;

	}
	public void set_all(int score)
	{
		this.coinamount = score;
	}

	void Start () {
		rb = GetComponent<Rigidbody> ();
		if (isTime == true) {
			SetTimer (setTime);
		}
	}


	void Update () {
		if (UsingTimer)
			SetUIText ();

		if (Physics.Raycast ((transform.position + Vector3.up * 0.1f), Vector3.down, groundCheckDistance)) {
			isGrounded = true;
		}
		else
		{
			isGrounded = false;	
		}
		if (isGrounded) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				AdjustPositionAndRotation (new Vector3 (0, 0, 0));
				rb.AddForce (new Vector3(0, jumpForce, jumpForce));
			}
			else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				AdjustPositionAndRotation (new Vector3 (0, 180, 0));
				rb.AddForce (new Vector3(0, jumpForce, -jumpForce));
			}
			else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				AdjustPositionAndRotation (new Vector3 (0, -90, 0));
				rb.AddForce (new Vector3(-jumpForce, jumpForce, 0));
			}
			else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				AdjustPositionAndRotation (new Vector3 (0, 90, 0));
				rb.AddForce (new Vector3(jumpForce, jumpForce, 0));
			}
		}
	}

	public void SetTimer(float time)
	{
		if (UsingTimer)
			return;
		TimeStamp = Time.time + time;
		UsingTimer = true;
	}
	public void SetUIText()
	{
		float timeleft = TimeStamp - Time.time;

		if (timeleft <= 0) {

			FinishAction ();
			SceneManager.LoadScene("Game Over");
			return;
		}
		float hours;
		float minutes;
		float secodes;
		float minisecondes;
		GetTimeValues (timeleft, out hours, out minutes, out secodes, out minisecondes);
		if (hours > 0)
			TimeText.text = string.Format ("{0}:{1}", hours, minutes);
		else if(minutes > 0 )
			TimeText.text = string.Format ("{0}:{1}",  minutes,secodes);
		else
			TimeText.text = string.Format ("{0}:{1}", secodes,minisecondes);
	}
	public void GetTimeValues(float time,out float hours,out float minutes,out float seconds,out float miniseconds){

		hours = (int)(time / 3600f);
		minutes = (int)((time - hours * 3600) / 60f);
		seconds = (int)((time - hours * 3600 - minutes * 60));
		miniseconds= (int)((time - hours * 3600 - seconds)*100);

	}
	public void FinishAction()
	{
		Debug.Log ("Boom");
		TimeText.text ="00:00";
		UsingTimer = false;


	}
	void AdjustPositionAndRotation(Vector3 newRotation)
	{
		rb.velocity = Vector3.zero;
		transform.eulerAngles = newRotation;
		transform.position = new Vector3 (transform.position.x, transform.position.y, Mathf.Round (transform.position.z));

	}
	private void OnTrigeerEnter(Collider other)
	{
		if (other.CompareTag ("StepTrigger"))
		{
	
			Destroy (other.gameObject);
		}
		if(other.CompareTag("Obstacle"))
		{
			if (lives >= 0) {
				lives = lives - 1;
			}
			if (lives < 0) {
				SceneManager.LoadScene ("Game Over");
			} 
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag ("Obstacle"))
		{
			

			if (lives >= 0) {
				lives = lives - 1;
			}
			if (lives < 0) {
				SceneManager.LoadScene ("Game Over");
			} 
		}
	}

	private void OnGUI()
	{
		GUI.Label (new Rect (10, 10, 100, 50), "Score: " + points);
		GUI.Label (new Rect (100, 10, 100, 50), "Life:  " + lives);
	}

	public void SavePlayer()
	{
		SaveSystem.SavePlayer (this);
		Debug.Log ("saving");

	}

	public void LoadPlayer()
	{
		SaveSystem.LoadPlayer ();
		//Debug.Log ("saving");
	}

	public void saveScore()
	{
		ScoreBoard.saveScore (this);
		Debug.Log ("score saving");
	}

}