using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wave_screen : MonoBehaviour {


	// Update is called once per frame
	void Update () {

		Rend ();
	}

	void Rend()
	{

		if (GLOBAL.wave_pause == true && GLOBAL.tutorial_pause == false && GLOBAL.boss_active == false) {

			transform.position = new Vector3 (0, 0);

		} else {

			transform.position = new Vector3 (0, 80);

		}

	}
}
