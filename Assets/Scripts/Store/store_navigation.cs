using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class store_navigation : MonoBehaviour {
	
	float posXspr;
	float posYspr;
	float width;
	float height;

//	Menu_weapon MW;

	public SpriteRenderer rend;

	// Use this for initialization
	void Awake () {

	//	MW = GameObject.Find("Weapon_menu").GetComponent<Menu_weapon> ();
		
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

			if (Input.GetTouch(0).phase == TouchPhase.Began) {

				tpos = Camera.main.ScreenToWorldPoint (touch.position);      /** Zmienna pomocnicza przechwytująca pozycję dotknięcia skonwertowaną do odpowiednich koordynatów kamery **/

				/** Warunek sprawdzający czy dotknięcie ekranu mieści się w prawidłowym zakresie **/
				if (tpos.x > posXspr - width && tpos.x < posXspr + width
					&& tpos.y > posYspr - height && tpos.y < posYspr + height) {

				
					switch (rend.name) {

					case "STORE_BACK":

						GLOBAL.shop_pause = false;
						GLOBAL.pause = false;

						break;

					case "TAP":

						Store.type = Store.Type_menu.tap;

						break;

					case "MACHINE":

						Store.type = Store.Type_menu.machine;

						if (GLOBAL.tutorial_count == 8) {

							GLOBAL.tutorial_count++;

						}

						break;

					case "LASER":

						Store.type = Store.Type_menu.laser;

						break;

					case "ROCKET":

						Store.type = Store.Type_menu.rocket;

						break;

					case "GATES":

						Store.type = Store.Type_menu.gate;

						break;

					}

				

				}  // Collider

			} // Touch Phase


		} // TouchCount
	}
}
