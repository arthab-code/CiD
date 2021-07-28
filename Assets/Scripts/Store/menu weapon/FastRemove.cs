using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastRemove : MonoBehaviour {

	Slot slot;

	// Use this for initialization
	void Start () {

		slot = gameObject.GetComponentInParent<Slot> ();
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GLOBAL.tutorial_pause == false) {
		
			RenderButton ();
			CheckButton ();
		
		}
	}

	void RenderButton()
	{

		if (slot.busy == true) {

			gameObject.GetComponent<SpriteRenderer> ().enabled = true;

		} else {

			gameObject.GetComponent<SpriteRenderer> ().enabled = false;

		}

	}
		
	void Remove()
	{
		Weapon.id = slot.weaponID;
		Debug.Log (Weapon.id);
		Weapon.weapons [Weapon.id].transform.position = new Vector2 (100, 100);
		RemoveWeapon ();

		Debug.Log ("Remove");




	}



	void CheckButton()
	{

		if (AreaClick (gameObject) == true && GetComponent<SpriteRenderer> ().enabled == true && GLOBAL.shop_pause == false && GLOBAL.pause == false) {

			Remove ();

		}

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

	void RemoveWeapon()
	{
		int id = Weapon.id;

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

			return "BŁĄD WARTOŚCI W FUNKCJI RETURN_NAME w PLIKU FAST REMOVE.CS!";

			break;

		}

	}
}
