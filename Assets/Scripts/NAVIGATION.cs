using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NAVIGATION : MonoBehaviour {

	public BoxCollider2D     col;      /** Obiekt BoxCollider2D **/

	float                    posXc;    /** Zmienna przechowująca pozycję X BoxCollidera **/
	float                    posYc;    /** Zmienna przechowująca pozycję Y BoxCollidera **/

	float                    width;    /** Zmienna przechowując szerokośc BoxCollidera **/
	float                    height;   /** Zmienna przechowująca wysokość BoxCollidera **/

	GameObject Go;
	FileManager FM;

	// Use this for initialization
	void Awake () {

		/** Ustawienie wymiarów BoxCollidera **/
		/** Wymiary BoxCollidera są pomnożone przez skalę, dlatego są zawsze dopasowane do każdego rozmiaru **/
		width = (col.bounds.size.x / 2);
		height = (col.bounds.size.y / 2);
		Go = GameObject.Find ("FileManager");
		FM = Go.GetComponent<FileManager> ();

	
	}
	
	// Update is called once per frame
	void Update () {

		/** Ustawienie współrzędnych BoxCollidera **/ 
		posXc = col.transform.position.x;
		posYc = col.transform.position.y;

		/** Wywołanie funkcji odpowiadającej za interakcję z ekranem **/
		Area ();

		
	}
		

	/** Funkcja odpowiadająca za interakcję z ekranem dotykowym **/
	void Area ()
	{
		Vector2 tpos;                                                        /** Zmienna pomocnicza przechowująca wspłrzędne dotkniętego punktu na ekranie **/

		/** Warunek sprawdzający, czy został dotknięty ekran **/
		if (Input.touchCount > 0) {

			Touch touch = Input.GetTouch (0);                                /** Zmienna przechwycająca dotknięcie ekranu **/
		

			/** Warunek sprawdzający czy faza dotknięcia jest fazą początkową (dotknięcie ekranu) **/
			if (touch.phase == TouchPhase.Began) {
		
				tpos = Camera.main.ScreenToWorldPoint (touch.position);      /** Zmienna pomocnicza przechwytująca pozycję dotknięcia skonwertowaną do odpowiednich koordynatów kamery **/

				/** Warunek sprawdzający czy dotknięcie ekranu mieści się w prawidłowym zakresie **/
				if (tpos.x > posXc - width && tpos.x < posXc + width
				    && tpos.y > posYc - height && tpos.y < posYc + height) {

					if (GLOBAL.pause == false && GLOBAL.shop_pause == false  || GLOBAL.tutorial_count == 7) {

						/** Instrukcja switch wybierająca odpowiednią scenę po kliknięciu w konkretną opcję **/
						switch (col.name) {

						case "START":

							SceneManager.LoadSceneAsync ("_LoadLevel_0");

							break;

						case "TUTORIAL":

							FM.LoadFile ();

							if (GLOBAL.tutorial == 1) {
								Debug.Log ("1");
								FM.SaveFile (0);

							} else {
								Debug.Log ("2");
								FM.SaveFile (1);
							}



							if (GLOBAL.tutorial == 1) {
								Debug.Log ("3");
								GLOBAL.tutorial_pause = true;
								GLOBAL.tutorial_count = 0;
								GLOBAL.WAVE = 0;
								GLOBAL.bufor_enemies = 0;

							} else {
								Debug.Log ("4");
								GLOBAL.tutorial_pause = false;
								GLOBAL.wave_pause = true;

							}

							break;

						case "SCORES":
							Application.LoadLevel ("_scores_0");

							break;

						case "EXIT":
							Application.Quit ();

							break;

						case "BACK_BUTTON":
							if (GLOBAL.wave_pause == false && GLOBAL.exit_pause == false) {
							
								GLOBAL.exit_pause = true;
						
							}
							break;

						case "BACK_DAGREE":
							GLOBAL.exit_pause = false;

							break;

						case "START_WAVE":
							GLOBAL.wave_check = true;

							break;

						case "BACK_MENU":

							GLOBAL.WAVE = 0;
							GLOBAL.SCORE = 0;
							GLOBAL.COINS = 0;
							GLOBAL.exit_pause = false;
							Spawner.ships.Clear ();
							GLOBAL.wave_pause = true;

							Application.LoadLevel ("_menu_0");

							break;

						case "STORE":
							if (GLOBAL.wave_pause == false && GLOBAL.exit_pause == false && GLOBAL.boss_active == false && GLOBAL.gameover_pause == false || GLOBAL.tutorial_count == 7) {
							
								if (GLOBAL.tutorial_count == 7) {

									GLOBAL.tutorial_count++;
									GLOBAL.COINS += 50;

								}

								GLOBAL.shop_pause = true;
								GLOBAL.pause = true;
								PositionInShop ();
							}
							break;


						case "next_button":

							if (gameObject.GetComponent<SpriteRenderer> ().enabled == true) {
							
								GLOBAL.tutorial_count++;

							}

							break;

						case "skip_button":

							if (gameObject.GetComponent<SpriteRenderer> ().enabled == true) {

								END_TUTORIAL();

							}

							break;

						case "end_button":

							if (gameObject.GetComponent<SpriteRenderer> ().enabled == true) {

								END_TUTORIAL();

							}

							break;


						}

					}
				}
			}

		}

	}

	public void END_TUTORIAL()
	{
		GLOBAL.WAVE++;
		GLOBAL.tutorial_count = 0;
		GLOBAL.tutorial_pause = false;
		GLOBAL.wave_pause = true;
		GLOBAL.tutorial = 0;

		GameObject slot = GameObject.Find ("slot_5");
		Slot slot_script = slot.GetComponent<Slot> ();

		if (Weapon.weapons [0].onArea == true && Weapon.weapons [0].added == false && slot_script.busy == true) {

			Weapon.weapons [0].transform.position = new Vector3 (0, 50f);

			Weapon.weapons [0].onArea = false;
			Weapon.weapons [0].side = false;
			Weapon.weapons [0].added = true;
			Weapon.weapons [0].lvl = 0;

			slot_script.busy = false;
			slot_script.weaponID = -1;

			Weapon.weapons [0].slot_id = 0;
		}

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


		s1.busy = false;
		s2.busy = false;
		s3.busy = false;
		s4.busy = false;
		s5.busy = false;
		s6.busy = false;

		if (GLOBAL.COINS == 50) {

			GLOBAL.COINS -= 50;

		}

		Weapon.weapons [0].lvl = 0;
		Weapon.weapons [0].shoot_time = 0;
		Weapon.weapons [0].damage = 0;
		Weapon.weapons [0].price = 50;
		Weapon.weapons [0].lvl_next = 1;
		Weapon.weapons [0].damage_next = 10;

	}

	public void PositionInShop()
	{


		if (GLOBAL.shop_pause == true) {

			for (int i = 0; i< 14; i++)
				Weapon.weapons[i].transform.position = GameObject.Find (slot_name (i)).transform.position;

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

			Debug.Log ("Błędna wartość w funkcji slot_name w klasie ShowWeapon");
			return bufor = "NIEPOPRAWNA_WARTOŚĆ";

			break;

		}

	}


}
