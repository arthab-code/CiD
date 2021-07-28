using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wave_txt : MonoBehaviour {

	public Text wave;

	
	// Update is called once per frame
	void Update () {

		Rend ();

	}

	void Rend()
	{
		if (GLOBAL.WAVE == 0) {
			wave.text = "WAVE : " + (GLOBAL.WAVE + 1).ToString ();
		} else {
			wave.text = "WAVE : " + (GLOBAL.WAVE).ToString ();

		}
	}
}
