using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowRayAim : MonoBehaviour {

	public GameObject Ship;
	public GameObject bullet;

	bool animated = false;

	Animator anim;

	public bool  shoot = false;
	float time = 0;

	GameObject bufor;

	// Use this for initialization
	void Awake () {

		anim = GetComponent<Animator> ();
		anim.enabled = false;

	}

	// Update is called once per frame
	void Update () {

		Weapon weapon = Weapon.weapons [ReturnID (gameObject.name)];

		if (GLOBAL.shop_pause == false && GLOBAL.pause == false && GLOBAL.wave_pause == false && GLOBAL.exit_pause == false) {

			if (weapon.shoot == true)
				weapon.ray_shoot += Time.deltaTime;

			if (Weapon.weapons [ReturnID (gameObject.name)].onArea == true) {

				if (Spawner.ships.Count > 0) {

					for (int i = 0; i < Spawner.ships.Count; i++) {

						if (Collision (Spawner.ships [i]) == true) {

							BulletRespawn ();

							/** POWRÓT PRAWIDŁOWEJ PRĘDKOŚCI GDY OBIEKT BULLET ZNISZCZONY **/
							if (bufor == null)
								Spawner.ships [i].speed = Spawner.ships [i].max_speed;

						}

					}
				}
			}
		}
	}

	bool Collision(Ship sh)
	{
		/** ZOBACZYĆ TĄ KOLIZJĘ CZY DZIAŁA DOBRZE **/

		float heightShip = (sh.rend.bounds.size.y / 2);

		float heightWeapon = (Weapon.weapons [ReturnID (gameObject.name)].rend.bounds.size.y / 2);

		float ShipY = sh.transform.position.y;

		float WeaponY = Weapon.weapons [ReturnID (gameObject.name)].transform.position.y;

		if ( (ShipY - heightShip < WeaponY + heightWeapon) && (ShipY + heightShip > WeaponY - heightWeapon))
			return true;
		else
			return false;


	}

	void BulletRespawn()
	{


		Weapon weapon = Weapon.weapons [ReturnID (gameObject.name)];


		//***************************************************************************************************//


		if (weapon.name == "SlowingGate") {

			anim.enabled = true;
			anim.speed = 5f;


			if (weapon.ray_shoot <= weapon.shoot_time) {


				if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1) {

					if (weapon.shoot == false) {

						if (weapon.side == false) {

							GameObject SpawnPoint = GameObject.Find (weapon.name + "_SP_L");
							bullet.GetComponent<slow_ray> ().speed = -1f;
							bullet.GetComponent<slow_ray> ().transform.position = SpawnPoint.transform.position;
							bullet.GetComponent<slow_ray> ().rend.flipX = false;
							bullet.GetComponent<slow_ray> ().weapon_name = gameObject.name; 

							bufor = Instantiate (bullet);

						}

						if (weapon.side == true) {

							GameObject SpawnPoint = GameObject.Find (weapon.name + "_SP_P");
							bullet.GetComponent<slow_ray> ().speed = 1f;
							bullet.GetComponent<slow_ray> ().transform.position = SpawnPoint.transform.position;
							bullet.GetComponent<slow_ray> ().rend.flipX = true;
							bullet.GetComponent<slow_ray> ().weapon_name = gameObject.name; 

							bufor = Instantiate (bullet);


						}

						anim.Rebind ();

						anim.enabled = false;

						weapon.shoot = true;

					} 
				}
			}

			/*	if (live_time >= live) {

				time += Time.deltaTime;

				if (time >= 2f) {
					Weapon.weapons [ReturnID (gameObject.name)].ammo = Weapon.weapons [ReturnID (gameObject.name)].max_ammo;
					time = 0f;
					weapon.ray_shoot = 0;
					shoot = false;
				}

			} */


		}

		//*************************************************************************************************//

	}

	int ReturnID(string name)
	{

		switch (name) {

		case "SST":

			return 0;

			break;

		case "MST":

			return 1;

			break;

		case "RC":

			return 2;

			break;

		case "FRC":

			return 3;

			break;

		case "LaserBeam":

			return 4;

			break;


		case "LaserGun":

			return 5;

			break;

		case "RLB":

			return 6;

			break;

		case "RLG":

			return 7;

			break;

		case "LaserGate":

			return 8;

			break;

		case "SLG":

			return 9;

			break;

		case "SlowingGate":

			return 10;

			break;

		case "MissileHelper":

			return 11;

			break;

		case "RocketLauncher":

			return 12;

			break;

		case "AtomicCannon":

			return 13;

			break;

		default:

			return -1;

			break;

		}



	}
}
