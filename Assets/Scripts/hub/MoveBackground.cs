using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += new Vector3 (0f, 0.03f);

		if (transform.position.y > 40f) {

			transform.position = new Vector3 (0f, -31.14f);

		}

	}
}
