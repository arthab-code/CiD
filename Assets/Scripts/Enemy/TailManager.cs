using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailManager : MonoBehaviour {

	public GameObject TAIL;

	float time = 0;
	float time_goal = 0.05f;
	
	// Update is called once per frame
	void Update () {

		TailSpawner ();

	}

	public void TailSpawner () {
		
		time += Time.deltaTime;
			   
		if (time > time_goal) {

			int random = Random.Range (-1, 2);

			TAIL.transform.position = new Vector3(gameObject.transform.position.x + random, gameObject.transform.position.y);


			Instantiate (TAIL);


			time = 0;

		}

	}
}
