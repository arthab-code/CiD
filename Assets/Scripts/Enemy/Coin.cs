using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	GameObject COIN_ARRAY;

	float angle;
	Vector3 pos;

	// Use this for initialization
	void Awake()
	{

		COIN_ARRAY = GameObject.Find ("coin_array");


		if (GLOBAL.mute == true)
		{
			gameObject.GetComponent<AudioSource>().enabled = false;
		}

	}

	// Update is called once per frame
	void Update () {

		Angle ();
		Move ();

		if (GetComponent<AudioSource>().isPlaying == false){
			
		  Destroy ();

		}

	}

	void Angle()
	{

		pos = COIN_ARRAY.transform.position - transform.position;

		angle = Mathf.Atan2 (pos.y, pos.x);
	    angle = angle * Mathf.Rad2Deg;


	}

	void Move()
	{
		
		Vector2 bufor = transform.position;
		bufor.x += Mathf.Tan (pos.x / pos.y) * 2f;
		bufor.y += Mathf.Cos (pos.y / pos.x) * 2f;
		transform.position = bufor;

	}

	void Destroy()
	{

		if (transform.position.y > ( COIN_ARRAY.transform.position.y - (COIN_ARRAY.GetComponent<SpriteRenderer>().bounds.size.y * 2) ) ) {
			
			GLOBAL.COINS++;
			Destroy (this);
			Destroy (gameObject);

		}

	}

}
