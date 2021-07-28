using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray : MonoBehaviour {

	public float speed = 0;
	public float damage = 0;
	public float time_live = 0;

	public float time = 0;

	public string weapon_name = " "; 

	public GameObject Ship;
	public Ship ship_script;


	public SpriteRenderer rend;
	Sprite         spr;

	// Use this for initialization
	void Awake () {

		rend = GetComponent<SpriteRenderer> ();

		if (GLOBAL.mute == true) {

			GetComponent<AudioSource> ().mute = true;


		} else {

			GetComponent<AudioSource> ().mute = false;

		}

	}
	
	// Update is called once per frame
	void Update () {

		time += Time.deltaTime;

		AudioCheck ();

		if (GLOBAL.shop_pause == false && GLOBAL.pause == false && GLOBAL.wave_pause == false && GLOBAL.exit_pause == false && GLOBAL.bonus_pause == false) {

			checkColission ();
			Move ();

		}
		
	}

	void AudioCheck()
	{

		if (GLOBAL.shop_pause == true)
			GetComponent<AudioSource> ().enabled = false;
		else
			GetComponent<AudioSource> ().enabled = true;

	}

	bool Collision(Ship sh)
	{

		/** ZOBACZYĆ TĄ KOLIZJĘ CZY DZIAŁA DOBRZE **/
		float widthShip = (sh.rend.bounds.size.x / 2);
		float heightShip = (sh.rend.bounds.size.y / 2);

		float ShipX = sh.transform.position.x;
		float ShipY = sh.transform.position.y;


		float widthBullet = (rend.bounds.size.x / 2); 
		float heightBullet = (rend.bounds.size.y / 2);

		float BulletX = transform.position.x;
		float BulletY = transform.position.y;

		float BulletSizeWidth;
		float BulletSizeWidth1;

		if (rend.flipX == false) {

			BulletX = BulletX - widthBullet;

		} else {

			BulletX = BulletX + widthBullet;

		}

		if (BulletX + widthBullet > ShipX - widthShip && BulletX - widthBullet < ShipX + widthShip
			&& BulletY - heightBullet < ShipY + heightShip && BulletY + heightBullet > ShipY - heightShip) {

			return true;

		} else {

			return false;

		}


	}

	bool CollisionRay(GameObject ray)
	{

		ray r_script = ray.GetComponent<ray> ();

		float XposRay;
		float YposRay = r_script.transform.position.y;
		float WidthRay = r_script.rend.bounds.size.x / 2;
		float HeightRay = r_script.rend.bounds.size.y / 2 ;

		float Xpos;
		float Ypos = transform.position.y;
		float Width = rend.bounds.size.x / 2;
		float Height = rend.bounds.size.y / 2; 

		if (r_script.rend.flipX == false) {

			XposRay = r_script.transform.position.x - WidthRay;

		} else {

			XposRay = r_script.transform.position.x + WidthRay;
		}
			
		if (rend.flipX == false) {

			Xpos = transform.position.x - Width;

		} else {

			Xpos = transform.position.x + Width;
		}

		if (Xpos + Width > XposRay - WidthRay && Xpos - Width < XposRay + WidthRay
			&& Ypos - Height < YposRay + HeightRay && Ypos + Height > YposRay - HeightRay) {

			return true;

		} else {

			return false;

		}


	}


	void checkColission()
	{

		if (Spawner.ships.Count > 0) {

			for (int i = 0; i < Spawner.ships.Count ; i++) {

				hit_anim_laser hal = Spawner.ships [i].GetComponentInChildren<hit_anim_laser> ();

				if (Collision (Spawner.ships [i]) == true) {

					Spawner.ships [i].hp -= damage;


					hal.rend.enabled = true;


				} else {
					
	
					if (hal.rend.enabled == true){ //time > 0.05f) {
						hal.rend.enabled = false;

					}
				}

				Destroy (hal);


			}
		}
	}



	void Move()
	{
		if (gameObject.transform.localScale.x <= 3200f) {

			rend.transform.localScale += new Vector3 (155, 0f);
		
		}
	}

void Destroy(hit_anim_laser hal)
	{
		Weapon weapon = Weapon.weapons [ReturnID (weapon_name)];

		if (weapon.ray_shoot > weapon.shoot_time || weapon.onArea == false) {
			hal.rend.enabled = false;
			Destroy (gameObject);
			Destroy (this);

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
