using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System;

public class FileManager : MonoBehaviour{

	bool load = true;

	void Update()
	{
		//PlayerPrefs.DeleteAll ();
		if (PlayerPrefs.GetInt ("SAVED") == 1)
		LoadGame ();

	}
    
	void LoadGame()
	{

		if (load == true) {

			if (Weapon.weapons [0] == null)
				return;

			for (int i = 0; i < 6; i++) {

				if (GameObject.Find ("slot_" + (i + 1).ToString ()).GetComponent<Slot>() == null)
					return;

			}

			LoadAll ();
			load = false;

		}
	}

	public void SaveAll()
	{
		/** SAVE WEAPONS **/

		int onArea;
		int added;
		int side;
		int active;
		int shoot;
		int aim;

		for (int i = 0; i < 15; i++) {
			
			if (Weapon.weapons [i].onArea == true) {

				onArea = 1;

			} else {

				onArea = 0;
			}

			if (Weapon.weapons [i].added == true) {

				added = 1;

			} else {

				added = 0;
			}

			if (Weapon.weapons [i].side == true) {

				side = 1;

			} else {

				side = 0;
			}

			if (Weapon.weapons [i].active == true) {

				active = 1;

			} else {

				active = 0;
			}

			if (Weapon.weapons [i].shoot == true) {

				shoot = 1;

			} else {

				shoot = 0;
			}

			if (Weapon.weapons [i].aim == true) {

				aim = 1;

			} else {

				aim = 0;
			}

			PlayerPrefs.SetInt ((i).ToString() + "onArea", onArea);
			PlayerPrefs.SetInt ((i).ToString()  + "added", added);
			PlayerPrefs.SetInt ((i).ToString() + "side", side);
			PlayerPrefs.SetInt ((i).ToString() + "active", active);
			PlayerPrefs.SetInt ((i).ToString() + "shoot", shoot);
			PlayerPrefs.SetInt ((i).ToString() + "aim", aim);

			PlayerPrefs.SetInt ((i).ToString() + "slotID", Weapon.weapons [i].slot_id);
			PlayerPrefs.SetInt ((i).ToString() + "lvl", Weapon.weapons [i].lvl);
			PlayerPrefs.SetInt ((i).ToString() + "price", Weapon.weapons [i].price);
			PlayerPrefs.SetInt ((i).ToString() + "slot_id", Weapon.weapons [i].slot_id);

			PlayerPrefs.SetFloat ((i).ToString() + "ammo", Weapon.weapons [i].ammo);
			PlayerPrefs.SetFloat ((i).ToString() + "max_ammo", Weapon.weapons [i].max_ammo);
			PlayerPrefs.SetFloat ((i).ToString() + "reload_time", Weapon.weapons [i].reload_time);
			PlayerPrefs.SetFloat ((i).ToString() + "shoot_time", Weapon.weapons [i].shoot_time);
			PlayerPrefs.SetFloat ((i).ToString() + "ray_shoot", Weapon.weapons [i].ray_shoot);
			PlayerPrefs.SetFloat ((i).ToString() + "damage", Weapon.weapons [i].damage);
			PlayerPrefs.SetFloat ((i).ToString() + "damage_next", Weapon.weapons [i].damage_next);
			PlayerPrefs.SetFloat ((i).ToString() + "lvl_next", Weapon.weapons [i].lvl_next);
			PlayerPrefs.SetFloat ((i).ToString() + "shoot_time_next", Weapon.weapons [i].shoot_time_next);
		}

		/** SAVE SLOTS **/
		for (int i = 0; i < 6; i++) {

			GameObject slot = GameObject.Find ("slot_" + (i+1).ToString ());
			Slot slot_script = slot.GetComponent<Slot> ();

			int busy;

			if (slot_script.busy == true) {

				busy = 1;

			} else {

				busy = 0;

			}

			PlayerPrefs.SetInt ((i+1).ToString() + "busy", busy);
			PlayerPrefs.SetInt ((i+1).ToString() + "weaponID", slot_script.weaponID);

		}

		/** GLOBAL SAVE **/
		PlayerPrefs.SetInt ("COINS", GLOBAL.COINS);

		if (GLOBAL.WAVE > PlayerPrefs.GetInt ("WaveBufor")) {
			
			PlayerPrefs.SetInt ("WaveBufor", GLOBAL.WAVE);

		}

		PlayerPrefs.SetInt ("SCORE", GLOBAL.SCORE);
		PlayerPrefs.SetInt ("SAVED", 1);
		PlayerPrefs.SetInt ("BOSS_TYPE", GLOBAL.boss_type);

		PlayerPrefs.Save ();

		Debug.Log ("ZAPISANO STAN GRY");

	}

	public void LoadAll()
	{
		/** LOAD WEAPONS **/
		bool onArea;
		bool added;
		bool side;
		bool active;
		bool shoot;
		bool aim;

		for (int i = 0; i < 15; i++) {

			if (PlayerPrefs.GetInt ((i).ToString() + "onArea") == 1) {

				onArea = true;

			} else {

				onArea = false;

			}

			if (PlayerPrefs.GetInt ((i).ToString() + "added") == 1) {

				added = true;

			} else {

				added = false;

			}


			if (PlayerPrefs.GetInt ((i).ToString() + "side") == 1) {

				side = true;

			} else {

				side = false;

			}

			if (PlayerPrefs.GetInt ((i).ToString() + "active") == 1) {

				active = true;

			} else {

				active = false;

			}

			if (PlayerPrefs.GetInt ((i).ToString() + "shoot") == 1) {

				shoot = true;

			} else {

				shoot = false;

			}

			if (PlayerPrefs.GetInt ((i).ToString() + "aim") == 1) {

				aim = true;

			} else {

				aim = false;

			}


			Weapon.weapons [i].onArea = onArea;
			Weapon.weapons [i].added = added;
			Weapon.weapons [i].side = side;
			Weapon.weapons [i].active = active;
			Weapon.weapons [i].shoot = shoot;
			Weapon.weapons [i].aim = aim;

			Weapon.weapons [i].lvl = PlayerPrefs.GetInt ((i).ToString() + "lvl");
			Weapon.weapons [i].price = PlayerPrefs.GetInt ((i).ToString() + "price");
			Weapon.weapons [i].slot_id = PlayerPrefs.GetInt ((i).ToString() + "slot_id");

			Weapon.weapons [i].ammo = PlayerPrefs.GetFloat ((i).ToString() + "ammo");
			Weapon.weapons [i].max_ammo = PlayerPrefs.GetFloat ((i).ToString() + "max_ammo");
			Weapon.weapons [i].reload_time = PlayerPrefs.GetFloat ((i).ToString() + "reload_time");
			Weapon.weapons [i].shoot_time = PlayerPrefs.GetFloat ((i).ToString() + "shoot_time");
			Weapon.weapons [i].ray_shoot = PlayerPrefs.GetFloat ((i).ToString() + "ray_shoot");
			Weapon.weapons [i].damage = PlayerPrefs.GetFloat ((i).ToString() + "damage");
			Weapon.weapons [i].damage_next = PlayerPrefs.GetFloat ((i).ToString() + "damage_next");
			Weapon.weapons [i].lvl_next = PlayerPrefs.GetFloat ((i).ToString() + "lvl_next");
			Weapon.weapons [i].shoot_time_next = PlayerPrefs.GetFloat ((i).ToString() + "shoot_time_next");


		}

		/** SLOT LOAD **/

		for (int i = 0; i < 6; i++) {

			GameObject slot = GameObject.Find ("slot_" + (i+1).ToString ());
			Slot slot_script = slot.GetComponent<Slot> ();

			bool busy;

			if (PlayerPrefs.GetInt((i+1).ToString() + "busy") == 1) {

				busy = true;

			} else {

				busy = false;

			}

			slot_script.busy = busy;
			slot_script.weaponID = PlayerPrefs.GetInt ((i + 1).ToString () + "weaponID");

		}

		/** LOAD GLOBAL **/
		GLOBAL.COINS = PlayerPrefs.GetInt ("COINS");
		GLOBAL.SCORE = PlayerPrefs.GetInt ("SCORE");
		GLOBAL.boss_type = PlayerPrefs.GetInt ("BOSS_TYPE");



		Debug.Log ("WCZYTYWANIE POWIODLO SIE");


	}

	public void SaveFile(int tutorial)
	{
		PlayerPrefs.SetInt ("Tutorial", tutorial);
		float bufor = GLOBAL.actualGameplayTime + GLOBAL.gameplayTime;
		PlayerPrefs.SetFloat ("Gameplay_time", bufor);

		PlayerPrefs.Save ();
	}

	public void LoadFile()
	{

		GLOBAL.tutorial = PlayerPrefs.GetInt ("Tutorial");
		GLOBAL.actualGameplayTime = PlayerPrefs.GetFloat ("Gameplay_time");



	}

		

}