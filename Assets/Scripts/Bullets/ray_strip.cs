using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray_strip : MonoBehaviour {

	public SpriteRenderer      rend;      /** Obiekt renderujący spritea **/
	Sprite                     spr;
	private float              width;
	public GameObject          nameWeapon;
	Weapon                     weapon;
	float                      time;
	Quaternion                 rotate;

	void Awake()
	{

		rend = GetComponent<SpriteRenderer> ();    
		width = 0.2f;//weapon.rend.size.x;

	}



	void FixedUpdate()
	{

		weapon = Weapon.weapons [ReturnID (nameWeapon.name)]; 
		//float size_strip = width * ( time / weapon.reload_time);                                /** funkcja obliczająca szerokośc paska **/

		//if (weapon.lvl > 0)
		//rend.transform.localScale = new Vector3 (size_strip,1f);                        /** zmiana skali paska hp **/

		if (weapon != null) {

			if (GLOBAL.pause == true || GLOBAL.shop_pause == true) {

				rend.enabled = false; 

			} else {

				if (weapon.onArea == true) {

					if (weapon.ray_shoot < weapon.shoot_time)
						Renderer ();

					if (weapon.ray_shoot >= weapon.shoot_time)
						Reload ();

				}

			}

		}
	}


	public void Renderer () {

		rend.enabled = true; 

		spr = Resources.Load<Sprite> ("Animation/Bullets/ammo_strip");
		rend.sprite = spr;

		float size_strip = width * ((weapon.shoot_time - weapon.ray_shoot) / weapon.shoot_time );                                /** funkcja obliczająca szerokośc paska **/

		rend.transform.localScale = new Vector3 (size_strip,1f);                        /** zmiana skali paska hp **/


	}

	public void Reload()
	{

		time += Time.deltaTime;

		spr = Resources.Load<Sprite> ("Animation/Bullets/reload_strip");
		rend.sprite = spr;

		float size_strip = width * ( time / weapon.reload_time);                                /** funkcja obliczająca szerokośc paska **/

		if (size_strip < width)
			rend.transform.localScale = new Vector3 (size_strip,1f);                                /** zmiana skali paska hp **/



		if (time >= weapon.reload_time) {
			
			weapon.ray_shoot = 0;
			weapon.shoot = false;
			time = 0;

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
