using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

		Rend ();

	}

	void Rend()
	{

		if (GLOBAL.tutorial_count > -1 && GLOBAL.tutorial_count < 11 && GLOBAL.tutorial_pause == true) {

			if (Spawner.ships.Count > 0 || GLOBAL.tutorial_count == 7 || GLOBAL.tutorial_count == 8
				|| GLOBAL.tutorial_count == 9 || GLOBAL.tutorial_count == 10 || GLOBAL.tutorial_count == 11 || GLOBAL.tutorial_count == 12) {

				gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		
			} else {

				gameObject.GetComponent<SpriteRenderer> ().enabled = true;

			}

		}


	}


}
