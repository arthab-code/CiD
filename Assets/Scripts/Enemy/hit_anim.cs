using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_anim : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Awake() {

		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		ControlAnim ();

		if (GLOBAL.shop_pause == false && GLOBAL.pause == false && GLOBAL.wave_pause == false && GLOBAL.exit_pause == false
		    || GLOBAL.tutorial_pause == true) {
		
			//Area ();
			//ControlAnim ();
			GetComponent<SpriteRenderer>().enabled = true;
		
		} else {

		//	HideAnim ();
			GetComponent<SpriteRenderer>().enabled = false;

		}
	}

	void ShowAnim()
	{

		anim.Rebind ();
		anim.enabled = true;
		GetComponent<SpriteRenderer>().enabled = true;


	}

	void HideAnim()
	{

		anim.enabled = false;
		GetComponent<SpriteRenderer>().enabled = false;

	}

	void Area ()
	{
		Vector2 tpos;                                                        /** Zmienna pomocnicza przechowująca wspłrzędne dotkniętego punktu na ekranie **/

		/** Warunek sprawdzający, czy został dotknięty ekran **/
		if (Input.touchCount > 0) {

			Touch touch = Input.GetTouch (0);                                /** Zmienna przechwycająca dotknięcie ekranu **/


			/** Warunek sprawdzający czy faza dotknięcia jest fazą początkową (dotknięcie ekranu) **/
			if (touch.phase == TouchPhase.Began) {

				tpos = Camera.main.ScreenToWorldPoint (touch.position);      /** Zmienna pomocnicza przechwytująca pozycję dotknięcia skonwertowaną do odpowiednich koordynatów kamery **/

				if (tpos.y < 23) {
					
					ShowAnim ();
					transform.position = tpos;

				}
			}

		}

	}

	void ControlAnim()
	{

		if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1) {

			Destroy (gameObject);
			Destroy (this);

			/*GetComponent<SpriteRenderer>().enabled = false;
			anim.enabled = false;

			transform.position = new Vector2 (-50, -50); */

		}

	}
} 
