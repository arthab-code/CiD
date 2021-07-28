using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTextPower : MonoBehaviour {

	public Text txt;

	Color ON, OFF;

	void Awake()
	{

		OFF = new Color (105f / 255f,12f / 255f,12f / 255f);
	    ON = new Color (24f / 255f,64 / 255f,6f / 255f);

	}

	// Update is called once per frame
	void Update () {

		if (GLOBAL.tutorial == 1) {

			txt.color = ON;
			txt.text = "ON";

		} else {
			txt.color = OFF;
			txt.text = "OFF";
		}

	}
}
