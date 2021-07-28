using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPart : MonoBehaviour {

	public float hp;
	public float max_hp;

	// Use this for initialization
	void Awake () {

		if (GLOBAL.boss_type == 0) { // CIRCLE BOSS

			max_hp = 100;
			hp = max_hp;
		
		}
	}
	
	// Update is called once per frame
	void Update () {

		CheckHp ();

	}

	void CheckHp()
	{

		if (hp <= 0) {

			Spawner.BossParts.Remove(this);
			Destroy (gameObject);
			Destroy (this);

		}

	}
}
