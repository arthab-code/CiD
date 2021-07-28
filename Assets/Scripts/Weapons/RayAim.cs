using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayAim : MonoBehaviour {

	public GameObject Ship;
	public GameObject bullet;

	bool animated = false;

	Animator anim;

	public bool  shoot = false;
	float time = 0;

	// Use this for initialization
	void Awake () {

		anim = GetComponent<Animator> ();
		anim.enabled = false;

	}

	// Update is called once per frame
	void Update () {
		
		Weapon weapon = Weapon.weapons [ReturnID (gameObject.name)];

		if (weapon != null) {

			if (GLOBAL.shop_pause == false && GLOBAL.pause == false && GLOBAL.wave_pause == false && GLOBAL.exit_pause == false) {

				if (weapon.shoot == true)
					weapon.ray_shoot += Time.deltaTime;

				if (Weapon.weapons [ReturnID (gameObject.name)].onArea == true) {

					if (Spawner.ships.Count > 0) {

						for (int i = 0; i < Spawner.ships.Count; i++) {

							if (Collision (Spawner.ships [i]) == true) {

								BulletRespawn ();

							}

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


		if (weapon.name == "LaserGate" || weapon.name == "SLG") {

			anim.enabled = true;
			anim.speed = 5f;


			if (weapon.ray_shoot <= weapon.shoot_time) {

				if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1) {

					bullet.GetComponent<ray> ().damage = Weapon.weapons [ReturnID (gameObject.name)].damage;

					if (weapon.shoot == false) {
						
						if (weapon.side == false) {

							GameObject SpawnPoint = GameObject.Find (weapon.name + "_SP_L");
							bullet.GetComponent<ray> ().speed = -1f;
							bullet.GetComponent<ray> ().transform.position = SpawnPoint.transform.position;
							bullet.GetComponent<ray> ().rend.flipX = false;
							bullet.GetComponent<ray> ().weapon_name = gameObject.name; 

							Instantiate (bullet);

						}

						if (weapon.side == true) {

							GameObject SpawnPoint = GameObject.Find (weapon.name + "_SP_P");
							bullet.GetComponent<ray> ().speed = 1f;
							bullet.GetComponent<ray> ().transform.position = SpawnPoint.transform.position;
							bullet.GetComponent<ray> ().rend.flipX = true;
							bullet.GetComponent<ray> ().weapon_name = gameObject.name; 
				
							Instantiate (bullet);


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
