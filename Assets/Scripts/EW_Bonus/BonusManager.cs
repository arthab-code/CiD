using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusManager : MonoBehaviour {

	bool hp_decrease     = false;
	bool speed_decrease  = false;
	bool bonus_active    = false;
	bool spawned = false;

	float hp_rate = 0.5f;
	float speed_rate = 0.5f;
	float bonus_rate = 1f;

	float sun_high_decrease = 10f;

	float time_to_spawn = 0;
	float goal_time = 60f;

	float bonus_time = 0f;
	float goal_bonus_time = 15f;

	bool bonus_stats = false;

	public GameObject LEFT_SPAWN;
	public GameObject RIGHT_SPAWN;

	public GameObject BONUS_SHIP;

	public GameObject EXIT;

	public GameObject border;

	public Text BONUS_TXT;
	public Text E_BONUS_TXT;

	int bufor_coins = 0;

	public static List<BonusShip> bs;

	enum BONUS
	{

		hp,
		speed,
		sun,
		none

	};

	BONUS type_bonus;

	float posXspr;
	float posYspr;
	float width;
	float height;


	void Awake()
	{

		bs = new List<BonusShip> ();

	}

	// Update is called once per frame
	void Update () {

		AreaClick ();
		RendScreen ();
		BonusTxt ();
		ExtraBonusTxt ();
		AfterAreaBonus ();

		if (GLOBAL.WAVE > 0) {

			/** SPAWN STATKU BONUSOWEGO **/
			TimeDestination ();
			TimeCount ();

		}

		if (GLOBAL.bonus_pause == true) {
			
			if (bonus_stats == false) {

				SelectBonus ();
				SetBonusStats ();

				bonus_stats = true;

			}

		}

		if (bonus_active == true) {
		
			CountBonusTime ();
			SetBonusOnShips ();
			EndBonus ();
		
		}
	}

	void TimeCount()
	{
		if (bonus_active == false) {

			time_to_spawn += Time.deltaTime;

		}
	}

	void TimeDestination()
	{

		if (time_to_spawn >= goal_time && GLOBAL.bonus_pause == false) {

			SpawnerShip ();

		}

	}

	void SelectBonus()
	{

		if (GLOBAL.bonus_pause == true && time_to_spawn >= goal_time) {
			
			RandomBonus ();
			time_to_spawn = 0;

		}

	}

    void SetBonusOnShips()
	{
		if (Spawner.ships.Count > 0) {
			
			for (int i = 0; i < Spawner.ships.Count; i++) {

				if (Spawner.ships[i].bonus == false) {
			

					if (type_bonus == BonusManager.BONUS.hp)
					Spawner.ships[i].hp = Spawner.ships[i].hp * hp_rate;

					if (type_bonus == BonusManager.BONUS.speed)
					Spawner.ships[i].speed = Spawner.ships[i].speed * speed_rate;
			
					Spawner.ships[i].bonus = true;
				}

			}
		}
	} 

	void CountBonusTime()
	{

		if (bonus_active == true && GLOBAL.bonus_pause == false) {

			bonus_time += Time.deltaTime;

		}

	}

	void SetBonusStats()
	{

			if (type_bonus == BONUS.hp) {

				//hp_rate = 0.5f;

			} else if (type_bonus == BONUS.speed) {

				//speed_rate = 0.5f;

			} else if (type_bonus == BONUS.sun) {

				/** BONUS SŁOŃCA **/


			} 

		bufor_coins = (GLOBAL.WAVE + 2) * Random.Range(10,20);

	}

	void EndBonus()
	{

		if (type_bonus == BonusManager.BONUS.sun) {

			bonus_time = goal_bonus_time;

		}

		if (bonus_active == true && bonus_time >= goal_bonus_time) {

			for (int i = 0; i < Spawner.ships.Count; i++) {

				if (Spawner.ships [i].bonus == true) {

					if (type_bonus == BonusManager.BONUS.hp)
						Spawner.ships[i].hp = Spawner.ships[i].hp / hp_rate;

					if (type_bonus == BonusManager.BONUS.speed)
						Spawner.ships[i].speed = Spawner.ships[i].speed / speed_rate;

					Spawner.ships [i].bonus = false;
				}

			}

			bonus_active = false;
			bonus_time = 0f;
			spawned = false;
			bonus_stats = false;
			type_bonus = BonusManager.BONUS.none;

		}

	}
 
	void RandomBonus()
	{
		
		int bufor = Random.Range (0, 3);

		if (bufor == 0) {
		
			type_bonus =  BONUS.hp;
		
		} else if (bufor == 1) {

			type_bonus =  BONUS.speed;

		} else if (bufor == 2) {

			type_bonus = BONUS.sun;
		}
	}

	void RandSpawnVector ()
	{

		int Bufor = Random.Range (0, 2);        /** Bufor losujący, który punkt respawnu ma być aktywowany **/

		if (Bufor == 0) {

			BONUS_SHIP.transform.position = LEFT_SPAWN.transform.position;

		} else if (Bufor == 1) {

			BONUS_SHIP.transform.position = RIGHT_SPAWN.transform.position;

		}


     }

	void SpawnerShip()
	{
		if (spawned == false) {
		
			RandSpawnVector ();

			GameObject go = Instantiate (BONUS_SHIP);

			spawned = true;
			bs.Add(go.GetComponent<BonusShip>());

		}

	}

	void RendScreen()
	{

		if (GLOBAL.bonus_pause == true) {

			transform.position = new Vector3 (0, 0);

		} else {

			transform.position = new Vector3 (-56, -79);

		}

	}

	void AfterAreaBonus()
	{

		if (bs.Count > 0) {
						
			if (bs [0].transform.position.y <= border.transform.position.y) {
				
				bonus_time = goal_bonus_time;
				bonus_active = false;
				bonus_time = 0f;
				spawned = false;
				bonus_stats = false;
				type_bonus = BonusManager.BONUS.none;
				time_to_spawn = 0;
				Destroy (bs[0].gameObject);
				bs.Remove (bs [0]);

			}
			
		}

	}

	void AreaClick()
	{

		Vector2 tpos;                                                        /** Zmienna pomocnicza przechowująca wspłrzędne dotkniętego punktu na ekranie **/
		posXspr = EXIT.transform.position.x;    
		posYspr = EXIT.transform.position.y;   

		width = EXIT.GetComponent<SpriteRenderer>().bounds.size.x / 2;
		height = EXIT.GetComponent<SpriteRenderer>().bounds.size.y / 2;

		/** Warunek sprawdzający, czy został dotknięty ekran **/
		if (Input.touchCount > 0) {

			Touch touch = Input.GetTouch (0);                                /** Zmienna przechwycająca dotknięcie ekranu **/

			/** Warunek sprawdzający czy faza dotknięcia jest fazą początkową (dotknięcie ekranu) **/

			if (Input.GetTouch (0).phase == TouchPhase.Began) {

				tpos = Camera.main.ScreenToWorldPoint (touch.position);      /** Zmienna pomocnicza przechwytująca pozycję dotknięcia skonwertowaną do odpowiednich koordynatów kamery **/

				/** Warunek sprawdzający czy dotknięcie ekranu mieści się w prawidłowym zakresie **/
				if (tpos.x > posXspr - width && tpos.x < posXspr + width
					&& tpos.y > posYspr - height && tpos.y < posYspr + height && gameObject.GetComponent<SpriteRenderer> ().enabled == true) {

					GLOBAL.bonus_pause = false;
					bonus_active = true;


				}

			}

		}

	}


	void BonusTxt()
	{

		if (type_bonus == BonusManager.BONUS.hp) {

			BONUS_TXT.text = "HP DECREASE";

		}

		if (type_bonus == BonusManager.BONUS.speed) {

			BONUS_TXT.text = "SPEED DECREASE";

		}

		if (type_bonus == BonusManager.BONUS.sun) {

			BONUS_TXT.text = "SUN DECREASE";

		}

	}

	void ExtraBonusTxt()
	{

		E_BONUS_TXT.text = bufor_coins.ToString ();

	}

}
