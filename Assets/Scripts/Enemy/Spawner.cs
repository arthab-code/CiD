using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Skrypt spawnujący na ekranie statki **/

public class Spawner : MonoBehaviour
{

	public GameObject ship;
	/** Referencja do prefabrykatu Ship**/
	public Vector2 pos;
	/** Zmienna pomocnicza przechowująca pozycję obiektu ship **/
	public int count = 0;
	/** Zmienna kontrolująca liczbę respawnowanych przeciwnikow **/
	float SpawnDelay;
	/** Zmienna przechowująca dane dotyczące czasu wstrzymania respawnu **/
	float SpawnDelayTime = 0;

	bool setEnemiesShow = false;

	bool AddWave = true;

	public static List<Ship> ships; /** Lista statków **/
	public static List<BossPart> BossParts;


	public GameObject LEFT_SPAWN;
	public GameObject RIGHT_SPAWN;

	float time = 0;
	float goalTime = 2f;

	public GameObject WAVE_CLEAR;
	bool show_wave_clear = false;

	bool BOSS_MANAGER = true;

	void Start ()
	{
		ships = new List<Ship> ();
		BossParts = new List<BossPart> ();
	}

	void Update ()
	{
		if (GLOBAL.shop_pause == false && GLOBAL.pause == false && GLOBAL.wave_pause == false && GLOBAL.exit_pause == false && GLOBAL.gameover_pause == false
			&& GLOBAL.tutorial_pause == false && GLOBAL.bonus_pause == false) {
			Respawn ();                                                                   /** Uruchomienie metody Respawnu **/
		}
			
		Check ();
		ShowWaveClear ();
	}


	/** Funkcja respawnująca przeciwnika **/
	void Respawn ()
	{
			            
			SpawnDelay = GLOBAL.spawnDelay - (GLOBAL.WAVE / GLOBAL.divisionTime);         /** Obliczenie opóźnienia respawnu **/

			Enemies ();                                                                   /** Obliczenie liczby przeciwników **/

			RandSpawnVector ();                                                           /** Uruchomienie funkcji odpowiadającej za losowe ustawienie punktu respawnu **/

			/** Warunek określający maksymalną liczbę respawnujących się przeciwników **/
		if (count < GLOBAL.enemies && ships.Count < 15) { //GLOBAL.enemies        

				SpawnDelayTime += Time.deltaTime;

				/** Warunek powodujący respawn co określoną ilość czasu, zwiększenie licznika wrogów **/
				if (SpawnDelayTime >= SpawnDelay) {
					
					GameObject go = Instantiate (ship);
			    	Ship s = go.GetComponent<Ship> ();
					ships.Add (s);              
					count++;   
					SpawnDelayTime = 0;

				}

			}


		//
						    
	}

	void Check()
	{


		/** Jeśli licznik jest równy liczbie przeciwników zeruj licznik i dodaj fale **/
		if (count == GLOBAL.enemies || GLOBAL.WAVE <= 0) { 

			if (ships.Count <= 0) {

				if (GLOBAL.gameover_pause == false && GLOBAL.bonus_pause == false && GLOBAL.boss_active == false) {

					/** TUTAJ INSTRUKCJE POKAZUJACE TEKST WAVE CLEAR **/

					time += Time.deltaTime;

					if (GLOBAL.tutorial_pause == false){
							
							show_wave_clear = true;


					} 

					if (time >= goalTime) {

						if (GLOBAL.boss_active == false){

							BossSelectManager ();

							if (AddWave == true && GLOBAL.tutorial_pause == false && GLOBAL.boss_active == false) {

							    GLOBAL.WAVE++;

						    	AddWave = false;

						  }

						  GLOBAL.wave_pause = true;
						  time = 0;

						}
					}

				} else {
					
					GLOBAL.wave_pause = false;

				}


			} else {

				time = 0;

			}
		}

		if (GLOBAL.wave_check == true) {

			BOSS_MANAGER = true;
			GLOBAL.wave_pause = false;
			GLOBAL.wave_check = false;
			count = 0;
			setEnemiesShow = false;
			AddWave = true;
			show_wave_clear = false;

		}

	}
		

	/** Funkcja obliczająca ilu przeciwników w danej fali ma się generować **/
	void Enemies ()
	{
		if (GLOBAL.WAVE < 25) {
			
			if (GLOBAL.WAVE >= 1 && GLOBAL.WAVE <= 4) {
		
				GLOBAL.enemies = 5;
		
			} else if (GLOBAL.WAVE >= 5 && GLOBAL.WAVE <= 9) {
		
				GLOBAL.enemies = 8;
		
			} else if (GLOBAL.WAVE >= 10 && GLOBAL.WAVE <= 14) {

				GLOBAL.enemies = 10;

			} else if (GLOBAL.WAVE >= 15 && GLOBAL.WAVE <= 19) {

				GLOBAL.enemies = 12;

			} else if (GLOBAL.WAVE >= 20 && GLOBAL.WAVE <= 24) {

				GLOBAL.enemies = 20;
		
			} 
		}


		if (GLOBAL.WAVE >= 25) {

			if (GLOBAL.WAVE >= 25 && GLOBAL.WAVE <= 29) {

				GLOBAL.enemies = 15;

			} else if (GLOBAL.WAVE >= 30 && GLOBAL.WAVE <= 34) {

				GLOBAL.enemies = 20;

			} else if (GLOBAL.WAVE >= 35 && GLOBAL.WAVE <= 39) {

				GLOBAL.enemies = 26;

			} else if (GLOBAL.WAVE >= 40 && GLOBAL.WAVE <= 44) {

				GLOBAL.enemies = 32;

			} else if (GLOBAL.WAVE >= 45 && GLOBAL.WAVE <= 49) {

				GLOBAL.enemies = 45;

			} 
		}

		if (setEnemiesShow == false) {

			GLOBAL.bufor_enemies = GLOBAL.enemies;
			setEnemiesShow = true;

		}

	}

	/** Funkcja ustawiająca losowy punkt respawnu przeciwników **/
	void RandSpawnVector ()
	{
							        
		int Bufor = Random.Range (0, 2);        /** Bufor losujący, który punkt respawnu ma być aktywowany **/
//		pos = ship.transform.position;

		if (Bufor == 0) {

			ship.transform.position = LEFT_SPAWN.transform.position;

		} else if (Bufor == 1) {

			ship.transform.position = RIGHT_SPAWN.transform.position;

		}



	}

	void ShowWaveClear()
	{

		if (show_wave_clear == true ) {

			if (GLOBAL.boss_active == false) {
				WAVE_CLEAR.transform.position = new Vector2 (0f, 0f);
			} else {
				WAVE_CLEAR.transform.position = new Vector2 (100f, 19f);
			}

		} else {

			WAVE_CLEAR.transform.position = new Vector2 (100f, 19f);

		}

	}

	void BossSelectManager()
	{

		/** CIRCLE BOSS **/
		if (BOSS_MANAGER == true) {
			
			if (GLOBAL.WAVE == 24 && GLOBAL.WAVE >= PlayerPrefs.GetInt("WaveBufor")) {
				
				show_wave_clear = false;
				GLOBAL.boss_active = true;
				BOSS_MANAGER = false;

			}
		}
	}

}
