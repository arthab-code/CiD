using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy_button : MonoBehaviour {

	Sprite spr;
	SpriteRenderer rend;

	float posXspr;
	float posYspr;
	float width;
	float height;

	int id;


	// Use this for initialization
	void Awake () {

		rend = GetComponent<SpriteRenderer> ();
		id = returnID (gameObject.name);

	}
	
	// Update is called once per frame
	void Update () {

		Render ();
		AreaClick ();
	}

	public void Render()
	{
		
		Weapon bufor = Weapon.weapons [id];

			if (bufor == null)
				return;

			if (bufor.lvl == 0 && GLOBAL.COINS >= bufor.price) {
				spr = Resources.Load<Sprite> ("Animation/Store/buy");
				rend.sprite = spr;



			}

			if (bufor.lvl == 0 && GLOBAL.COINS < bufor.price) {
				spr = Resources.Load<Sprite> ("Animation/Store/buy_d");
				rend.sprite = spr;

			}

			if (bufor.lvl > 0 && GLOBAL.COINS < bufor.price) {
				spr = Resources.Load<Sprite> ("Animation/Store/upgrade_d");
				rend.sprite = spr;

			}

			if (bufor.lvl > 0 && GLOBAL.COINS >= bufor.price) {
				spr = Resources.Load<Sprite> ("Animation/Store/upgrade_a");
				rend.sprite = spr;

			}



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

			if (Input.GetTouch (0).phase == TouchPhase.Began) {

				tpos = Camera.main.ScreenToWorldPoint (touch.position);      /** Zmienna pomocnicza przechwytująca pozycję dotknięcia skonwertowaną do odpowiednich koordynatów kamery **/

				/** Warunek sprawdzający czy dotknięcie ekranu mieści się w prawidłowym zakresie **/
				if (tpos.x > posXspr - width && tpos.x < posXspr + width
				    && tpos.y > posYspr - height && tpos.y < posYspr + height) {

					Weapon bufor = Weapon.weapons [id];

					if (bufor == null)
						return;

					if (bufor.lvl == 0 && GLOBAL.COINS >= bufor.price)
					{
						
						CountdownCoins ();
						UpdateStats ();

						if (GLOBAL.tutorial_count == 9) {

							GLOBAL.tutorial_count++;

						}

					}
						

					else if (bufor.lvl > 0 && GLOBAL.COINS >= bufor.price)
					{

						CountdownCoins ();
						UpdateStats ();

					}


				}

			}

		}

	}

	public int CountdownCoins()
	{
		Weapon bufor = Weapon.weapons [id];

		return GLOBAL.COINS -= bufor.price;

	}
		

	public void UpdateStats()
	{
		Weapon bufor = Weapon.weapons [id];

		switch (bufor.name) {

		case "SST":

			bufor.lvl += 1;
			bufor.damage = bufor.lvl * 10f;
			bufor.price = bufor.lvl * 100;
			bufor.max_ammo = bufor.lvl * 5;
			bufor.ammo = bufor.max_ammo;
			bufor.reload_time = 3f - (bufor.lvl / 15); 
			bufor.shoot_time = 0.7f - (bufor.lvl / 100);

			/** WYŚWIETLANIE W OKIENKU NASTĘPNE W MENU BRONI **/
			bufor.damage_next = (bufor.lvl + 1) * 10f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 0.7f - ((bufor.lvl+1) / 100);

			/** UWAGA PAMIĘTAĆ O ZMIANACH WARTOŚCI W NAVIGATION W FUNKCJI END_TUTORIAL () **/

			break;

		case "MST":

			bufor.lvl += 1;
			bufor.damage = bufor.lvl * 15f;
			bufor.price = bufor.lvl * 600;
			bufor.max_ammo = bufor.lvl * 12;
			bufor.ammo = bufor.max_ammo;
			bufor.reload_time = 2.5f - (bufor.lvl / 15); 
			bufor.shoot_time = 0.5f - (bufor.lvl / 100);

			/** WYŚWIETLANIE W OKIENKU NASTĘPNE W MENU BRONI **/
			bufor.damage_next = (bufor.lvl + 1) * 15f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 0.5f - ((bufor.lvl+1) / 100);

			break;

		case "RC":

			bufor.lvl += 1;
			bufor.damage = bufor.lvl * 10f;
			bufor.price = bufor.lvl * 800;
			bufor.max_ammo = bufor.lvl * 8;
			bufor.ammo = bufor.max_ammo;
			bufor.reload_time = 3f - (bufor.lvl / 15); 
			bufor.shoot_time = 0.7f - (bufor.lvl / 100);

			/** WYŚWIETLANIE W OKIENKU NASTĘPNE W MENU BRONI **/
			bufor.damage_next = (bufor.lvl + 1) * 10f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 0.7f - ((bufor.lvl+1) / 100);

			break;

		case "FRC":

			bufor.lvl += 1;
			bufor.damage = bufor.lvl * 15f;
			bufor.price = bufor.lvl * 1000;
			bufor.max_ammo = bufor.lvl * 12;
			bufor.ammo = bufor.max_ammo;
			bufor.reload_time = 2.5f - (bufor.lvl / 15); 
			bufor.shoot_time = 0.5f - (bufor.lvl / 100);

			/** WYŚWIETLANIE W OKIENKU NASTĘPNE W MENU BRONI **/
			bufor.damage_next = (bufor.lvl + 1) * 15f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 0.5f - ((bufor.lvl+1) / 100);

			break;

		case "LaserBeam":

			bufor.lvl += 1;
			bufor.damage = bufor.lvl * 0.6f;
			bufor.price = bufor.lvl * 1200;
			bufor.max_ammo = bufor.lvl * 20;
			bufor.ammo = bufor.max_ammo;
			bufor.reload_time = 2f - (bufor.lvl / 15); 
			bufor.shoot_time = 0.4f - (bufor.lvl / 100);

			/** WYŚWIETLANIE W OKIENKU NASTĘPNE W MENU BRONI **/
			bufor.damage_next = (bufor.lvl + 1) * 0.6f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 0.4f - ((bufor.lvl+1) / 100);

			break;

		case "LaserGun":

			bufor.lvl += 1;
			bufor.damage = bufor.lvl * 0.5f;
			bufor.price = bufor.lvl * 800;
			bufor.max_ammo = bufor.lvl * 10;
			bufor.ammo = bufor.max_ammo;
			bufor.reload_time = 2f - (bufor.lvl / 15); 
			bufor.shoot_time = 0.5f - (bufor.lvl / 100);

			/** WYŚWIETLANIE W OKIENKU NASTĘPNE W MENU BRONI **/
			bufor.damage_next = (bufor.lvl + 1) * 0.5f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 0.5f - ((bufor.lvl+1) / 100);

			break;

		case "RLB":

			bufor.lvl += 1;
			bufor.damage = bufor.lvl * 0.8f;
			bufor.price = bufor.lvl * 1600;
			bufor.max_ammo = bufor.lvl * 22;
			bufor.ammo = bufor.max_ammo;
			bufor.reload_time = 2f - (bufor.lvl / 15); 
			bufor.shoot_time = 0.4f - (bufor.lvl / 100);

			/** WYŚWIETLANIE W OKIENKU NASTĘPNE W MENU BRONI **/
			bufor.damage_next = (bufor.lvl + 1) * 0.8f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 0.4f - ((bufor.lvl+1) / 100);

			break;

		case "RLG":

			bufor.lvl += 1;
			bufor.damage = bufor.lvl * 0.5f;
			bufor.price = bufor.lvl * 2600;
			bufor.max_ammo = bufor.lvl * 20;
			bufor.ammo = bufor.max_ammo;
			bufor.reload_time = 2f - (bufor.lvl / 15); 
			bufor.shoot_time = 0.4f - (bufor.lvl / 100);

			/** WYŚWIETLANIE W OKIENKU NASTĘPNE W MENU BRONI **/
			bufor.damage_next = (bufor.lvl + 1) * 0.5f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 0.4f - ((bufor.lvl+1) / 100);

			break;

		case "LaserGate":

			bufor.lvl += 1;
			bufor.damage = bufor.lvl * 0.5f;
			bufor.price = bufor.lvl * 1400;
			bufor.reload_time = 6f - (bufor.lvl / 15); 
			bufor.shoot_time = 12f + (bufor.lvl / 100);

			/** WYŚWIETLANIE W OKIENKU NASTĘPNE W MENU BRONI **/
			bufor.damage_next = (bufor.lvl + 1) * 0.5f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 12f + ((bufor.lvl+1) / 100);


			break;

		case "SLG":

			bufor.lvl += 1;
			bufor.damage = bufor.lvl * 0.8f;
			bufor.price = bufor.lvl * 2600;
			bufor.reload_time = 7f - (bufor.lvl / 15); 
			bufor.shoot_time = 10f + (bufor.lvl / 100);

			/** WYŚWIETLANIE W OKIENKU NASTĘPNE W MENU BRONI **/
			bufor.damage_next = (bufor.lvl + 1) * 0.8f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 10f + ((bufor.lvl+1) / 100);

			break;

		case "SlowingGate":

			bufor.lvl += 1;
			bufor.damage = bufor.lvl * 0f;
			bufor.price = bufor.lvl * 4000;
			bufor.reload_time = 7f - (bufor.lvl / 15); 
			bufor.shoot_time = 12f + (bufor.lvl / 100);


			/** WYŚWIETLANIE W OKIENKU NASTĘPNE W MENU BRONI **/
			bufor.damage_next = (bufor.lvl + 1) * 0f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 12f + ((bufor.lvl+1) / 100);

			break;

		case "MissileHelper":

			bufor.lvl += 1;
			bufor.damage = bufor.lvl * 5f;
			bufor.price = bufor.lvl * 4000;

			if (bufor.lvl <= 3)
				bufor.max_ammo = 1f;
			if (bufor.lvl >= 4)
				bufor.max_ammo = 2;
			
			bufor.ammo = bufor.max_ammo;
			bufor.reload_time = 20f - (bufor.lvl / 15); 
			bufor.shoot_time = 3f - (bufor.lvl / 100);

			/** WYŚWIETLANIE W OKIENKU NASTĘPNE W MENU BRONI **/
			bufor.damage_next = (bufor.lvl + 1) * 5f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 3f - ((bufor.lvl+1) / 100);

			break;

		case "RocketLauncher":

			bufor.lvl += 1;
			bufor.damage = bufor.lvl * 8f;
			bufor.price = bufor.lvl * 6000;

			if (bufor.lvl <= 3)
				bufor.max_ammo = 1f;
			if (bufor.lvl >= 4 && bufor.lvl <= 6)
				bufor.max_ammo = 2;
			if (bufor.lvl >= 7)
				bufor.max_ammo = 3;

			bufor.ammo = bufor.max_ammo;
			bufor.reload_time = 20f - (bufor.lvl / 15); 
			bufor.shoot_time = 4f - (bufor.lvl / 100);

			/** WYŚWIETLANIE W OKIENKU NASTĘPNE W MENU BRONI **/
			bufor.damage_next = (bufor.lvl + 1) * 8f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 4f - ((bufor.lvl+1) / 100);

			break;

		case "AtomicCannon":
			
			bufor.lvl += 1;
			bufor.damage = bufor.lvl * 10f;
			bufor.price = bufor.lvl * 10000;

			bufor.max_ammo = 1;

			bufor.ammo = bufor.max_ammo;
			bufor.reload_time = 30f - (bufor.lvl / 15); 
			bufor.shoot_time = 5f - (bufor.lvl / 100);

			/** WYŚWIETLANIE W OKIENKU NASTĘPNE W MENU BRONI **/
			bufor.damage_next = (bufor.lvl + 1) * 10f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 5f - ((bufor.lvl+1) / 100);

			break;

		case "PLAYER":

			bufor.lvl += 1;
			bufor.damage = bufor.lvl * 3f;
			bufor.price = bufor.lvl * 100;
			bufor.max_ammo = 10;
			bufor.ammo = bufor.max_ammo;
			bufor.reload_time = 1.5f; 

			bufor.damage_next = (bufor.lvl + 1) * 3f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 0f;

			break;

		}
	}


	int returnID (string name)
	{

		switch (name) {

		case "buy_sst":

			return 0;

			break;

		case "buy_mst":

			return 1;

			break;

		case "buy_rc":

			return 2;

			break;

		case "buy_frc":

			return 3;

			break;

		case "buy_laserbeam":

			return 4;

			break;

		case "buy_lasergun":

			return 5;

			break;

		case "buy_rlb":

			return 6;

			break;

		case "buy_rlg":

			return 7;

			break;

		case "buy_lg":

			return 8;

			break;

		case "buy_slg":

			return 9;

			break;

		case "buy_sg":

			return 10;

			break;

		case "buy_missilehelper":

			return 11;

			break;

		case "buy_rocketlauncher":

			return 12;

			break;

		case "buy_atomiccannon":

			return 13;

			break;

		case "buy_player":

			return 14;

			break;

		default:
			return -1;
			break;

		}
	}
}
