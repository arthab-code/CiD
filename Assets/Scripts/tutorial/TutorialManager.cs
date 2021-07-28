using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

	public GameObject SHIP;
	public GameObject POINTER;

	public GameObject ShopPointer;
	public GameObject MachinePointer;
	public GameObject BuyPointer;
	public GameObject SetPointer;
	public GameObject SlotPointer;

	GameObject go;
	Ship sh;

	bool ship_create = false;

	public GameObject LEFT_SPAWN;


	// Update is called once per frame
	void Update () {

		TurnOnOFF ();

			Rend ();
			PointerRend ();
			ShipController ();
			ShipTutorial ();

	}

	void TurnOnOFF()
	{

		if (GLOBAL.WAVE == 0) {

			GLOBAL.tutorial_pause = true;

		} else {

			GLOBAL.tutorial_pause = false;
		}

	}

	void Rend()
	{

		if (GLOBAL.tutorial_pause == true) {

			gameObject.transform.position = new Vector3 (0, -25.54f);

		} else {

			gameObject.transform.position = new Vector3 (0, -53f);

		}

	}

	void ShipTutorial()
	{
		if ((GLOBAL.tutorial_count == 5 && ship_create == false) || (GLOBAL.tutorial_count == 12 && ship_create == false)) {

		    go = Instantiate (SHIP);

			Ship sh = go.GetComponent<Ship> ();
			sh.transform.position = LEFT_SPAWN.transform.position;
			Spawner.ships.Add (sh);

			GLOBAL.bufor_enemies++;

			ship_create = true;


		}

		if (GLOBAL.tutorial_count == 10) {

			ship_create = false;

		}

	}

	void ShipController()
	{
		/** GDY STATEK WYJEDZIE ZA EKRAN WRACA Z POWRTOEM DO SPAWN POINTU */
		if (GLOBAL.tutorial_pause == true && Spawner.ships.Count > 0) {

			if (Spawner.ships [0].transform.position.y < -23f) {

				Spawner.ships [0].transform.position = new Vector3 (-5f,35f);

			}

		}

		/** GDY ZOSTANIE WCISNIETY SKIP W MOMENCIE GDY STATEK JEST NA EKRANIE - USUWA GO**/
		if (GLOBAL.tutorial_pause == false && Spawner.ships.Count > 0) {

			Spawner.ships.Remove (sh);
			Destroy (go);
		}

	}

	void PointerRend()
	{

		if (GLOBAL.tutorial_count == 5 && Spawner.ships.Count > 0) {

			POINTER.transform.position = Spawner.ships [0].transform.position;

		}else if (GLOBAL.tutorial_count == 7){

			POINTER.transform.position = ShopPointer.transform.position;

		}else if (GLOBAL.tutorial_count == 8){

			POINTER.transform.position = MachinePointer.transform.position;

		}else if (GLOBAL.tutorial_count == 9){

			POINTER.transform.position = BuyPointer.transform.position;

		}else if (GLOBAL.tutorial_count == 10){

			POINTER.transform.position = SetPointer.transform.position;

		}else if (GLOBAL.tutorial_count == 11){

			POINTER.transform.position = SlotPointer.transform.position;

		}else if (GLOBAL.tutorial_count == 12  && Spawner.ships.Count > 0){

			POINTER.transform.position = Spawner.ships[0].transform.position;

		} else {

			POINTER.transform.position = new Vector3 (-36f, -46f);

		}

	}
}
