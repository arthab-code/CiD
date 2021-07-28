using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDestroyObject : MonoBehaviour {

	GameObject EARTH;
	Earth EARTH_SCRIPT;

	// Use this for initialization
	void Start () {

		EARTH = GameObject.Find ("earth");
		EARTH_SCRIPT = EARTH.GetComponent<Earth> ();

	}
	
	// Update is called once per frame
	void Update () {

		Move ();
		DestroyCollision ();

	}

	void Move()
	{

		transform.position -= new Vector3 (0, 1f);

	}

	void DestroyCollision()
	{

		if (transform.position.y < ( EARTH.GetComponent<SpriteRenderer> ().bounds.size.y / 2 ) + EARTH.transform.position.y) {

			Destroy (gameObject);
			Destroy (this);

			EARTH_SCRIPT.HP--;

		}

	}
}
