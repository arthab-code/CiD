using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit_screen : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {

		Rend ();
	}

	void Rend()
	{

		if (GLOBAL.exit_pause == true) {

			transform.position = new Vector3 (0, 0);

		} else {

			transform.position = new Vector3 (57, 80);

		}

	}
}
