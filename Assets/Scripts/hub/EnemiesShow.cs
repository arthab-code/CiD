using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesShow : MonoBehaviour {

	public Text show;

	// Update is called once per frame
	void Update () {


		if (GLOBAL.bufor_enemies < 0)
			GLOBAL.bufor_enemies = 0;

		show.text = GLOBAL.bufor_enemies.ToString ();

	}
}
