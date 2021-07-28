using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveScore : MonoBehaviour {

	public Text waveScore;

	
	// Update is called once per frame
	void Update () {

		waveScore.text = GLOBAL.WAVE.ToString ();

	}
}
