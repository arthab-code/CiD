using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {

	public GameObject COIN;

	// Use this for initialization
	void Awake () {

		COIN.transform.position = new Vector3(0f, 0f);
		Instantiate (COIN);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
