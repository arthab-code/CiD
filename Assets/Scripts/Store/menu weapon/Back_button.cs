using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_button : MonoBehaviour {

	Sprite spr;
	SpriteRenderer rend;

	float posXspr;
	float posYspr;
	float width;
	float height;

	// Use this for initialization
	void Awake () {

		rend = GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {

		AreaClick ();

	}

	public void AreaClick()
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
					&& tpos.y > posYspr - height && tpos.y < posYspr + height && GLOBAL.tutorial_pause == false) {


					Show_panel ();

					for (int i = 0; i < 15; i++) {
						Weapon.weapons [i].rend.sortingOrder = 7;
						Weapon.weapons [i].transform.position = GameObject.Find (slot_name (i)).transform.position;
					}

					Weapon.id = -1;
				}

			}

		}

	}

	public void Show_panel()
	{

			GameObject S = GameObject.Find ("Store");   /** STORE **/
			//GameObject WM = GameObject.Find ("Weapon_menu");   /** WEAPON MENU **/
			//Menu_weapon MW_S = WM.GetComponent<Menu_weapon> ();

		//	MW_S.active = true;

			GLOBAL.shop_pause = true;

			Hide_Setmenu ();


	}

	public void Hide_Setmenu()
	{

		GameObject SM = GameObject.Find ("Set_menu");   /** STORE **/

		GameObject slot_1 = GameObject.Find ("slot_1");
		GameObject slot_2 = GameObject.Find ("slot_2");
		GameObject slot_3 = GameObject.Find ("slot_3");
		GameObject slot_4 = GameObject.Find ("slot_4");
		GameObject slot_5 = GameObject.Find ("slot_5");
		GameObject slot_6 = GameObject.Find ("slot_6");

		slot_1.GetComponent<SpriteRenderer> ().sortingOrder = 4;
		slot_2.GetComponent<SpriteRenderer> ().sortingOrder = 4;
		slot_3.GetComponent<SpriteRenderer> ().sortingOrder = 4;
		slot_4.GetComponent<SpriteRenderer> ().sortingOrder = 4;
		slot_5.GetComponent<SpriteRenderer> ().sortingOrder = 4;
		slot_6.GetComponent<SpriteRenderer> ().sortingOrder = 4;

		SM.transform.position = new Vector2 (-58, 0);

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
