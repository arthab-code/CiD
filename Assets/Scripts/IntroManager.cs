using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour {

	float time;
	
	// Update is called once per frame
	void Update () {
		//PlayerPrefs.DeleteAll ();
		time += Time.deltaTime;

		if (time > 3.1f) {

			Application.LoadLevel ("_menu_0");

		}

		if (Input.touchCount > 0) {

			Touch touch = Input.GetTouch (0);                                /** Zmienna przechwycająca dotknięcie ekranu **/


			/** Warunek sprawdzający czy faza dotknięcia jest fazą początkową (dotknięcie ekranu) **/
			if (touch.phase == TouchPhase.Began) {

				Application.LoadLevel ("_menu_0");

			}


		}

		
	}
}
