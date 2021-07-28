using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

	public GameObject SLOT;

	public bool busy = false;
	public int weaponID = -1;

	public Back_button   BB;

	Sprite spr;
	SpriteRenderer rend;

	float posXspr;
	float posYspr;
	float width;
	float height;

	// Use this for initialization
	void Awake () {

		rend = GetComponent<SpriteRenderer> ();
		BB = GameObject.Find("BACK_SET_MENU").GetComponent<Back_button> ();

	}
	
	// Update is called once per frame
	void Update () {

		AreaClick ();

		if (weaponID > -1)
			PositionUpdate ();

		
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
					&& tpos.y > posYspr - height && tpos.y < posYspr + height && busy == false && GLOBAL.pause == true && GLOBAL.shop_pause == false ) {


					Set_weapon ();
					Weapon.weapons [Weapon.id].added = false;

					for (int i = 0; i < 15; i++) {
						Weapon.weapons [i].rend.sortingOrder = 7;
						Weapon.weapons [i].transform.position = GameObject.Find (slot_name (i)).transform.position;
					}
						

				}

			}

		}

	}

	void Set_weapon()
	{

		weaponID = Weapon.id;

		if (Weapon.weapons [weaponID].onArea == false && Weapon.weapons [weaponID].added == false && busy == false ) {


			Weapon.weapons [weaponID].onArea = true; 
			Weapon.weapons [weaponID].added = true;
			Weapon.weapons [weaponID].slot_id = ReturnId (gameObject.name); 
			busy = true;

			if (gameObject.name == "slot_1" || gameObject.name == "slot_3" || gameObject.name == "slot_5")
				Weapon.weapons [weaponID].side = true; 


			BB.Show_panel ();

			if (GLOBAL.tutorial_count == 11) {

				GLOBAL.tutorial_count++;
				GLOBAL.shop_pause = false;
				GLOBAL.pause = false;

			}

		}

	}

	void PositionUpdate()
	{
		if (Weapon.weapons [weaponID] == null)
			return;

		if (Weapon.weapons[weaponID].onArea == true &&  busy == true &&  GLOBAL.shop_pause == false)
		{
		
			Weapon.weapons [weaponID].transform.position = transform.position;

		
		}
			

	}

	int ReturnId(string name)
	{

		int id;

		switch (name) {

		case "slot_1":

			return id = 1;

			break;

		case "slot_2":

			return id = 2;

			break;

		case "slot_3":

			return id = 3;

			break;

		case "slot_4":

			return id = 4;

			break;

		case "slot_5":

			return id = 5;

			break;

		case "slot_6":

			return id = 6;

			break;

		default:

			return 0;

			break;

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
