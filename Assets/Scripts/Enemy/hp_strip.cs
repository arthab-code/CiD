using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp_strip : MonoBehaviour {

	public SpriteRenderer      rend;      /** Obiekt renderujący spritea **/
	public Sprite             strip;      /** Sprite hapeka **/
	private Ship               ship;

	void Awake()
	{
		
		ship = GetComponentInParent<Ship> ();                                              /** uzyskanie komponentu z rodzica **/
		rend = GetComponent<SpriteRenderer> ();                                            /** uzyskanie komponentu Sprite Renderer umożliwiającego wyświetlanie sprajta **/

	}

	void FixedUpdate()
	{

		if (ship.hp > 0) {

			Renderer ();                                                                        /** wywołanie metody wyświetlającej pasek hp **/
		
		} else {

			rend.enabled = false;                                                               /** jesli hp spadnie ponizej zera wylacz renderowanie paska hp **/

		}

	}

	/** Metoda wyświetlająca pasek hp **/
	public void Renderer () {

			/** Jeśli HP jest różne od MAX HP przeciwnika wtedy dopiero zacznie wyświetlać się pasek **/
			if (ship.hp != ship.hp_max) {
			
				strip = Resources.Load<Sprite> ("Animation/Ships/hp_strip");                    /** Wgranie sprajta paska hp **/

				rend.sprite = strip;                                                            /** wyswietlenie sprajta **/

				this.transform.position = ship.transform.position;                              /** przyjęcie pozycji rodzica **/
				this.transform.position += new Vector3 (0, (ship.rend.bounds.size.y / 2), 0);     /** funkcja ustawiająca sprajta paska hp na górnej krawędzi statku **/
				float size_strip = 20 * (ship.hp / ship.hp_max);                                /** funkcja obliczająca szerokośc paska **/

				this.rend.transform.localScale = new Vector3 (size_strip, 1f);                  /** zmiana skali paska hp **/

			}

	}
		

}
