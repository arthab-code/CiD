using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_weapon_navi : MonoBehaviour {

	float posXspr;
	float posYspr;
	float width;
	float height;
	Menu_weapon MW;

	public SpriteRenderer rend;

	// Use this for initialization
	void Awake () {

		rend = GetComponent<SpriteRenderer> ();
		MW = GameObject.Find("Weapon_menu").GetComponent<Menu_weapon> ();

		
	}
	
	// Update is called once per frame
	void Update () {
		
		AreaClick ();

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
					&& tpos.y > posYspr - height && tpos.y < posYspr + height) {




					if (MW.active == false) {
						switch (rend.name) {

						case "SST_SLOT":

							Weapon.id = 0;

							break;

						case "MST_SLOT":

							Weapon.id = 1;

							break;

						case "RC_SLOT":

							Weapon.id = 2;

							break;

						case "FRC_SLOT":

							Weapon.id = 3;

							break;

						case "LASERBEAM_SLOT":

							Weapon.id = 4;

							break;

						case "LASERGUN_SLOT":

							Weapon.id = 5;

							break;

						case "RLB_SLOT":

							Weapon.id = 6;

							break;

						case "RLG_SLOT":

							Weapon.id = 7;

							break;

						case "LG_SLOT":

							Weapon.id = 8;

							break;

						case "SLG_SLOT":

							Weapon.id = 9;

							break;

						case "SG_SLOT":

							Weapon.id = 10;

							break;

						case "MISSILEHELPER_SLOT":

							Weapon.id = 11;

							break;

						case "ROCKETLAUNCHER_SLOT":

							Weapon.id = 12;

							break;

						case "ATOMICCANNON_SLOT":

							Weapon.id = 13;

							break;

						case "PLAYER_SLOT":

							Weapon.id = 14;

							break;


						}
					}

					if (rend.name != "BACK") {
						
						MW.active = true;   /** aktywacja menu broni w sklepie **/
					
					} else {
						
						MW.active = false;
						Hide ();
					} 

				}



		}

	}
}


   

	public void Hide()
	{
		Vector2 bufor_xy;

		bufor_xy.x = 130f;
		bufor_xy.y = 0f;

		MW.transform.position = bufor_xy;
		MW.rend.transform.position = bufor_xy;



		for (int i = 0; i < 15; i++) {
			Weapon.weapons [i].rend.sortingOrder = 7;
			Weapon.weapons [i].transform.position = GameObject.Find (slot_name (i)).transform.position;
		}


	}

	public string slot_name(int i)
	{
		string bufor;

		switch (i) {


		case 0:

			return bufor = "SST_SLOT_M";

			break;

		case 1:

			return bufor = "MST_SLOT_M";

			break;

		case 2:

			return bufor = "RC_SLOT_M";

			break;

		case 3:

			return bufor = "FRC_SLOT_M";

			break;

		case 4:

			return bufor = "LASERBEAM_SLOT_M";

			break;

		case 5:

			return bufor = "LASERGUN_SLOT_M";

			break;

		case 6:

			return bufor = "RLB_SLOT_M";

			break;

		case 7:

			return bufor = "RLG_SLOT_M";

			break;

		case 8:

			return bufor = "LG_SLOT_M";

			break;

		case 9:

			return bufor = "SLG_SLOT_M";

			break;

		case 10:

			return bufor = "SG_SLOT_M";

			break;

		case 11:

			return bufor = "MISSILEHELPER_SLOT_M";

			break;

		case 12:

			return bufor = "ROCKETLAUNCHER_SLOT_M";

			break;

		case 13:

			return bufor = "ATOMICCANNON_SLOT_M";

			break;

		case 14:

			return bufor = "PLAYER_SLOT_M";

			break;

		default:

			Debug.Log ("Błędna wartość w funkcji slot_name w klasie MenuWeaponNavi");
			return bufor = "NIEPOPRAWNA_WARTOŚĆ";

			break;

		}

	}
}
