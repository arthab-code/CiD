using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text_coins : MonoBehaviour {

	public Text COINS;
	void Awake()
	{

		COINS.font = Resources.Load<Font> ("pixel");


	}
	// Update is called once per frame
	void Update () {

		COINS.text = GLOBAL.COINS.ToString ();
		
	}
}
