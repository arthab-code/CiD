using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	public float                       hp;
	public float                       hp_max;
	public float                       speed;
	public float                       max_speed;
	public int                         coins;

	public Vector2                     pos;

	public SpriteRenderer              rend;     /** Obiekt renderujący spritea **/
	public Sprite                      ship;     /** Sprite statku **/

	private ShipDestroy                sd;


	private int                        rand;

	public bool                        aimed = false; /** czy jest aktualnie namierzany ? **/
	public bool                        IN = false;

	public bool                        hit = false;

	public enum Type 
	{
		ship11, 
		ship12, 
		ship13, 
		ship21,
		ship22,
		ship23,
		ship24, 
		ship31, 
		ship32,
		ship33,
		ship41
	}

	public Type                        type;

	public bool bonus = false;
	public bool bonus_ship = false;

	public GameObject COIN;

	void Awake()
	{
		rend = GetComponent<SpriteRenderer> ();
		sd = GetComponentInChildren<ShipDestroy> ();
		//PlayerPrefs.DeleteAll ();
		RandomShip ();
		SetStats ();
		RenderSprite ();
	}

	void FixedUpdate()
	{

		if (GLOBAL.shop_pause == false && GLOBAL.pause == false && GLOBAL.wave_pause == false && GLOBAL.exit_pause == false 
			&& GLOBAL.gameover_pause == false && GLOBAL.bonus_pause == false || GLOBAL.tutorial_pause == true) {
			
			/** Jeśli hp jest większe od 0 poruszaj obiektem i renderuj spritea**/

			if (hp > 0) {
				Move ();

			}

		} 


	}

	void Update()
	{

		if (GLOBAL.shop_pause == false && GLOBAL.pause == false) {

		CheckHp ();

		} 

	}

	/**Metoda sprawdzająca liczbe punktów życia **/
	public void CheckHp()
	{

		if (hp <= 0) {

			sd.DestroyShipAnim ();

		}
				
		
	}

	/** Metoda wprawiająca w ruch Przeciwnika **/
	public void Move()
	{
		pos = transform.position;
		pos.y -= speed;
		transform.position = pos;

	}

	/** Metoda niszcząca obiekt Przeciwnika gdy wpadnie do słońca**/
	public void Destroy()
	{
		
		//Spawner.counts -=1;
		GLOBAL.bufor_enemies--;
		Spawner.ships.Remove (gameObject.GetComponent<Ship>());
		Destroy(gameObject);
		Destroy (this);

	}

	/** Metoda niszcząca obiekt Przeciwnika gdy gracz go zniszczy*/
	public void DestroyWin()
	{
		if (GLOBAL.tutorial_pause == true) {

			GLOBAL.tutorial_count++;

		} else {

			if (ComboManager.combo_active == false) {
				
				GLOBAL.SCORE++;
				COIN.transform.position = transform.position;
				Instantiate (COIN);

			}

			//GLOBAL.COINS += coins;

			if (type == Ship.Type.ship41) {

				GLOBAL.bonus_pause = true;

			}
		
		}

		GLOBAL.bufor_enemies--;

		Spawner.ships.Remove (gameObject.GetComponent<Ship>());
		Destroy (gameObject);
		Destroy (this);


	}

	/** Metoda ustawiająca statystyki utworzonego obiektu**/

	public void SetStats()
	{		
			switch (type) {

			case Ship.Type.ship11:

				hp = 30f;          /** Ustawienie poziomu HP **/
				hp_max = 30f;          /** Ustawienie poziomu max_HP **/
				speed = 0.1f;    /** Ustawienie prędkości spadania **/
				max_speed = speed;
				coins = Random.Range (2, 3);                             /** Ustawienie liczby wypadających coinsów **/

				break;

			case Ship.Type.ship12:

		    	hp = 100f;           /** Ustawienie poziomu HP **/
		    	hp_max = 100f;        /** Ustawienie poziomu max_HP **/
				speed = 0.08f;      /** Ustawienie prędkości spadania **/
				max_speed = speed;
				coins = Random.Range (3,4);                               /** Ustawienie liczby wypadających coinsów **/

				break;

			case Ship.Type.ship13:

			hp = 160f;        /** Ustawienie poziomu HP **/
			hp_max = 160f;         /** Ustawienie poziomu max_HP **/
				speed = 0.08f;      /** Ustawienie prędkości spadania **/
				max_speed = speed;
				coins = Random.Range (4, 5);                               /** Ustawienie liczby wypadających coinsów **/

				break;

			case Ship.Type.ship21:

			hp = 220f;          /** Ustawienie poziomu HP **/
			hp_max = 220f;        /** Ustawienie poziomu max_HP **/
				speed = 0.06f;     /** Ustawienie prędkości spadania **/
				max_speed = speed;
				coins = Random.Range (5, 6);                              /** Ustawienie liczby wypadających coinsów **/


				break;

			case Ship.Type.ship22:

			hp = 80f + ((GLOBAL.WAVE + 1) * GLOBAL.divisionHp);         /** Ustawienie poziomu HP **/
			hp_max = 80f + ((GLOBAL.WAVE + 1) * GLOBAL.divisionHp);           /** Ustawienie poziomu max_HP **/
				speed = 0.065f + (GLOBAL.WAVE / GLOBAL.divisionSpeed);     /** Ustawienie prędkości spadania **/
				max_speed = speed;
				coins = Random.Range (4, 5);                              /** Ustawienie liczby wypadających coinsów **/

				break;

			case Ship.Type.ship23:

			hp = 90f + ((GLOBAL.WAVE + 1) * GLOBAL.divisionHp);        /** Ustawienie poziomu HP **/
			hp_max = 90f + ((GLOBAL.WAVE + 1) * GLOBAL.divisionHp);         /** Ustawienie poziomu max_HP **/
				speed = 0.05f + (GLOBAL.WAVE / GLOBAL.divisionSpeed);     /** Ustawienie prędkości spadania **/
				max_speed = speed;
				coins = Random.Range (5, 6);                              /** Ustawienie liczby wypadających coinsów **/

				break;

			case Ship.Type.ship24:

			hp = 100f + ((GLOBAL.WAVE + 1) * GLOBAL.divisionHp);           /** Ustawienie poziomu HP **/
			hp_max = 100f + ((GLOBAL.WAVE + 1) * GLOBAL.divisionHp);      /** Ustawienie poziomu max_HP **/
				speed = 0.055f + (GLOBAL.WAVE / GLOBAL.divisionSpeed);       /** Ustawienie prędkości spadania **/
				coins = Random.Range (5, 7);                                /** Ustawienie liczby wypadających coinsów **/
				break;

			case Ship.Type.ship31:

			hp = 120f + ((GLOBAL.WAVE + 1) * GLOBAL.divisionHp);         /** Ustawienie poziomu HP **/
			hp_max = 120f + ((GLOBAL.WAVE + 1) * GLOBAL.divisionHp);           /** Ustawienie poziomu max_HP **/
				speed = 0.05f + (GLOBAL.WAVE / GLOBAL.divisionSpeed);      /** Ustawienie prędkości spadania **/
				max_speed = speed;
				coins = Random.Range (6, 8);                              /** Ustawienie liczby wypadających coinsów **/


				break;

			case Ship.Type.ship32:

			hp = 140f + ((GLOBAL.WAVE + 1) * GLOBAL.divisionHp);         /** Ustawienie poziomu HP **/
			hp_max = 140f + ((GLOBAL.WAVE + 1) * GLOBAL.divisionHp);         /** Ustawienie poziomu max_HP **/
				speed = 0.045f + (GLOBAL.WAVE / GLOBAL.divisionSpeed);        /** Ustawienie prędkości spadania **/
				max_speed = speed;
				coins = Random.Range (6, 9);                                /** Ustawienie liczby wypadających coinsów **/

				break;
	

			case Ship.Type.ship33:

			hp = 170f + ((GLOBAL.WAVE + 1) * GLOBAL.divisionHp);           /** Ustawienie poziomu HP **/
			hp_max = 170f + ((GLOBAL.WAVE + 1) * GLOBAL.divisionHp);          /** Ustawienie poziomu max_HP **/
				speed = 0.04f + (GLOBAL.WAVE / GLOBAL.divisionSpeed);        /** Ustawienie prędkości spadania **/
				max_speed = speed;
				coins = Random.Range (8, 10);                               /** Ustawienie liczby wypadających coinsów **/

				break;

			case Ship.Type.ship41:

			hp = 50f + ((GLOBAL.WAVE + 1) * GLOBAL.divisionHp);           /** Ustawienie poziomu HP **/
			hp_max = 50f + ((GLOBAL.WAVE + 1) * GLOBAL.divisionHp);           /** Ustawienie poziomu max_HP **/
				speed = 0.1f + (GLOBAL.WAVE / GLOBAL.divisionSpeed);        /** Ustawienie prędkości spadania **/
				max_speed = speed;
				coins = Random.Range (0, 0);                               /** Ustawienie liczby wypadających coinsów **/   

				break;

			}

	}


	/** Metoda renderująca sprite`a obiektu **/
	public void RenderSprite ()
	{
		
		Animator anim = gameObject.GetComponent<Animator> ();

			switch (type) {

			case Ship.Type.ship11:

				ship = Resources.Load<Sprite> ("Animation/Ships/ship11");
				rend.sprite = ship;

				anim.runtimeAnimatorController = Resources.Load ("Animator/ship11") as RuntimeAnimatorController;
				anim.Play ("ship11_anim");

				break;

			case Ship.Type.ship12:

				ship = Resources.Load<Sprite> ("Animation/Ships/ship12");
				rend.sprite = ship;

				anim.runtimeAnimatorController = Resources.Load ("Animator/ship12") as RuntimeAnimatorController;
				anim.Play ("ship12_anim");

				break;

			case Ship.Type.ship13:

				ship = Resources.Load<Sprite> ("Animation/Ships/ship13");
				rend.sprite = ship;

				anim.runtimeAnimatorController = Resources.Load ("Animator/ship13") as RuntimeAnimatorController;
				anim.Play ("ship13_anim");

				break;

			case Ship.Type.ship21:

				ship = Resources.Load<Sprite> ("Animation/Ships/ship21");
				rend.sprite = ship;

				anim.runtimeAnimatorController = Resources.Load ("Animator/ship21") as RuntimeAnimatorController;
				anim.Play ("ship21_anim");

				break;

			case Ship.Type.ship22:

				ship = Resources.Load<Sprite> ("Animation/Ships/ship22");
				rend.sprite = ship;

				anim.runtimeAnimatorController = Resources.Load ("Animator/ship22") as RuntimeAnimatorController;
				anim.Play ("ship22_anim");

				break;

			case Ship.Type.ship23:

				ship = Resources.Load<Sprite> ("Animation/Ships/ship23");
				rend.sprite = ship;

				anim.runtimeAnimatorController = Resources.Load ("Animator/ship23") as RuntimeAnimatorController;
				anim.Play ("ship23_anim");

				break;

			case Ship.Type.ship24:

				ship = Resources.Load<Sprite> ("Animation/Ships/ship24");
				rend.sprite = ship;

				anim.runtimeAnimatorController = Resources.Load ("Animator/ship24") as RuntimeAnimatorController;
				anim.Play ("ship24_anim");

				break;

			case Ship.Type.ship31:

				ship = Resources.Load<Sprite> ("Animation/Ships/ship31");
				rend.sprite = ship;

				anim.runtimeAnimatorController = Resources.Load ("Animator/ship31") as RuntimeAnimatorController;
				anim.Play ("ship31_anim");

				break;

			case Ship.Type.ship32:

				ship = Resources.Load<Sprite> ("Animation/Ships/ship32");
				rend.sprite = ship;

				anim.runtimeAnimatorController = Resources.Load ("Animator/ship32") as RuntimeAnimatorController;
				anim.Play ("ship32_anim");

				break;

			case Ship.Type.ship33:

				ship = Resources.Load<Sprite> ("Animation/Ships/ship33");
				rend.sprite = ship;

				anim.runtimeAnimatorController = Resources.Load ("Animator/ship33") as RuntimeAnimatorController;
				anim.Play ("ship33_anim");

				break;

		    case Ship.Type.ship41:

				ship = Resources.Load<Sprite> ("Animation/Ships/ship41");
				rend.sprite = ship;

				anim.runtimeAnimatorController = Resources.Load ("Animator/ship41") as RuntimeAnimatorController;
				anim.Play ("ship41_anim");

				break;

			}


	}

	/** Metoda ustawiająca typ wyliczeniowy respawnowanego statku **/
	public void SwitchRand()
	{

		switch (rand) {

		case 0:
			type = Type.ship11;
			break;

		case 1:
			type = Type.ship12;
			break;

		case 2:
			type = Type.ship13;
			break;

		case 3:
			type = Type.ship21;
			break;

		case 4:
			type = Type.ship22;
			break;

		case 5:
			type = Type.ship23;
			break;

		case 6:
			type = Type.ship24;
			break;

		case 7:
			type = Type.ship31;
			break;

		case 8:
			type = Type.ship32;
			break;

		case 9:
			type = Type.ship33;
			break;

		case 10:
			type = Type.ship41;
			break;

		}

	}

	/** Metoda losująca typy respawnujących się statkow w zależności od aktualnej fali **/
	public void RandomShip()
	{
		/** POZIOM PIERWSZY **/
		if (GLOBAL.WAVE >= 1 && GLOBAL.WAVE <= 4) {

			rand = 0;

		} else if (GLOBAL.WAVE >= 5 && GLOBAL.WAVE <= 9) {

			rand = 1;

		} else if (GLOBAL.WAVE >= 10 && GLOBAL.WAVE <= 14) {

			rand = 2;

		} else if (GLOBAL.WAVE >= 15 && GLOBAL.WAVE <= 19) {

			rand = 3;

		} else if (GLOBAL.WAVE >= 20 && GLOBAL.WAVE <= 24) {

			rand = Random.Range (0, 4);

			/** POZIOM DRUGI **/
		} else if (GLOBAL.WAVE >= 25 && GLOBAL.WAVE <= 29) {

			rand = 4;

		} else if (GLOBAL.WAVE >= 30 && GLOBAL.WAVE <= 34) {

			rand = 5;

		} else if (GLOBAL.WAVE >= 35 && GLOBAL.WAVE <= 39) {

			rand = 6;

		} else if (GLOBAL.WAVE >= 40 && GLOBAL.WAVE <= 44) {

			rand = 7;

		} else if (GLOBAL.WAVE >= 45 && GLOBAL.WAVE <= 49) {

			rand = Random.Range (4, 8);

		} else if (GLOBAL.WAVE == 0) {

			rand = 0;

		} else {

			rand = Random.Range (0, 10);

		}
			

		SwitchRand ();                            /** Wywołanie funkcji odpowiedzialnej za przypisanie typowi wyliczeniowemu odpowiedniej wartości */
	}



}
