using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour {

	float mag = 20f;

	float time = 0;
	float time_goal = 1f;


	// Update is called once per frame
	void Update () {

		DestroyTail ();
		Move ();

	}

	void DestroyTail()
	{
		time += Time.deltaTime;

		if (time > time_goal) {

			Destroy (this);
			Destroy (gameObject);

		}

	}

	void Move()
	{

		gameObject.transform.position += new Vector3(0, 0.1f);

	}

}
