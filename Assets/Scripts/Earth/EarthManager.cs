using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthManager : MonoBehaviour {

	public GameObject EARTH;
	public Earth EARTH_SCRIPT;

	public GameObject border_animation;

	public GameObject ShipDestroySpawner;
	public GameObject ShipDestroyObject;

	public GameObject smoke_1_l1;
	public GameObject smoke_2_l1;
	public GameObject smoke_3_l1_l3;
	public GameObject smoke_4_l1_l3;

	public GameObject smoke_l3;

	public GameObject smoke_1_l4;
	public GameObject smoke_2_l4;
	public GameObject smoke_3_l4;
	public GameObject smoke_4_l4;
	public GameObject smoke_5_l4;
	public GameObject smoke_6_l4;
	public GameObject smoke_7_l4;
	public GameObject smoke_8_l4;
	public GameObject smoke_9_l4;
	public GameObject smoke_10_l4;
	public GameObject smoke_11_l4;
	public GameObject smoke_12_l4;

	float highBorder;


	// Use this for initialization
	void Start () {

		EARTH_SCRIPT = EARTH.GetComponent<Earth> ();

		FalseRend ();

		highBorder = border_animation.transform.position.y - (border_animation.GetComponent<SpriteRenderer> ().bounds.size.y / 2);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GLOBAL.boss_active == true) {

			EARTH.GetComponent<SpriteRenderer> ().enabled = false;
			FalseRend ();

		} else {
			
			EARTH.GetComponent<SpriteRenderer> ().enabled = true;
			EarthRender ();
			CheckCollision ();
			GameOverVoid ();
		}
	}

	void EarthRender()
	{

		Sprite spr;

		if (EARTH_SCRIPT.HP > (EARTH_SCRIPT.MAX_HP * 0.9)) {

			spr = Resources.Load<Sprite> ("Animation/Earth/earth");
			EARTH.GetComponent<SpriteRenderer> ().sprite = spr;

		}

		if (EARTH_SCRIPT.HP <= (EARTH_SCRIPT.MAX_HP * 0.9) && EARTH_SCRIPT.HP >= (EARTH_SCRIPT.MAX_HP * 0.8)) {

			spr = Resources.Load<Sprite> ("Animation/Earth/earth_1");
			EARTH.GetComponent<SpriteRenderer> ().sprite = spr;

			smoke_1_l1.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_2_l1.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_3_l1_l3.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_4_l1_l3.GetComponent<SpriteRenderer> ().enabled = true;

		}

		if (EARTH_SCRIPT.HP < (EARTH_SCRIPT.MAX_HP * 0.8) && EARTH_SCRIPT.HP >= (EARTH_SCRIPT.MAX_HP * 0.6)) {

			spr = Resources.Load<Sprite> ("Animation/Earth/earth_2");
			EARTH.GetComponent<SpriteRenderer> ().sprite = spr;

			smoke_1_l1.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_2_l1.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_3_l1_l3.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_4_l1_l3.GetComponent<SpriteRenderer> ().enabled = true;
		}

		if (EARTH_SCRIPT.HP < (EARTH_SCRIPT.MAX_HP * 0.6) && EARTH_SCRIPT.HP >= (EARTH_SCRIPT.MAX_HP * 0.3)) {

			spr = Resources.Load<Sprite> ("Animation/Earth/earth_3");
			EARTH.GetComponent<SpriteRenderer> ().sprite = spr;

			smoke_1_l1.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_2_l1.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_l3.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_3_l1_l3.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_4_l1_l3.GetComponent<SpriteRenderer> ().enabled = true;
		}

		if (EARTH_SCRIPT.HP < (EARTH_SCRIPT.MAX_HP * 0.3) && EARTH_SCRIPT.HP > 0) {

			spr = Resources.Load<Sprite> ("Animation/Earth/earth_4");
			EARTH.GetComponent<SpriteRenderer> ().sprite = spr;

			smoke_1_l1.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_2_l1.GetComponent<SpriteRenderer> ().enabled = true;

			smoke_1_l4.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_2_l4.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_3_l4.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_4_l4.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_5_l4.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_6_l4.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_7_l4.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_8_l4.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_9_l4.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_10_l4.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_11_l4.GetComponent<SpriteRenderer> ().enabled = true;
			smoke_12_l4.GetComponent<SpriteRenderer> ().enabled = true;



		}

		if (EARTH_SCRIPT.HP <= 0) {

			spr = Resources.Load<Sprite> ("Animation/Earth/earth_5");
			EARTH.GetComponent<SpriteRenderer> ().sprite = spr;

			smoke_1_l1.GetComponent<SpriteRenderer> ().enabled = false;
			smoke_2_l1.GetComponent<SpriteRenderer> ().enabled = false;
			smoke_3_l1_l3.GetComponent<SpriteRenderer> ().enabled = false;
			smoke_4_l1_l3.GetComponent<SpriteRenderer> ().enabled = false;
			smoke_l3.GetComponent<SpriteRenderer> ().enabled = false;
			smoke_1_l4.GetComponent<SpriteRenderer> ().enabled = false;
			smoke_2_l4.GetComponent<SpriteRenderer> ().enabled = false;
			smoke_3_l4.GetComponent<SpriteRenderer> ().enabled = false;
			smoke_4_l4.GetComponent<SpriteRenderer> ().enabled = false;
			smoke_5_l4.GetComponent<SpriteRenderer> ().enabled = false;
			smoke_6_l4.GetComponent<SpriteRenderer> ().enabled = false;
			smoke_7_l4.GetComponent<SpriteRenderer> ().enabled = false;
			smoke_8_l4.GetComponent<SpriteRenderer> ().enabled = false;
			smoke_9_l4.GetComponent<SpriteRenderer> ().enabled = false;
			smoke_10_l4.GetComponent<SpriteRenderer> ().enabled = false;
			smoke_11_l4.GetComponent<SpriteRenderer> ().enabled = false;
			smoke_12_l4.GetComponent<SpriteRenderer> ().enabled = false;

		}

	}

	void CheckCollision()
	{

		float highShip;

		for (int i = 0; i < Spawner.ships.Count; i++) {

			highShip = Spawner.ships [i].transform.position.y + (Spawner.ships [i].gameObject.GetComponent<SpriteRenderer> ().bounds.size.y / 2);

			if (highShip < highBorder) {

				InstantiateShipDestroy ();
				Spawner.ships [i].Destroy ();

			}

		}

	}

	void InstantiateShipDestroy()
	{

		ShipDestroyObject.transform.position = ShipDestroySpawner.transform.position;

		Instantiate (ShipDestroyObject);

	}

	void GameOverVoid()
	{

		if (EARTH_SCRIPT.HP <= 0) {

			GLOBAL.gameover_pause = true;

		}

	}

	void FalseRend()
	{

		smoke_1_l1.GetComponent<SpriteRenderer> ().enabled = false;
		smoke_2_l1.GetComponent<SpriteRenderer> ().enabled = false;
		smoke_3_l1_l3.GetComponent<SpriteRenderer> ().enabled = false;
		smoke_4_l1_l3.GetComponent<SpriteRenderer> ().enabled = false;
		smoke_l3.GetComponent<SpriteRenderer> ().enabled = false;
		smoke_1_l4.GetComponent<SpriteRenderer> ().enabled = false;
		smoke_2_l4.GetComponent<SpriteRenderer> ().enabled = false;
		smoke_3_l4.GetComponent<SpriteRenderer> ().enabled = false;
		smoke_4_l4.GetComponent<SpriteRenderer> ().enabled = false;
		smoke_5_l4.GetComponent<SpriteRenderer> ().enabled = false;
		smoke_6_l4.GetComponent<SpriteRenderer> ().enabled = false;
		smoke_7_l4.GetComponent<SpriteRenderer> ().enabled = false;
		smoke_8_l4.GetComponent<SpriteRenderer> ().enabled = false;
		smoke_9_l4.GetComponent<SpriteRenderer> ().enabled = false;
		smoke_10_l4.GetComponent<SpriteRenderer> ().enabled = false;
		smoke_11_l4.GetComponent<SpriteRenderer> ().enabled = false;
		smoke_12_l4.GetComponent<SpriteRenderer> ().enabled = false;


	}
}
