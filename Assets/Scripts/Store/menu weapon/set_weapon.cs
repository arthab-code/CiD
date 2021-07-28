using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_weapon : MonoBehaviour {

	Sprite spr;
	SpriteRenderer rend;

	float posXspr;
	float posYspr;
	float width;
	float height;

	int id;

	// Use this for initialization
	void Awake () {

		rend = GetComponent<SpriteRenderer> ();
		id = returnID (gameObject.name);

	}
	
	// Update is called once per frame
	void Update () {

		AreaClick ();
		Show_Button ();

	}

	void Show_Button()
	{
			
			if (Weapon.weapons [id] == null)
				return;

			if (id == 14)
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;

			if (Weapon.weapons [id].lvl < 1 || Weapon.weapons [id].onArea == true)
				gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			else
				gameObject.GetComponent<SpriteRenderer> ().enabled = true;
	}

	void AreaClick()
	{

		Vector2 tpos;                                                        /** Zmienna pomocnicza przechowująca wspłrzędne dotkniętego punktu na ekranie **/
		posXspr = transform.position.x;    
		posYspr = transform.position.y;   

		width = rend.bounds.size.x / 2;
		height = rend.bounds.size.y / 2;

		/** Warunek sprawdzający, czy został dotknięty ekran **/
		if (Input.touchCount > 0) {

			Touch touch = Input.GetTouch (0);                                /** Zmienna przechwycająca dotknięcie ekranu **/

			/** Warunek sprawdzający czy faza dotknięcia jest fazą początkową (dotknięcie ekranu) **/

			if (Input.GetTouch (0).phase == TouchPhase.Began) {

				tpos = Camera.main.ScreenToWorldPoint (touch.position);      /** Zmienna pomocnicza przechwytująca pozycję dotknięcia skonwertowaną do odpowiednich koordynatów kamery **/

				/** Warunek sprawdzający czy dotknięcie ekranu mieści się w prawidłowym zakresie **/
				if (tpos.x > posXspr - width && tpos.x < posXspr + width
					&& tpos.y > posYspr - height && tpos.y < posYspr + height && gameObject.GetComponent<SpriteRenderer> ().enabled == true) {

					if (GLOBAL.tutorial_count == 10) {

						GLOBAL.tutorial_count++;

					}

					Hide_panel ();
		


				}

			}

		}

	}

	void Hide_panel()
	{

		GameObject S = GameObject.Find ("Store");   /** STORE **/

		GLOBAL.shop_pause = false;

		S.transform.position = new Vector2 (65, 0);


		Show_Setmenu ();


	}

	void Show_Setmenu()
	{
		Weapon.id = id;

		GameObject SM = GameObject.Find ("Set_menu");   /** STORE **/

		GameObject slot_1 = GameObject.Find ("slot_1");
		GameObject slot_2 = GameObject.Find ("slot_2");
		GameObject slot_3 = GameObject.Find ("slot_3");
		GameObject slot_4 = GameObject.Find ("slot_4");
		GameObject slot_5 = GameObject.Find ("slot_5");
		GameObject slot_6 = GameObject.Find ("slot_6");
	
		Slot s1 = slot_1.GetComponent<Slot> ();
		Slot s2 = slot_2.GetComponent<Slot> ();
		Slot s3 = slot_3.GetComponent<Slot> ();
		Slot s4 = slot_4.GetComponent<Slot> ();
		Slot s5 = slot_5.GetComponent<Slot> ();
		Slot s6 = slot_6.GetComponent<Slot> ();

			if (s1.busy == false)
				slot_1.GetComponent<SpriteRenderer> ().sortingOrder = 9;

			if (s2.busy == false)
				slot_2.GetComponent<SpriteRenderer> ().sortingOrder = 9;

			if (s3.busy == false)
				slot_3.GetComponent<SpriteRenderer> ().sortingOrder = 9;

			if (s4.busy == false)
				slot_4.GetComponent<SpriteRenderer> ().sortingOrder = 9;

			if (s5.busy == false)
				slot_5.GetComponent<SpriteRenderer> ().sortingOrder = 9;
		
			if (s6.busy == false)
				slot_6.GetComponent<SpriteRenderer> ().sortingOrder = 9;

		if (GLOBAL.tutorial_pause == true && s5.busy == false) {

			s1.busy = true;
			s2.busy = true;
			s3.busy = true;
			s4.busy = true;
			s5.busy = false;
			s6.busy = true;

		}
		    
		SM.transform.position = new Vector2 (0, 0);

	}

	int returnID (string name)
	{

		switch (name) {

		case "set_sst":

			return 0;

			break;

		case "set_mst":

			return 1;

			break;

		case "set_rc":

			return 2;

			break;

		case "set_frc":

			return 3;

			break;

		case "set_laserbeam":

			return 4;

			break;

		case "set_lasergun":

			return 5;

			break;

		case "set_rlb":

			return 6;

			break;

		case "set_rlg":

			return 7;

			break;

		case "set_lg":

			return 8;

			break;

		case "set_slg":

			return 9;

			break;

		case "set_sg":

			return 10;

			break;

		case "set_missilehelper":

			return 11;

			break;

		case "set_rocketlauncher":

			return 12;

			break;

		case "set_atomiccannon":

			return 13;

			break;

		case "set_player":

			return 14;

			break;

		default:
			return -1;
			break;

		}
	}


}
