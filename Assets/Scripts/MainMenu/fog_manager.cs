using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fog_manager : MonoBehaviour {

	bool right = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (right == true) {

			transform.position += new Vector3 (0.001f, -0.001f);
		
		} else {

			transform.position -= new Vector3 (0.001f, -0.001f);

		}

		if (transform.position.x > 0.8f) {

			right = false;

		} else if (transform.position.x < -0.606) {

			right = true;

		}
			


	}
}
