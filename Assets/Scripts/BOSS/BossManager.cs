using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour {

	bool resp = false;

	public Text tip_text;
	bool tip_text_show = false;
	float time_text = 0;
	float time_goal_text = 10f;

	public Text timer;


	float time_show_message_boss = 0;
	float goalTime = 2f;

	public GameObject CIRCLE_BOSS;

	public GameObject BOSS_MESSAGE;
	bool message_show = true;

	bool active_current_boss = false;

	public static float BOSS_TIME_LIFE = 0;
	public static float LIFE_TIME_BOSS;
	// Update is called once per frame
	void Start()
	{

		tip_text.enabled = false;
		timer.enabled = false;

	}

	void Update () {

		ShowMessage ();
		CircleBossRespawn ();

		TextShow ();

		Timer ();

	}

	void CircleBossRespawn()
	{

		if (GLOBAL.boss_type == 0 && GLOBAL.boss_active == true && resp == true) {

			CIRCLE_BOSS.transform.position = new Vector2 (0f, 0f);
			Instantiate (CIRCLE_BOSS);

			tip_text_show = true;

			resp = false;

		}

	}

	void ShowMessage()
	{

		if (GLOBAL.boss_active == true) {

			if (active_current_boss == false) {
				
				time_show_message_boss += Time.deltaTime;

				BOSS_MESSAGE.transform.position = new Vector2 (0f, 0f);

				if (time_show_message_boss > goalTime) {

					active_current_boss = true;
					resp = true;
					time_show_message_boss = 0;

				} 

			} else {

				BOSS_MESSAGE.transform.position = new Vector2 (100f, 6f);

			}

		} else {

			active_current_boss = false;

		}

	}



	void TextShow()
	{

		if (tip_text_show == true) {
			
			tip_text.enabled = true;

			TextTimeCount ();

			if (GLOBAL.boss_type == 0) {

				tip_text.text = "Te pulsujace trojkaty sa denerwujace, nieprawdaz?";

			} 

		}else {

			tip_text.enabled = false;
		}

	}

	void TextTimeCount()
	{

		time_text += Time.deltaTime;

		if (time_text > time_goal_text) {

			tip_text_show = false;
			time_text = 0;

		}

	}

	void Timer()
	{

		if (GLOBAL.boss_active == true) {

			float count = LIFE_TIME_BOSS - BOSS_TIME_LIFE;
			int lol = (int) count;
			timer.text = lol.ToString ();
			timer.enabled = true;

		} else {

			timer.enabled = false;

		}

	}
}
