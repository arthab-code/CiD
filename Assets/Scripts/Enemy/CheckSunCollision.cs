using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSunCollision : MonoBehaviour {

	public GameObject sun;
	public Sun        sunScript;
	public Ship       ship;

	float position_change = 5;

	// Use this for initialization
	void Awake () {

		sunScript = sun.GetComponent<Sun> ();                         /** użycie komponentu Sun z obiektu Sun **/
		sunScript.rend = sunScript.GetComponent<SpriteRenderer> ();   /** przypisanie komponentu SpriteRenderer z obiektu Sun poprzez wyłuksanie go ze skryptu **/
		ship = GetComponent<Ship> ();                                 /** Pobranie komponentu skryptu przeciwnika **/

	}
	
	// Update is called once per frame
	void Update () {

		CheckCollision ();	                                          /** Wywołanie metody sprawdzającej kolizje **/

	}

	/** Metoda sprawdzająca czy doszło do kolizji ze słońcem **/
	public void CheckCollision()
	{

		float height = sunScript.rend.bounds.size.y / 2;                                          /** wyliczenie wysokości słońca **/

		/** Warunek - gdu pozycja statku spadnie poniżej odpowiedniej pozycji słońca **/
		if (Spawner.ships.Count > 0) {
		
			for (int i = 0; i < Spawner.ships.Count; i++) {
			
				if (Spawner.ships[i].transform.position.y < SunSpawner.suns [0].transform.position.y + (height - 15)) {
			
					Sun.POS.y += position_change;                                                                        /** Dodanie do pozycji Y słońca odpowiedniej wartości **/
					Spawner.ships[i].Destroy ();                                                                       /** Wywołąnie metody niszczącej statek i skrypt SHip **/

				} 
			}
		}
	}
}
