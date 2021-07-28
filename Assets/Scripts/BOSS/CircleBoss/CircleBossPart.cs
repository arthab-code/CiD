using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBossPart : MonoBehaviour {

	bool up = true;
	// Update is called once per frame
	void Update () {

		Animation ();

	}

	void Animation()
	{
		if (transform.localScale.x > 1.1f)
			up = false;

		if (transform.localScale.x < 1)
			up = true;

		if (up == true) {
		transform.localScale += new Vector3 (0.01f, 0.01f);
		}

		if (up == false) {
			transform.localScale -= new Vector3 (0.01f, 0.01f);
		}

	}
}
