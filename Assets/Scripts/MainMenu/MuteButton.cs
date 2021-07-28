using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButton : MonoBehaviour {

	public BoxCollider2D     col;      /** Obiekt BoxCollider2D **/

	float                    posXc;    /** Zmienna przechowująca pozycję X BoxCollidera **/
	float                    posYc;    /** Zmienna przechowująca pozycję Y BoxCollidera **/

	float                    width;    /** Zmienna przechowując szerokośc BoxCollidera **/
	float                    height;   /** Zmienna przechowująca wysokość BoxCollidera **/
	SpriteRenderer rend;
	Sprite spr;


	// Use this for initialization
	void Awake () {

		/** Ustawienie wymiarów BoxCollidera **/
		/** Wymiary BoxCollidera są pomnożone przez skalę, dlatego są zawsze dopasowane do każdego rozmiaru **/
		width = (col.bounds.size.x / 2);
		height = (col.bounds.size.y / 2);

		rend = GetComponent<SpriteRenderer> ();


	}

	// Update is called once per frame
	void Update () {

		/** Ustawienie współrzędnych BoxCollidera **/ 
		posXc = col.transform.position.x;
		posYc = col.transform.position.y;

		/** Wywołanie funkcji odpowiadającej za interakcję z ekranem **/
		Area ();

		Render ();


	}

	void Render()
	{

		if (GLOBAL.mute == true) {

			spr = Resources.Load<Sprite> ("Animation/MainMenu/mute_button_active");
			rend.sprite = spr;

		} else {
			
			spr = Resources.Load<Sprite> ("Animation/MainMenu/mute_button_deactive");
			rend.sprite = spr;

		}

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

					if (GLOBAL.pause == false && GLOBAL.shop_pause == false || GLOBAL.tutorial_count == 7) {

						/** Instrukcja switch wybierająca odpowiednią scenę po kliknięciu w konkretną opcję **/
						switch (col.name) {

						case "MUTE":

							if (GLOBAL.mute == true) {

								GLOBAL.mute = false;

							} else {

								GLOBAL.mute = true;

							}

							break;

						}

					}

				}
			}
		}

	}
}
