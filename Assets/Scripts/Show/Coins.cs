using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour {

	public Text coins;


	// Update is called once per frame
	void Update () {

		coins.text = GLOBAL.COINS.ToString ();

	}
}
