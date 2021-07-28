using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectWaveManager : MonoBehaviour {

	public Text txt_wave;
	public GameObject START;
	public GameObject EXIT;
	public GameObject NEXT;
	public GameObject PREVIOUS;

	int wave = 5;

	int page = -1;


	// Use this for initialization
	void Awake () {

		FirstSetPage ();

	}
	
	// Update is called once per frame
	void Update () {
		
		PagePrevious (PREVIOUS);
		PageNext (NEXT);
		StartGame (START);
		ExitGame (EXIT);
		TextUpdate ();
		
	}

	bool AreaClick(GameObject GO)
	{

		Vector2 tpos;                                                        /** Zmienna pomocnicza przechowująca wspłrzędne dotkniętego punktu na ekranie **/
		SpriteRenderer go_r = GO.GetComponent<SpriteRenderer> ();
		float posXc = GO.transform.position.x;
		float posYc = GO.transform.position.y;

		float width = go_r.bounds.size.x;
		float height = go_r.bounds.size.y;

		/** Warunek sprawdzający, czy został dotknięty ekran **/
		if (Input.touchCount > 0) {

			Touch touch = Input.GetTouch (0);                                /** Zmienna przechwycająca dotknięcie ekranu **/


			/** Warunek sprawdzający czy faza dotknięcia jest fazą początkową (dotknięcie ekranu) **/
			if (touch.phase == TouchPhase.Began) {

				tpos = Camera.main.ScreenToWorldPoint (touch.position);      /** Zmienna pomocnicza przechwytująca pozycję dotknięcia skonwertowaną do odpowiednich koordynatów kamery **/

				/** Warunek sprawdzający czy dotknięcie ekranu mieści się w prawidłowym zakresie **/
				if (tpos.x > posXc - width && tpos.x < posXc + width
				    && tpos.y > posYc - height && tpos.y < posYc + height) {

					return true;


				}

			} 


		}// INPUT.TOUCHCOUNT > 0

		return false;
	} 
	

	void FirstSetPage()
	{

		if (PlayerPrefs.HasKey ("WaveBufor") == false) {

			page = -1;
			return;

		} 
			
		if (PlayerPrefs.GetInt ("WaveBufor") == 0) {

				page = 0;

		} 

		if (PlayerPrefs.GetInt ("WaveBufor") > 0) {

				page = PlayerPrefs.GetInt ("WaveBufor") / wave;

			}

		

	

	}

	void PagePrevious(GameObject PREV)
	{

		SpriteRenderer PREV_R = PREV.GetComponent<SpriteRenderer> ();

		if (page == -1) {

			PREV_R.enabled = false;

		} else {

			PREV_R.enabled = true;

		}

		if (PREV_R.enabled == true && AreaClick (PREV) == true) {

			page--;

		}

	}

	void PageNext(GameObject NEXT)
	{

		SpriteRenderer NEXT_R = NEXT.GetComponent<SpriteRenderer> ();

		if (PlayerPrefs.HasKey ("WaveBufor") == false) {

			NEXT_R.enabled = false;
			return;

		}

		if (page == PlayerPrefs.GetInt("WaveBufor") / wave) {

			NEXT_R.enabled = false;

		} else {

			NEXT_R.enabled = true;

		}



		if (NEXT_R.enabled == true && AreaClick (NEXT) == true) {

			page++;

		}

	}

	void StartGame(GameObject START)
	{

		SpriteRenderer START_R = START.GetComponent<SpriteRenderer> ();

		if (AreaClick (START) == true) {

			if (page == -1) {

				GLOBAL.WAVE = 0;

			}

			if (page == 0) {

				GLOBAL.WAVE = 1;

			}

			if (page > 0) {

				GLOBAL.WAVE = page * wave;

			}

			SceneManager.LoadSceneAsync ("_LoadLevel_0");
			GLOBAL.wave_pause = true;

		}

	}

	void ExitGame(GameObject EXIT)
	{

		SpriteRenderer EXIT_R = EXIT.GetComponent<SpriteRenderer> ();

		if (AreaClick (EXIT) == true) {

			SceneManager.LoadSceneAsync ("_menu_0");

		}

	}

	void TextUpdate()
	{

		if (page == -1) {

			txt_wave.text = "TUTORIAL";
			txt_wave.fontSize = 15;

		} else if (page == 0){

			txt_wave.fontSize = 20;
			txt_wave.text = 1.ToString ();

		} else {

			txt_wave.fontSize = 20;
			txt_wave.text = ((page * wave)).ToString ();

		}

	}

}
