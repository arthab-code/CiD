using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteManager : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {

		Mute ();
	}

	void Mute()
	{

		if (GLOBAL.mute == true) {

			GetComponent<AudioSource> ().mute = true;


		} else {

			GetComponent<AudioSource> ().mute = false;

		}

	}
}
