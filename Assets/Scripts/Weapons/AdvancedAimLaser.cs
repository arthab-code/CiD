using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedAimLaser : MonoBehaviour {

	public GameObject Ship;
	public GameObject bullet;

	int aim = -1;
	float angle;
	Quaternion rotate;

	bool animated = false;

	Animator anim;

	GameObject LaserShoot;
	GameObject LaserShoot_1;
	float timeCheckAnim = 0;

	GameObject SpawnPoint;
	GameObject SpawnPoint2;


	// Use this for initialization
	void Awake () {

		anim = GetComponent<Animator> ();
		anim.enabled = false;

		if (gameObject.name == "RLB") {

			LaserShoot = GameObject.Find ("laser_shoot_anim_q");

		}

		if (gameObject.name == "RLG") {

			LaserShoot = GameObject.Find ("laser_shoot_anim_q1");
			LaserShoot_1 = GameObject.Find ("laser_shoot_anim_q2");

			LaserShoot_1.GetComponent<SpriteRenderer> ().enabled = false;

		}

		LaserShoot.GetComponent<SpriteRenderer> ().enabled = false;

	}

	// Update is called once per frame
	void Update () {

		if (GLOBAL.shop_pause == false && GLOBAL.pause == false && GLOBAL.wave_pause == false && GLOBAL.exit_pause == false) {

			checkAnim ();

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

							if (Spawner.ships[aim].aimed == false)
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

	bool Collision(Ship sh)
	{
		/** ZOBACZYĆ TĄ KOLIZJĘ CZY DZIAŁA DOBRZE **/

		float heightShip = (sh.rend.bounds.size.y);

		float heightWeapon = (Weapon.weapons [ReturnID (gameObject.name)].rend.bounds.size.y);

		float ShipY = sh.transform.position.y;

		float WeaponY = Weapon.weapons [ReturnID (gameObject.name)].transform.position.y;

		if ( (ShipY - heightShip < WeaponY + heightWeapon) && (ShipY + heightShip > WeaponY - heightWeapon))
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
		rotate = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
		weapon.transform.rotation = rotate;

		if (LaserShoot_1 != null) {

			if (SpawnPoint2 != null) {
				LaserShoot_1.transform.position = SpawnPoint2.transform.position;
			}

		}

		if (SpawnPoint != null) {
			LaserShoot.transform.position = SpawnPoint.transform.position;
		}

	}

	void checkAnim()
	{

		if (LaserShoot.GetComponent<SpriteRenderer> ().enabled == true) {

			timeCheckAnim += Time.deltaTime;

			if (timeCheckAnim >= 0.1f) {

				LaserShoot.transform.position = new Vector3 (43f, -43f);
				LaserShoot.GetComponent<SpriteRenderer> ().enabled = false;

				if (LaserShoot_1 != null) {

					LaserShoot_1.transform.position = new Vector3 (43f, -43f);
					LaserShoot_1.GetComponent<SpriteRenderer> ().enabled = false;

				}

				timeCheckAnim = 0;

			}


		}

	}

	void BulletRespawn()
	{


		Weapon weapon = Weapon.weapons [ReturnID (gameObject.name)];


		//***************************************************************************************************//


		if (weapon.name == "RLB") {

			anim.enabled = true;
			anim.speed = 5f;

			if (Weapon.weapons [ReturnID (gameObject.name)].ammo > 0) {

				if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1) {

					bullet.GetComponent<laser_bullet> ().damage = Weapon.weapons [ReturnID (gameObject.name)].damage;
					LaserShoot.GetComponent<SpriteRenderer> ().enabled = true;

					if (weapon.side == false) {

						SpawnPoint = GameObject.Find (weapon.name + "_SP_L");
						LaserShoot.transform.position = SpawnPoint.transform.position;

						bullet.GetComponent<laser_bullet> ().speed = -1f;
						bullet.GetComponent<laser_bullet> ().transform.position = SpawnPoint.transform.position;
						bullet.GetComponent<laser_bullet> ().angle = angle;
						bullet.GetComponent<laser_bullet> ().rotate = rotate;
						bullet.GetComponent<laser_bullet> ().RotationOption = true;

						Instantiate (bullet);


					}

					if (weapon.side == true) {

						SpawnPoint = GameObject.Find (weapon.name + "_SP_P");
						LaserShoot.transform.position = SpawnPoint.transform.position;

						bullet.GetComponent<laser_bullet> ().speed = 1f;
						bullet.GetComponent<laser_bullet> ().transform.position = SpawnPoint.transform.position;
						bullet.GetComponent<laser_bullet> ().angle = angle;
						bullet.GetComponent<laser_bullet> ().rotate = rotate;
						bullet.GetComponent<laser_bullet> ().RotationOption = true;

						Instantiate (bullet);


					}

					anim.Rebind ();

					anim.enabled = false;

					Weapon.weapons [ReturnID (gameObject.name)].ammo --;


				} 

			}

		}

		//*************************************************************************************************//



		if (weapon.name == "RLG") {

			anim.enabled = true;
			anim.speed = 5f;

			if (Weapon.weapons [ReturnID (gameObject.name)].ammo > 0) {

				if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1) {

					bullet.GetComponent<laser_bullet> ().damage = Weapon.weapons [ReturnID (gameObject.name)].damage;

					LaserShoot.GetComponent<SpriteRenderer> ().enabled = true;
					LaserShoot_1.GetComponent<SpriteRenderer> ().enabled = true;

					if (weapon.side == false) {

					    SpawnPoint = GameObject.Find (weapon.name + "_SP_HIGH_L");
						SpawnPoint2 = GameObject.Find (weapon.name + "_SP_LOW_L");
						LaserShoot.transform.position = SpawnPoint.transform.position;
						LaserShoot_1.transform.position = SpawnPoint2.transform.position;

						bullet.GetComponent<laser_bullet> ().speed = -1f;
						bullet.GetComponent<laser_bullet> ().transform.position = SpawnPoint.transform.position;
						bullet.GetComponent<laser_bullet> ().angle = angle;
						bullet.GetComponent<laser_bullet> ().rotate = rotate;
						bullet.GetComponent<laser_bullet> ().RotationOption = true;

						Instantiate (bullet);

						bullet.GetComponent<laser_bullet> ().transform.position = SpawnPoint2.transform.position;
						bullet.GetComponent<laser_bullet> ().angle = angle;
						bullet.GetComponent<laser_bullet> ().rotate = rotate;
						bullet.GetComponent<laser_bullet> ().RotationOption = true;

						Instantiate (bullet);

					}

					if (weapon.side == true) {

						SpawnPoint = GameObject.Find (weapon.name + "_SP_HIGH_P");
						SpawnPoint2 = GameObject.Find (weapon.name + "_SP_LOW_P");
						LaserShoot.transform.position = SpawnPoint.transform.position;
						LaserShoot_1.transform.position = SpawnPoint2.transform.position;

						bullet.GetComponent<laser_bullet> ().speed = 1f;
						bullet.GetComponent<laser_bullet> ().transform.position = SpawnPoint.transform.position;
						bullet.GetComponent<laser_bullet> ().angle = angle;
						bullet.GetComponent<laser_bullet> ().rotate = rotate;
						bullet.GetComponent<laser_bullet> ().RotationOption = true;

						Instantiate (bullet);


						bullet.GetComponent<laser_bullet> ().transform.position = SpawnPoint2.transform.position;
						bullet.GetComponent<laser_bullet> ().angle = angle;
						bullet.GetComponent<laser_bullet> ().rotate = rotate;
						bullet.GetComponent<laser_bullet> ().RotationOption = true;


						Instantiate (bullet);


					}

					anim.Rebind ();

					anim.enabled = false;

					Weapon.weapons [ReturnID (gameObject.name)].ammo --;
				} 

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
