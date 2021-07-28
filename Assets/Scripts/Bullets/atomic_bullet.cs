using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atomic_bullet : MonoBehaviour {

	public float speed = 0;
	public float damage = 0;

	public GameObject BULLET;

	public GameObject Ship;
	public Ship ship_script;

	public Quaternion rotate;

	public float angle;

	public bool RotationOption = false;

	public SpriteRenderer rend;

	bool collided = false;
	bool destroyed = false;

	AudioSource audio;

	public AudioClip audioClip1;

	bool audio_clip_one = false;

	// Use this for initialization
	void Awake () {

		rend = GetComponent<SpriteRenderer> ();
		ship_script = Ship.GetComponent<Ship> ();
		audio = GetComponent<AudioSource> ();

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
			if (destroyed == true) {

				DestroyCollision ();
			}


			DestroyBullet ();
		}

	}

	void checkColission()
	{

		if (Spawner.ships.Count > 0) {

			for (int i = 0; i < Spawner.ships.Count ; i++) {

				if (Collision (Spawner.ships[i]) == true ) {

					//if (destroyed == false)
					Spawner.ships [i].hp -= damage;

					collided = true;
					destroyed = true;

				} 


			}


		}


	}


	void DestroyCollision()
	{
		Animator anim;
		anim = GetComponent<Animator> ();
		anim.runtimeAnimatorController = Resources.Load ("Animator/hit_anim_atomic") as RuntimeAnimatorController;
		rend.transform.localScale = new Vector3 (30f, 30f);
		anim.Play ("hit_anim_atomic");

		audio.clip = audioClip1;

		if (audio_clip_one == false) {
			audio_clip_one = true;
			audio.Play ();
		}

		if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1) {

			Destroy (GetComponent<Animator> ());
			Destroy (this);
			Destroy (gameObject);

		}
	}

	void DestroyBullet()
	{

		if (transform.position.magnitude > 30)
		{
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
