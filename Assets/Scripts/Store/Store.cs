using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour {

	public SpriteRenderer         rend;


	public enum Type_menu
	{

		tap,
		laser,
		machine,
		rocket,
		gate

	}

	public static Type_menu       type = Type_menu.tap;


	// Update is called once per frame
	void Update () {

		if (GLOBAL.shop_pause == false && GLOBAL.pause == false) {
		    Hide ();
		}

		if (GLOBAL.shop_pause == true && GLOBAL.pause == true) {
			Show ();

			/** USTAWIENIE ROTACJI NA 0 W MENU WYŚWIETLANIA BRONI W SKLEPIE ABY UNIKNĄĆ NIEPRAWIDŁOWEGO WYŚWIETLANIA **/
			for (int i = 0; i < 14; i++) {

				Weapon.weapons[i].transform.rotation = Quaternion.Euler(0, 0, 0);


			}

		}

	}

	public void Show()
	{
		Vector2 bufor;

		bufor.x = 0f;
		bufor.y = 0f;


		rend.transform.position = bufor;
		transform.position = bufor;




		if (Store.type == Type_menu.machine) {

			Show_machine ();

		} else {

			Hide_machine ();

		}



		if (Store.type == Type_menu.laser) {

			Show_laser ();

		} else {

			Hide_laser ();

		}



		if (Store.type == Type_menu.rocket) {


			Show_rocket ();

		} else {

			Hide_rocket ();

		}


		if (Store.type == Type_menu.tap) {


			Show_tap ();

		} else {

			Hide_tap ();

		}

		if (Store.type == Type_menu.gate) {


			Show_gate ();

		} else {

			Hide_gate ();

		}

	}

	public void Hide()
	{
		Vector2 bufor;

			bufor.x = 55f;
			bufor.y = 0f;

		transform.position = bufor;
		rend.transform.position = bufor;

	}

	public void Show_machine()
	{
		GameObject.Find ("MACHINE_SLOTS").transform.position = new Vector2 (-0.5f,0.06f);

	}

	public void Hide_machine()
	{

		GameObject.Find ("MACHINE_SLOTS").transform.position = new Vector2 (50, 50);

	}

	public void Show_laser()
	{
		GameObject.Find ("LASER_SLOTS").transform.position = new Vector2 (-0.5f,0.06f);

	}

	public void Hide_laser()
	{

		GameObject.Find ("LASER_SLOTS").transform.position = new Vector2 (50, 50);

	}

	public void Show_rocket()
	{
		GameObject.Find ("ROCKET_SLOTS").transform.position = new Vector2 (-0.5f,0.06f);

	}

	public void Hide_rocket()
	{

		GameObject.Find ("ROCKET_SLOTS").transform.position = new Vector2 (50, 50);

	}

	public void Show_gate()
	{
		GameObject.Find ("GATE_SLOTS").transform.position = new Vector2 (-0.5f,0.06f);

	}

	public void Hide_gate()
	{

		GameObject.Find ("GATE_SLOTS").transform.position = new Vector2 (50, 50);

	}

	public void Show_tap()
	{
		GameObject.Find ("PLAYER_SLOTS").transform.position = new Vector2 (-0.5f,0.06f);

	}

	public void Hide_tap()
	{

		GameObject.Find ("PLAYER_SLOTS").transform.position = new Vector2 (50, 50);

	}



}
