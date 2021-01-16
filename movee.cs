using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class movee : MonoBehaviour
{

	public float Speed = 28;
	private Rigidbody rigbody;
	public float jump = 1;

	private float direction;

	private int count;

	private int c1 = 0;
	public Text displayText;
	public GameObject Panel;
	public AudioClip audio;
	public GameObject EatBee;
	public GameObject EatBee1;
	public GameObject EatBee2;
	public GameObject EatBee3;
	public GameObject FireBall;
	public GameObject Win;
	public GameObject SoundDragon;
	public GameObject SoundKill;
	public GameObject SoundWater;
	public GameObject Zmoor;
	public GameObject Matoor;


	void Start()
	{

		rigbody = GetComponent<Rigidbody>();//ضروري مشان نقدر نستخدمها لبعدين
		direction = 1;
		count = 0;


	}

	private Collider o;
	void Update()
	{

		Vector3 pos = transform.localPosition;

		if (Input.GetKey(KeyCode.UpArrow))
		{
			AudioSource.PlayClipAtPoint(audio, transform.position);
			rigbody.velocity = Vector3.up * jump;

			rigbody.velocity = new Vector3(0, rigbody.velocity.y, Speed * Time.deltaTime);

			transform.rotation = Quaternion.Slerp(transform.rotation,
				Quaternion.Euler(-98, 180, 0),
				15 * Time.deltaTime);


		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			AudioSource.PlayClipAtPoint(audio, transform.position);
			rigbody.velocity = Vector3.up * jump;
			//rigbody.velocity = new Vector3(0, rigbody.velocity.y, -Speed * Time.deltaTime);

			transform.rotation = Quaternion.Slerp(transform.rotation,
				Quaternion.Euler(-98, 180, -180),
				15 * Time.deltaTime);

		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			AudioSource.PlayClipAtPoint(audio, transform.position);
			rigbody.velocity = Vector3.up * jump;
			rigbody.velocity = new Vector3(-Speed * Time.deltaTime, rigbody.velocity.y, 0);
			transform.rotation = Quaternion.Slerp(transform.rotation,
				Quaternion.Euler(-98, 180, -90),
				15 * Time.deltaTime);



		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			AudioSource.PlayClipAtPoint(audio, transform.position);

			rigbody.velocity = Vector3.up * jump;
			rigbody.velocity = new Vector3(Speed * Time.deltaTime, rigbody.velocity.y, 0);

			transform.rotation = Quaternion.Slerp(transform.rotation,
				Quaternion.Euler(-98, 180, 90),
				15 * Time.deltaTime);


		}




		if (transform.position.z < -1480)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, (float)-1480);
		}

		if (transform.position.z > 370)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, (float)370.0);
			displayText.text = "Win&Score:" + count.ToString();
			Win.SetActive(true);
		}

		if (transform.position.z > 30)
		{
			FireBall.SetActive(true);
		}

		if (transform.position.z >= -860.1411)
		{
			Zmoor.SetActive(true);
			Matoor.SetActive(true);
		}


		if (transform.position.z > 70)
		{
			SoundDragon.SetActive(true);
		}

		if (transform.position.y > 15)
		{
			transform.position = new Vector3(transform.position.x, 10, transform.position.z);
		}

		if (transform.position.y < 0)
		{
			transform.position = new Vector3(transform.position.x, 10, transform.position.z);
		}

		transform.position += rigbody.velocity;

	}


	void OnTriggerEnter(Collider other)
	{
		//Vector3 pos = transform.localPosition;
		if (other.gameObject.tag.Equals("fish"))
		{
			other.gameObject.SetActive(false);//غير ظاهرة
			EatBee.SetActive(true);
			count += 1;
			//c1 += count;
			displayText.text = "Score :" + count.ToString();
		}

		else if (other.gameObject.tag.Equals("fish1"))
		{
			other.gameObject.SetActive(false);//غير ظاهرة
			EatBee1.SetActive(true);
			count += 1;
			//c1 += count;
			displayText.text = "Score :" + count.ToString();
		}
		else if (other.gameObject.tag.Equals("fish2"))
		{
			other.gameObject.SetActive(false);//غير ظاهرة
			EatBee2.SetActive(true);
			count += 1;
			//c1 += count;
			displayText.text = "Score :" + count.ToString();
		}

		else if (other.gameObject.tag.Equals("fish3"))
		{
			other.gameObject.SetActive(false);//غير ظاهرة
			EatBee3.SetActive(true);
			count += 1;
			c1 += count;
			displayText.text = "Score :" + count.ToString();
		}


		//اذا اصطدم بسيارة او دولاب يرجع للاول
		else if (other.gameObject.tag.Equals("myitems"))
		{

			SoundKill.SetActive(true);
			displayText.text = "Lose&Score:" + count.ToString();
			transform.position = new Vector3((float)4.87038, (float)1.889553, (float)-934.1237);
			Panel.SetActive(true);




		}




		else if (other.gameObject.tag.Equals("Window"))
		{
			//AudioSource.PlayClipAtPoint(kill, transform.position);
			SoundKill.SetActive(true);
			displayText.text = "Lose&Score:" + count.ToString();
			transform.position = new Vector3((float)4.87038, (float)1.889553, (float)-934.1237);
			//kill.Play();

			Panel.SetActive(true);
			transform.parent = null;


		}

		//اذا وقع بالمي يرجع للاول
		else  if (other.gameObject.tag.Equals("Water"))
		{
			//AudioSource.PlayClipAtPoint(kill, transform.position);
			SoundWater.SetActive(true);
			SoundKill.SetActive(true);
			displayText.text = "Lose&Score:" + count.ToString();
			Panel.SetActive(true);
			transform.position = new Vector3((float)4.87038, (float)1.889553, (float)-934.1237);
			//kill.Play();
			transform.parent = null;


		}

		else if (other.gameObject.tag.Equals("Fire"))
		{
			//AudioSource.PlayClipAtPoint(kill, transform.position);
			transform.position = new Vector3((float)4.87038, (float)1.889553, (float)-934.1237);
			//kill.Play();
			displayText.text = "Lose&Score:" + count.ToString();
			SoundKill.SetActive(true);
			Panel.SetActive(true);
			transform.parent = null;


		}
	}
	void OnCollisionStay(Collision col)
	{



		if (col.collider.gameObject.tag.Equals("KH"))
		{



			rigbody.transform.parent = col.transform;

		}
		if (col.gameObject.tag.Equals("KHR"))
		{

			rigbody.transform.parent = col.transform;


		}


	}
	void OnCollisionExit(Collision col)
	{
		if (!col.collider.gameObject.tag.Equals("KHR"))
		{
			transform.parent = null;
			//transform.localScale = new Vector3((float)0.4033749, (float)0.3254248, (float)0.6274775);

		}
		if ((!col.gameObject.tag.Equals("KH")))
		{
			transform.parent = null;
			//transform.localScale = new Vector3((float)0.4033749, (float)0.3254248, (float)0.6274775);

		}
	}


}
