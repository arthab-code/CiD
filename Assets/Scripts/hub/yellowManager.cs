using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowManager : MonoBehaviour {

	public GameObject YA;

	float time = 0;
	float timeGoal = 0.05f;
	
	// Update is called once per frame
	void Update () {

		time += Time.deltaTime;

		if (time > timeGoal) {

			Instantiate (YA);
			time = 0;
		}
		
	}
}
