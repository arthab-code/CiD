using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedAim : MonoBehaviour {

	public GameObject Ship;
	public GameObject bullet;

	public float TimeShoot = 20000f;

	int aim = -1;
	float angle;
	Quaternion rotate;

	GameObject ShootAnimTurret;
	Animator anim;



	GameObject ShootAnimRocket;
	Animator anim_rocket;

	GameObject SpawnPoint;

	void Awake()
	{
		if (gameObject.name == "RC") {
		
			ShootAnimTurret = GameObject.Find ("turret_shoot_anim_q");
			anim = ShootAnimTurret.GetComponent<Animator> ();
		
		} else {

			ShootAnimTurret = GameObject.Find ("turret_shoot_anim_q1");
			anim = ShootAnimTurret.GetComponent<Animator> ();

		}
			
		if (gameObject.name == "RocketLauncher") {
			
			ShootAnimRocket = GameObject.Find ("rocket_shoot_anim_q");

		} else {

			ShootAnimRocket = GameObject.Find ("rocket_shoot_anim_q1");

		}
			anim_rocket = ShootAnimRocket.GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {

		if (GLOBAL.shop_pause == false && GLOBAL.pause == false && GLOBAL.wave_pause == false && GLOBAL.exit_pause == false) {

			if (anim != null)
			checkAnim ();

			if (Weapon.weapons [ReturnID (gameObject.name)] != null) {

				if (Weapon.weapons [ReturnID (gameObject.name)].onArea == true) {

					if (Spawner.ships.Count > 0) {

						/*******************************/
						if (aim == -1) {
						
							for (int i = 0; i < Spawner.ships.Count; i++) {

								if (Collision (Spawner.ships [i]) == true) {
					        
									aim = i;

								}

							}

						} else {

							if (Weapon.weapons [ReturnID (gameObject.name)].aim == false) {

								Weapon.weapons [ReturnID (gameObject.name)].aim = true;
			
								if (Spawner.ships [aim].aimed == false)
									Spawner.ships [aim].aimed = true;

							}

							if (Collision (Spawner.ships [aim]) == true && Weapon.weapons [ReturnID (gameObject.name)].aim == true
							   && Spawner.ships [aim].aimed == true) {

								Angle (Spawner.ships [aim]);
								BulletRespawn ();
						
							} else {

								Weapon.weapons [ReturnID (gameObject.name)].aim = false;
								Spawner.ships [aim].aimed = false;
								aim = -1;

							}

						}

						/*******************************/

					}
				}
			}

		}
	}

	void checkAnim()
	{

		if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1) {

			ShootAnimTurret.GetComponent<SpriteRenderer> ().enabled = false;
			ShootAnimTurret.transform.position = new Vector3 (43f, -43f);

		} 


		if (anim_rocket.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1) {

			ShootAnimRocket.GetComponent<SpriteRenderer> ().enabled = false;
			ShootAnimRocket.transform.position = new Vector3 (43f, -43f);

		} 

		if (SpawnPoint != null) {
			
			ShootAnimTurret.transform.position = SpawnPoint.transform.position;
			ShootAnimRocket.transform.position = SpawnPoint.transform.position;
		}
	}
									
	bool Collision(Ship sh)
	{
		/** ZOBACZYĆ TĄ KOLIZJĘ CZY DZIAŁA DOBRZE **/

		float heightShip = (sh.rend.bounds.size.y);

		float heightWeapon = (Weapon.weapons [ReturnID (gameObject.name)].rend.bounds.size.y);

		float ShipY = sh.transform.position.y;

		float WeaponY = Weapon.weapons [ReturnID (gameObject.name)].transform.position.y;

		//if ( (ShipY - heightShip < WeaponY + heightWeapon && ShipY - heightShip > WeaponY - heightWeapon)  ||
		//	(ShipY + heightShip < WeaponY + heightWeapon && ShipY + heightShip > WeaponY - heightWeapon) )
		if ( (ShipY - heightShip < WeaponY + heightWeapon) && (ShipY + heightShip > WeaponY - heightWeapon))
			return true;
		else
			return false;


	}
		


	bool CollisionOUT(Ship sh)
	{
		/** ZOBACZYĆ TĄ KOLIZJĘ CZY DZIAŁA DOBRZE **/

		float heightShip = (sh.rend.bounds.size.y);

		float heightWeapon = (Weapon.weapons [ReturnID (gameObject.name)].rend.bounds.size.y);

		float ShipY = sh.transform.position.y;

		float WeaponY = Weapon.weapons [ReturnID (gameObject.name)].transform.position.y;

		if ( (ShipY + heightShip < WeaponY - heightWeapon))
			return true;
		else
			return false;


	}



	void Angle(Ship sh)
	{
		Weapon weapon = Weapon.weapons [ReturnID (gameObject.name)];

		if (weapon.ammo <= 0)
			return;

		Vector3 pos;

		if (weapon.side == false)
			pos = weapon.transform.position - sh.transform.position;
		else
			pos = sh.transform.position - weapon.transform.position;
		
		angle = Mathf.Atan2 (pos.y, pos.x);
		rotate = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
		weapon.transform.rotation = rotate;

		if (ShootAnimTurret != null) {
		
			ShootAnimTurret.transform.rotation = rotate;
		
		}

		ShootAnimRocket.transform.rotation = rotate;


	}

	void BulletRespawn()
	{

		Weapon weapon = Weapon.weapons [ReturnID (gameObject.name)];

		//***************************************************************************************************//

		TimeShoot += Time.deltaTime;

		if (weapon.name == "RC" || weapon.name == "FRC") {


			if (Weapon.weapons [ReturnID (gameObject.name)].ammo > 0) {

				bullet.GetComponent<machine_bullet> ().damage = Weapon.weapons [ReturnID (gameObject.name)].damage;

				if (TimeShoot >= weapon.shoot_time) {

					anim.Rebind ();

					ShootAnimTurret.GetComponent<SpriteRenderer>().enabled = true;

					if (weapon.side == false) {

						SpawnPoint = GameObject.Find (weapon.name + "_SP_L");
						ShootAnimTurret.transform.position = SpawnPoint.transform.position;
						ShootAnimTurret.GetComponent<SpriteRenderer> ().flipX = true;

			

						bullet.GetComponent<machine_bullet> ().speed = -1f;
						bullet.GetComponent<machine_bullet> ().transform.position = SpawnPoint.transform.position;
						bullet.GetComponent<machine_bullet> ().angle = angle;
						bullet.GetComponent<machine_bullet> ().rotate = rotate;
						bullet.GetComponent<machine_bullet> ().RotationOption = true;
						bullet.GetComponent<machine_bullet> ().rend.flipX = false;

						Instantiate (bullet);

						TimeShoot = 0;

					}

					if (weapon.side == true) {

						SpawnPoint = GameObject.Find (weapon.name + "_SP_P");

						ShootAnimTurret.transform.position = SpawnPoint.transform.position;
						ShootAnimTurret.GetComponent<SpriteRenderer> ().flipX = false;

						bullet.GetComponent<machine_bullet> ().speed = 1f;
						bullet.GetComponent<machine_bullet> ().transform.position = SpawnPoint.transform.position;
						bullet.GetComponent<machine_bullet> ().angle = angle;
						bullet.GetComponent<machine_bullet> ().rotate = rotate;
						bullet.GetComponent<machine_bullet> ().RotationOption = true;
						bullet.GetComponent<machine_bullet> ().rend.flipX = true;
						Instantiate (bullet);

						TimeShoot = 0;

					}

					Weapon.weapons [ReturnID (gameObject.name)].ammo--;

				}

			}
		}

		if (weapon.name == "RocketLauncher") {

			if (Weapon.weapons [ReturnID (gameObject.name)].ammo > 0) {

				if (TimeShoot >= weapon.shoot_time) {

					anim_rocket.Rebind ();
					ShootAnimRocket.GetComponent<SpriteRenderer>().enabled = true;

					bullet.GetComponent<rocket_bullet> ().damage = Weapon.weapons [ReturnID (gameObject.name)].damage;

					if (weapon.side == false) {

						SpawnPoint = GameObject.Find (weapon.name + "_SP_L");
						ShootAnimRocket.transform.position = SpawnPoint.transform.position;
						ShootAnimRocket.GetComponent<SpriteRenderer> ().flipX = true;

						bullet.GetComponent<rocket_bullet> ().speed = -1f;
						bullet.GetComponent<rocket_bullet> ().transform.position = SpawnPoint.transform.position;
						bullet.GetComponent<rocket_bullet> ().angle = angle;
						bullet.GetComponent<rocket_bullet> ().rotate = rotate;
						bullet.GetComponent<rocket_bullet> ().RotationOption = true;
						bullet.GetComponent<rocket_bullet> ().rend.flipX = false;

						Instantiate (bullet);

						TimeShoot = 0;

					}

					if (weapon.side == true) {

						SpawnPoint = GameObject.Find (weapon.name + "_SP_P");
						ShootAnimRocket.transform.position = SpawnPoint.transform.position;
						ShootAnimRocket.GetComponent<SpriteRenderer> ().flipX = false;

						bullet.GetComponent<rocket_bullet> ().speed = 1f;
						bullet.GetComponent<rocket_bullet> ().transform.position = SpawnPoint.transform.position;
						bullet.GetComponent<rocket_bullet> ().angle = angle;
						bullet.GetComponent<rocket_bullet> ().rotate = rotate;
						bullet.GetComponent<rocket_bullet> ().RotationOption = true;
						bullet.GetComponent<rocket_bullet> ().rend.flipX = true;
						Instantiate (bullet);

						TimeShoot = 0;

					}

					Weapon.weapons [ReturnID (gameObject.name)].ammo--;

				}

			}
		}


		if (weapon.name == "AtomicCannon") {

			if (Weapon.weapons [ReturnID (gameObject.name)].ammo > 0) {

				if (TimeShoot >= weapon.shoot_time) {

					anim_rocket.Rebind ();
					ShootAnimRocket.GetComponent<SpriteRenderer>().enabled = true;

					bullet.GetComponent<atomic_bullet> ().damage = Weapon.weapons [ReturnID (gameObject.name)].damage;

					if (weapon.side == false) {

						GameObject SpawnPoint = GameObject.Find (weapon.name + "_SP_L");
						ShootAnimRocket.transform.position = SpawnPoint.transform.position;
						ShootAnimRocket.GetComponent<SpriteRenderer> ().flipX = true;

						bullet.GetComponent<atomic_bullet> ().speed = -1f;
						bullet.GetComponent<atomic_bullet> ().transform.position = SpawnPoint.transform.position;
						bullet.GetComponent<atomic_bullet> ().angle = angle;
						bullet.GetComponent<atomic_bullet> ().rotate = rotate;
						bullet.GetComponent<atomic_bullet> ().RotationOption = true;
						bullet.GetComponent<atomic_bullet> ().rend.flipX = false;

						Instantiate (bullet);

						TimeShoot = 0;

					}

					if (weapon.side == true) {

						GameObject SpawnPoint = GameObject.Find (weapon.name + "_SP_P");
						ShootAnimRocket.transform.position = SpawnPoint.transform.position;
						ShootAnimRocket.GetComponent<SpriteRenderer> ().flipX = false;

						bullet.GetComponent<atomic_bullet> ().speed = 1f;
						bullet.GetComponent<atomic_bullet> ().transform.position = SpawnPoint.transform.position;
						bullet.GetComponent<atomic_bullet> ().angle = angle;
						bullet.GetComponent<atomic_bullet> ().rotate = rotate;
						bullet.GetComponent<atomic_bullet> ().RotationOption = true;
						bullet.GetComponent<atomic_bullet> ().rend.flipX = true;

						Instantiate (bullet);

						TimeShoot = 0;

					}

					Weapon.weapons [ReturnID (gameObject.name)].ammo--;

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
