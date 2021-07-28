using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour {

	// Use this for initialization
	void Start() {

		SceneManager.LoadSceneAsync ("_gameplay_0");

	}
	

}
