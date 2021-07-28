using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_bullet : MonoBehaviour {

	public float speed = 0;
	public float damage = 0;

	public GameObject BULLET;

	public GameObject Ship;
	public Ship ship_script;

	public Quaternion rotate;

	public float angle;

	public bool RotationOption = false;

	SpriteRenderer rend;

	bool collided = false;
	bool InColision = false;
	bool created = false;
	bool destroyed = false;

	float time = 0;

	//AudioSource audio;

	public AudioClip audioClip1;

	bool audio_clip_one = false;

	// Use this for initialization
	void Awake () {

		rend = GetComponent<SpriteRenderer> ();
		ship_script = Ship.GetComponent<Ship> ();

		if (GLOBAL.mute == true) {

			GetComponent<AudioSource> ().mute = true;


		} else {

			GetComponent<AudioSource> ().mute = false;

		}

		if (RotationOption == true)
		transform.rotation = rotate;

	}

	// Update is called once per frame
	void Update () {

		if (GLOBAL.shop_pause == false && GLOBAL.pause == false && GLOBAL.wave_pause == false && GLOBAL.exit_pause == false
			&& GLOBAL.gameover_pause == false && GLOBAL.bonus_pause == false) {

			checkColission ();

			if (collided == false) {

				if (RotationOption == false) {

					Move ();

				} else {

					Move2 ();
				}

			}

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

					if (audio_clip_one == false && GetComponent<AudioSource>().mute == false) {
						GetComponent<AudioSource>().clip = audioClip1;
						audio_clip_one = true;
						GetComponent<AudioSource>().Play ();
					}
				

				} else {
					time += Time.deltaTime;
					if (time > 0.05f) {
						hal.rend.enabled = false;
						time = 0;
					}
				}

				DestroyBullet (hal);


			}


		}


	}
		

	void DestroyCollision()
	{

			Destroy (GetComponent<Animator> ());
			Destroy (this);
			Destroy (gameObject);


	}

	void DestroyBullet(hit_anim_laser hal)
	{

		if (transform.position.magnitude > 70)
		{
			hal.rend.enabled = false;
			Destroy (this);
			Destroy (gameObject);
		}
	}

	void Move()
	{

		Vector2 bufor = transform.position;
		bufor.x += speed;
		transform.position = bufor;

	}

	void Move2()
	{

		Vector2 bufor = transform.position;
		bufor.x += Mathf.Cos (angle) * speed;
		bufor.y += Mathf.Sin (angle) * speed;
		transform.position = bufor;

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

		if (BulletX + widthBullet > ShipX - widthShip && BulletX - widthBullet < ShipX + widthShip
			&& BulletY - heightBullet < ShipY + heightShip && BulletY + heightBullet > ShipY - heightShip) {

			return true;

		} else {

			return false;

		}
	}

}