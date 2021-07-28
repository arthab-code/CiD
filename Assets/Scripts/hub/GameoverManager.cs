using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameoverManager : MonoBehaviour {

	public Text score;
	public GameObject EXIT;
	public GameObject SUBMIT;

	float posXspr;
	float posYspr;
	float width;
	float height;

	
	// Update is called once per frame
	void Update () {

		ShowScreen ();
		ShowText ();
		AreaClick ();
	}

	void ShowText()
	{

		score.text = GLOBAL.SCORE.ToString ();

	}

	void ShowScreen()
	{

		if (GLOBAL.gameover_pause == true) {

			transform.position = new Vector3 (0, 0);

		} else {

			transform.position = new Vector3 (-108, 0);

		}

	}

	public void GameOver()
	{
		GLOBAL.WAVE = 0;
		GLOBAL.SCORE = 0;
		GLOBAL.SCORE = 0;

		GLOBAL.wave_pause = true;
		GLOBAL.gameover_pause = false;
		Spawner.ships.Clear ();

		Application.LoadLevel ("_menu_0");

	}

	public void AreaClick()
	{

		Vector2 tpos;                                                        /** Zmienna pomocnicza przechowująca wspłrzędne dotkniętego punktu na ekranie **/
		posXspr = EXIT.transform.position.x;    
		posYspr = EXIT.transform.position.y;   

		width = EXIT.GetComponent<SpriteRenderer>().bounds.size.x / 2;
		height = EXIT.GetComponent<SpriteRenderer>().bounds.size.y / 2;

		/** Warunek sprawdzający, czy został dotknięty ekran **/
		if (Input.touchCount > 0) {

			Touch touch = Input.GetTouch (0);                                /** Zmienna przechwycająca dotknięcie ekranu **/

			/** Warunek sprawdzający czy faza dotknięcia jest fazą początkową (dotknięcie ekranu) **/

			if (Input.GetTouch (0).phase == TouchPhase.Began) {

				tpos = Camera.main.ScreenToWorldPoint (touch.position);      /** Zmienna pomocnicza przechwytująca pozycję dotknięcia skonwertowaną do odpowiednich koordynatów kamery **/

				/** Warunek sprawdzający czy dotknięcie ekranu mieści się w prawidłowym zakresie **/
				if (tpos.x > posXspr - width && tpos.x < posXspr + width
					&& tpos.y > posYspr - height && tpos.y < posYspr + height && GLOBAL.tutorial_pause == false) {

					GameOver ();


				}

			}

		}

	}

}
