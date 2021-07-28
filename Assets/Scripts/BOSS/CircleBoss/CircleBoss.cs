using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBoss : MonoBehaviour {

	float angle = 0;

	public GameObject part1;
	public GameObject part2;
	public GameObject part3;
	public GameObject part4;


	void Awake()
	{

		Spawner.BossParts.Add(part1.GetComponent<BossPart>());
		Spawner.BossParts.Add(part2.GetComponent<BossPart>());
		Spawner.BossParts.Add(part3.GetComponent<BossPart>());
		Spawner.BossParts.Add(part4.GetComponent<BossPart>());

		BossManager.LIFE_TIME_BOSS = 15f;

	}

	// Update is called once per frame
	void Update () {


		BossManager.BOSS_TIME_LIFE += Time.deltaTime;

		angle += 1f;

		if (angle >= 360)
			angle = 0;
		
		transform.rotation = Quaternion.AngleAxis (angle, new Vector3 (0, 0, angle));

		DestroyObject ();

	}

	void DestroyObject()
	{

		if (Spawner.BossParts.Count <= 0) {

			GLOBAL.boss_active = false;
			GLOBAL.boss_type ++;
			GLOBAL.COINS += 2000;
			GLOBAL.SCORE += 10000;
			Destroy (gameObject);
			Destroy (this);

		}

		if (BossManager.BOSS_TIME_LIFE > BossManager.LIFE_TIME_BOSS) {
		
			GLOBAL.gameover_pause = true;
			BossManager.LIFE_TIME_BOSS = 0;
			BossManager.BOSS_TIME_LIFE = 0;
			Spawner.BossParts.Clear ();
			Destroy (gameObject);
			Destroy (this);

		}

	}


}
