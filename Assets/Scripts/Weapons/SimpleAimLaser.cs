using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAimLaser : MonoBehaviour {

	public GameObject Ship;
	public GameObject bullet;

	bool animated = false;

	Animator anim;

	GameObject LaserShoot;
	float timeCheckAnim = 0;

	// Use this for initialization
	void Awake () {
		
		anim = GetComponent<Animator> ();
		anim.enabled = false;

		if (gameObject.name == "LaserGun") {
			
			LaserShoot = GameObject.Find ("laser_shoot_anim");

		}

		if (gameObject.name == "LaserBeam") {
			
			LaserShoot = GameObject.Find ("laser_shoot_anim1");

		}

			LaserShoot.GetComponent<SpriteRenderer> ().enabled = false;

	}

	// Update is called once per frame
	void Update () {
			
		if (GLOBAL.shop_pause == false && GLOBAL.pause == false && GLOBAL.wave_pause == false && GLOBAL.exit_pause == false) {

			checkAnim ();

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


		if (weapon.name == "LaserGun" || weapon.name == "LaserBeam") {

			anim.enabled = true;
			anim.speed = 5f;

			if (Weapon.weapons [ReturnID (gameObject.name)].ammo > 0) {

				if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1) {

					bullet.GetComponent<laser_bullet> ().damage = Weapon.weapons [ReturnID (gameObject.name)].damage;
					LaserShoot.GetComponent<SpriteRenderer> ().enabled = true;

					if (weapon.side == false) {

						GameObject SpawnPoint = GameObject.Find (weapon.name + "_SP_L");
						LaserShoot.transform.position = SpawnPoint.transform.position;

						bullet.GetComponent<laser_bullet> ().speed = -1f;
						bullet.GetComponent<laser_bullet> ().transform.position = SpawnPoint.transform.position;
						bullet.GetComponent<laser_bullet> ().RotationOption = false;
						Instantiate (bullet);


					}

					if (weapon.side == true) {

						GameObject SpawnPoint = GameObject.Find (weapon.name + "_SP_P");
						LaserShoot.transform.position = SpawnPoint.transform.position;

						bullet.GetComponent<laser_bullet> ().speed = 1f;
						bullet.GetComponent<laser_bullet> ().transform.position = SpawnPoint.transform.position;
						bullet.GetComponent<laser_bullet> ().RotationOption = false;
						Instantiate (bullet);


					}

					anim.Rebind ();

					anim.enabled = false;


					Weapon.weapons [ReturnID (gameObject.name)].ammo--;
				} 
			}

		}

		//*************************************************************************************************//

	}

	void checkAnim()
	{

		if (LaserShoot.GetComponent<SpriteRenderer> ().enabled == true) {

			timeCheckAnim += Time.deltaTime;

			if (timeCheckAnim >= 0.1f) {

				LaserShoot.transform.position = new Vector3 (43f, -43f);
				LaserShoot.GetComponent<SpriteRenderer> ().enabled = false;
				timeCheckAnim = 0;

			}

		}

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
