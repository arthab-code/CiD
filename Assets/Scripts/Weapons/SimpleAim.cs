using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAim : MonoBehaviour {

	public GameObject Ship;
	public GameObject bullet;

	GameObject ShootAnimTurret;
	Animator anim;

	GameObject ShootAnimRocket;
	Animator anim_rocket;

	public float TimeShoot = 200f;

	void Awake()
	{
		if (gameObject.name == "SST") {

			ShootAnimTurret = GameObject.Find ("turret_shoot_anim");

		}else{
			
			ShootAnimTurret = GameObject.Find ("turret_shoot_anim1");
		
		}

		anim = ShootAnimTurret.GetComponent<Animator> ();

		ShootAnimRocket = GameObject.Find ("rocket_shoot_anim");
		anim_rocket = ShootAnimRocket.GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {

		if (GLOBAL.shop_pause == false && GLOBAL.pause == false && GLOBAL.wave_pause == false && GLOBAL.exit_pause == false || GLOBAL.tutorial_pause == true) {

			checkAnim ();

			if (Weapon.weapons [ReturnID (gameObject.name)].onArea == true) {
				
				if (Spawner.ships.Count > 0) {

					for (int i = 0; i < Spawner.ships.Count; i++) {

						if (Collision (Spawner.ships [i]) == true && Weapon.weapons[ReturnID (gameObject.name)].ammo > 0) {
		                
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

	void checkAnim()
	{

		if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1) {

			ShootAnimTurret.GetComponent<SpriteRenderer>().enabled = false;
			ShootAnimTurret.transform.position = new Vector3 (43f, -43f);

		}

		if (anim_rocket.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1) {

			ShootAnimRocket.GetComponent<SpriteRenderer>().enabled = false;
			ShootAnimRocket.transform.position = new Vector3 (43f, -43f);

		}

	}

	void BulletRespawn()
	{

		//***************************************************************************************************//

		Weapon weapon = Weapon.weapons [ReturnID (gameObject.name)];

		TimeShoot += Time.deltaTime;

		if (weapon.name == "SST" || weapon.name == "MST") {

			if (TimeShoot >= weapon.shoot_time) {

				if (Weapon.weapons [ReturnID (gameObject.name)].ammo > 0) {

					bullet.GetComponent<machine_bullet> ().damage = Weapon.weapons [ReturnID (gameObject.name)].damage;
					anim.Rebind ();
					ShootAnimTurret.GetComponent<SpriteRenderer>().enabled = true;

					if (weapon.side == false) {

						GameObject SpawnPoint = GameObject.Find (weapon.name + "_SP_L");
						ShootAnimTurret.transform.position = SpawnPoint.transform.position;
						ShootAnimTurret.GetComponent<SpriteRenderer> ().flipX = true;

						bullet.GetComponent<machine_bullet> ().speed = -1f;
						bullet.GetComponent<machine_bullet> ().transform.position = SpawnPoint.transform.position;
						bullet.GetComponent<machine_bullet> ().RotationOption = false;
						bullet.GetComponent<machine_bullet> ().rend.flipX = false;
						Instantiate (bullet);

						TimeShoot = 0;

					}

					if (weapon.side == true) {

						GameObject SpawnPoint = GameObject.Find (weapon.name + "_SP_P");
						ShootAnimTurret.transform.position = SpawnPoint.transform.position;
						ShootAnimTurret.GetComponent<SpriteRenderer> ().flipX = false;

						bullet.GetComponent<machine_bullet> ().speed = 1f;
						bullet.GetComponent<machine_bullet> ().transform.position = SpawnPoint.transform.position;
						bullet.GetComponent<machine_bullet> ().RotationOption = false;
						bullet.GetComponent<machine_bullet> ().rend.flipX = true;
						Instantiate (bullet);

						TimeShoot = 0;

					}
						

					Weapon.weapons [ReturnID (gameObject.name)].ammo -= 1; //**

				}
			}
		}


		if (weapon.name == "MissileHelper") {

			if (TimeShoot >= weapon.shoot_time) {

				if (Weapon.weapons [ReturnID (gameObject.name)].ammo > 0) {

					bullet.GetComponent<rocket_bullet> ().damage = Weapon.weapons [ReturnID (gameObject.name)].damage;

					anim_rocket.Rebind ();
					ShootAnimRocket.GetComponent<SpriteRenderer>().enabled = true;

					if (weapon.side == false) {

						GameObject SpawnPoint = GameObject.Find (weapon.name + "_SP_L");
						ShootAnimRocket.transform.position = SpawnPoint.transform.position;
						ShootAnimRocket.GetComponent<SpriteRenderer> ().flipX = true;


						bullet.GetComponent<rocket_bullet> ().speed = -1f;
						bullet.GetComponent<rocket_bullet> ().transform.position = SpawnPoint.transform.position;
						bullet.GetComponent<rocket_bullet> ().RotationOption = false;
						bullet.GetComponent<rocket_bullet> ().rend.flipX = false;
						Instantiate (bullet);

						TimeShoot = 0;

					}

					if (weapon.side == true) {

						GameObject SpawnPoint = GameObject.Find (weapon.name + "_SP_P");
						ShootAnimRocket.transform.position = SpawnPoint.transform.position;
						ShootAnimRocket.GetComponent<SpriteRenderer> ().flipX = false;


						bullet.GetComponent<rocket_bullet> ().speed = 1f;
						bullet.GetComponent<rocket_bullet> ().transform.position = SpawnPoint.transform.position;
						bullet.GetComponent<rocket_bullet> ().RotationOption = false;
						bullet.GetComponent<rocket_bullet> ().rend.flipX = true;
						Instantiate (bullet);

						TimeShoot = 0;

					}

					Weapon.weapons [ReturnID (gameObject.name)].ammo -= 1;

				}
			}
		}
		//****************************************************************************************************//


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

		case "LaserGun":

			return 4;

			break;

		case "LaserBeam":

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
