using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour {

	// Update is called once per frame
	void Update () {

		Rend ();

	}

	void Rend()
	{

		if (GLOBAL.tutorial_pause == true && GLOBAL.tutorial_count > 12)
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		else
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;

	}
		
}
