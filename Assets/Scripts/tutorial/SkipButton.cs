using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButton : MonoBehaviour {

	// Update is called once per frame
	void Update () {

		Rend ();

	}

	void Rend()
	{

		if (GLOBAL.tutorial_pause == true && GLOBAL.tutorial_count < 13 && GLOBAL.tutorial_count != 8 && GLOBAL.tutorial_count != 9 && GLOBAL.tutorial_count != 10 
			&& GLOBAL.tutorial_count != 11)
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		else
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;

	}

}
