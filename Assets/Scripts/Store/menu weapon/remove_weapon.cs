using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remove_weapon : MonoBehaviour {

	Sprite spr;
	SpriteRenderer rend;

	float posXspr;
	float posYspr;
	float width;
	float height;

	int id;

	void Awake()
	{

		rend = GetComponent<SpriteRenderer> ();
		id = returnID (gameObject.name);

	}
	// Update is called once per frame
	void Update () {

		Show_Button ();
		AreaClick ();

	}

	void Show_Button()
	{

		if (Weapon.weapons [id] == null)
			return;

		if (id == 14)
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;

		if ( Weapon.weapons[id].onArea == true)
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		else
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
	}


	public void RemoveWeapon()
	{
		GameObject slot = GameObject.Find (ReturnName (Weapon.weapons [id].slot_id));
		Slot slot_script = slot.GetComponent<Slot> ();

		if (Weapon.weapons [id].onArea == true && Weapon.weapons [id].added == false && slot_script.busy == true) {
			Weapon.weapons [id].onArea = false;
			Weapon.weapons [id].side = false;
			Weapon.weapons [id].added = true;


			slot_script.busy = false;
			slot_script.weaponID = -1;

			Weapon.weapons [id].slot_id = 0;
		}

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

					//Weapon.id = id;
					RemoveWeapon ();


				}

			}

		}

	}

	string ReturnName(int id)
	{

		string name;

		switch (id) {

		case 1:

			return name = "slot_1";

			break;

		case 2:

			return name = "slot_2";

			break;

		case 3:

			return name = "slot_3";

			break;

		case 4:

			return name = "slot_4";

			break;

		case 5:

			return name = "slot_5";

			break;

		case 6:

			return name = "slot_6";

			break;

		default:

			return "BŁĄD WARTOŚCI W FUNKCJI RETURN_NAME w PLIKU REMOVE_WEAPON.CS!";

			break;

		}

	}
		
	int returnID (string name)
	{

		switch (name) {

		case "remove_sst":

			return 0;

			break;

		case "remove_mst":

			return 1;

			break;

		case "remove_rc":

			return 2;

			break;

		case "remove_frc":

			return 3;

			break;

		case "remove_laserbeam":

			return 4;

			break;

		case "remove_lasergun":

			return 5;

			break;

		case "remove_rlb":

			return 6;

			break;

		case "remove_rlg":

			return 7;

			break;

		case "remove_lg":

			return 8;

			break;

		case "remove_slg":

			return 9;

			break;

		case "remove_sg":

			return 10;

			break;

		case "remove_missilehelper":

			return 11;

			break;

		case "remove_rocketlauncher":

			return 12;

			break;

		case "remove_atomiccannon":

			return 13;

			break;

		case "remove_player":

			return 14;

			break;

		default:
			return -1;
			break;

		}
	}
}