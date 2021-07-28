using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellow_anim : MonoBehaviour {

	// Use this for initialization
	void Awake () {

		float posX = Random.Range (-20, 20);
		float posY = Random.Range (-35, 20);

		int randomFlip = Random.Range (0, 1);

		if (randomFlip == 0) {

			gameObject.GetComponent<SpriteRenderer> ().flipX = true;

		} else {

			gameObject.GetComponent<SpriteRenderer> ().flipX = false;

		}

		transform.position = new Vector3 (posX, posY);

	}
	
	// Update is called once per frame
	void Update () {

		DestroyAnim ();

	}

	void DestroyAnim()
	{

		if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo (0).normalizedTime >= 1) {

			Destroy (gameObject);
			Destroy (this);

		}

	}
}
