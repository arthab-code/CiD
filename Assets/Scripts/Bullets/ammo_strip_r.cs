using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo_strip_r : MonoBehaviour {

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
		width = 0.2f;

	}



	void FixedUpdate()
	{

		weapon = Weapon.weapons [ReturnID (nameWeapon.name)]; 

		if (weapon != null) {

			if (GLOBAL.pause == true || GLOBAL.shop_pause == true || GLOBAL.wave_pause == true || GLOBAL.exit_pause == true) {

				rend.enabled = false; 

			} else {

				if (weapon.onArea == true) {

					CheckFlip ();

					if (weapon.ammo >= 0)
						Renderer ();

					if (weapon.ammo <= 0)
						Reload ();

				}

			}

		}

	}


	public void Renderer () {

		rend.enabled = true; 

		spr = Resources.Load<Sprite> ("Animation/Bullets/ammo_strip_r");
		rend.sprite = spr;

		float size_strip = width * (weapon.ammo / weapon.max_ammo );                                /** funkcja obliczająca szerokośc paska **/

		rend.transform.localScale = new Vector3 (size_strip,1f);                        /** zmiana skali paska hp **/


	}

	public void Reload()
	{
		time += Time.deltaTime;

		spr = Resources.Load<Sprite> ("Animation/Bullets/reload_strip_r");
		rend.sprite = spr;

		float size_strip = width * (time / weapon.reload_time );                                /** funkcja obliczająca szerokośc paska **/

		rend.transform.localScale = new Vector3 (size_strip,1f);                        /** zmiana skali paska hp **/


		if (time >= weapon.reload_time) {

			weapon.ammo = weapon.max_ammo;
			time = 0;

		}
	}

	void CheckFlip()
	{

		if (weapon.rend.flipX == false)
			rend.flipX = false;
		else
			rend.flipX = true;

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