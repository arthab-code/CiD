using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour {

	public static bool combo_active = false;

	public int combo_count;

	float time_to_kill = 0;
	float goal_time = 2f;
	int score_bufor = 0;
	int coins_bufor = 0;

	bool combo_end = false;

	public GameObject POINTER_COMBO;
	public GameObject COIN_SPAWNER;
	public GameObject COIN;

	public Text text_combo;


	// Update is called once per frame
	void Update () {

		ShowComboScreen ();
		TimeCount ();
		CheckDestroyedShip ();
		ComboActive ();
		ComboDeactive ();
		AddScore ();
		SetTextCombo ();

	}

	void TimeCount()
	{

		time_to_kill += Time.deltaTime;

		if (time_to_kill >= goal_time) {

			time_to_kill = 0;
			combo_count = 0;

		}

	}

	void CheckDestroyedShip()
	{
		ShipDestroy sd;
		int bufor = 0;

		for (int i = 0; i < Spawner.ships.Count; i++) {
			
			sd = Spawner.ships [i].gameObject.GetComponentInChildren<ShipDestroy> ();

			if (sd.destroyed == true) {

				if (time_to_kill < goal_time) {

					time_to_kill = 0;
					combo_count++;
					coins_bufor += (combo_count + 2) * Spawner.ships[i].coins;
					score_bufor += (2 * combo_count);

				} 

				sd.destroyed = false;
			 }

		} 

	}

	void ComboActive()
	{

		if (combo_count > 1) {

			combo_active = true;

		}

	}

	void ComboDeactive()
	{

		if (combo_active == true && combo_count == 0) {

			combo_active = false;
			combo_end = true;

		}

	}

	void AddScore()
	{

		if (combo_end == true) {

			combo_end = false;

			GLOBAL.SCORE += score_bufor;

			COIN.transform.position = COIN_SPAWNER.transform.position;

			int bufor = 0;

			for (int i = 0; i < coins_bufor; i++) {

				bufor = Random.Range (-2, 2);

				COIN.transform.position -= new Vector3 (0, bufor);

				Instantiate (COIN);

			}

			//GLOBAL.COINS += coins_bufor;
			score_bufor = 0;
			coins_bufor = 0;
		}

	}

	void ShowComboScreen()
	{

		if (combo_active == true) {

			transform.position = POINTER_COMBO.transform.position;

		} else {

			transform.position = new Vector3 (100f,30f);

		}

	}

	void SetTextCombo()
	{

		text_combo.text = combo_count.ToString ();

	}
}
