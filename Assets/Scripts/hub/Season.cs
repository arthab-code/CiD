using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Season : MonoBehaviour {

	float time = 0f;
	float goalTime = 60f;
	int randomDay = 0;
	int countDays = 15;

	bool setDay = true;

	
	// Update is called once per frame
	void Update () {

		time += Time.deltaTime;

		if (setDay == true) {

			RandomDay ();
			Rend ();
			setDay = false;
		}

		if (time > goalTime) {

			NextTime ();

			Rend ();

			time = 0;

		}


		
	}

	void RandomDay()
	{

		randomDay = Random.Range (0, countDays);

	}

	void NextTime()
	{

		if (randomDay != countDays - 1) {

			randomDay++;

		} else {

			randomDay = 0;

		}

	}

	void Rend()
	{
		Sprite spr = GetComponent<Sprite> ();
		SpriteRenderer rend = GetComponent<SpriteRenderer> ();

		switch (randomDay) {

		case 0:

			spr = Resources.Load<Sprite> ("Animation/Background/BG/bg_1");
			rend.sprite = spr;

			break;


		case 1:

			spr = Resources.Load<Sprite> ("Animation/Background/BG/bg_2");
			rend.sprite = spr;

			break;


		case 2:

			spr = Resources.Load<Sprite> ("Animation/Background/BG/bg_3");
			rend.sprite = spr;

			break;


		case 3:

			spr = Resources.Load<Sprite> ("Animation/Background/BG/bg_4");
			rend.sprite = spr;

			break;

		case 4:

			spr = Resources.Load<Sprite> ("Animation/Background/BG/bg_5");
			rend.sprite = spr;

			break;

		case 5:

			spr = Resources.Load<Sprite> ("Animation/Background/BG/bg_6");
			rend.sprite = spr;

			break;

		case 6:

			spr = Resources.Load<Sprite> ("Animation/Background/BG/bg_7");
			rend.sprite = spr;

			break;

		case 7:

			spr = Resources.Load<Sprite> ("Animation/Background/BG/bg_8");
			rend.sprite = spr;

			break;

		case 8:

			spr = Resources.Load<Sprite> ("Animation/Background/BG/bg_9");
			rend.sprite = spr;

			break;

		case 9:

			spr = Resources.Load<Sprite> ("Animation/Background/BG/bg_10");
			rend.sprite = spr;

			break;

		case 10:

			spr = Resources.Load<Sprite> ("Animation/Background/BG/bg_11");
			rend.sprite = spr;

			break;

		case 11:

			spr = Resources.Load<Sprite> ("Animation/Background/BG/bg_12");
			rend.sprite = spr;

			break;

		case 12:

			spr = Resources.Load<Sprite> ("Animation/Background/BG/bg_13");
			rend.sprite = spr;

			break;

		case 13:

			spr = Resources.Load<Sprite> ("Animation/Background/BG/bg_night");
			rend.sprite = spr;

			break;

		case 14:

			spr = Resources.Load<Sprite> ("Animation/Background/BG/bg_14");
			rend.sprite = spr;

			break;


		}

	}
}
