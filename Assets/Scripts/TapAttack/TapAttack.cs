using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapAttack : MonoBehaviour {

	private float   dmg;
	private int     lvl;
	private int     price;

	public GameObject   hit_anim;
	public Ship         shipScript;

	float posXship;
	float posYship;
	float width;
	float height;


	// Use this for initialization
	void Awake () {
	                                           
		//shipScript = ship.GetComponent<Ship> ();                             /** pobranie **/
		//shipScript.rend = shipScript.GetComponent<SpriteRenderer> ();   /** komponentów **/


	}
	
	// Update is called once per frame
	void Update () {

	//	if (GLOBAL.shop_pause == false && GLOBAL.pause == false && GLOBAL.wave_pause == false && GLOBAL.exit_pause == false || GLOBAL.tutorial_pause == true) {


			AreaClick ();
			
	//	}


	}


	/** Metoda kolidująca touch pad ze statkiem oraz odbierająca punkty życia przeciwnikowi **/
	void AreaClick()
	{
		Vector2 tpos;                                                        /** Zmienna pomocnicza przechowująca wspłrzędne dotkniętego punktu na ekranie **/
		int j = 0;
		while (j < Input.touchCount){
			/** Warunek sprawdzający, czy został dotknięty ekran **/
			if (Input.touchCount > 0) {

				Touch touch = Input.GetTouch (j);                                /** Zmienna przechwycająca dotknięcie ekranu **/
				/** Warunek sprawdzający czy faza dotknięcia jest fazą początkową (dotknięcie ekranu) **/

			if (Input.GetTouch(j).phase == TouchPhase.Began) {
				
					tpos = Camera.main.ScreenToWorldPoint (touch.position);      /** Zmienna pomocnicza przechwytująca pozycję dotknięcia skonwertowaną do odpowiednich koordynatów kamery **/
				
					GameObject go = Instantiate (hit_anim);
					go.transform.position = tpos;

				/** PĘTLA SPRAWDZAJĄCA KAŻDY STATEK - CZY ZOSTAŁ DOTKNIĘTY **/
						
						for (int i = 0; i < Spawner.ships.Count; i++) {

							posXship = Spawner.ships [i].GetComponent<Ship> ().transform.position.x;    
							posYship = Spawner.ships [i].GetComponent<Ship> ().transform.position.y;   

							width = Spawner.ships [i].GetComponent<Ship> ().rend.bounds.size.x / 2;
							height = Spawner.ships [i].GetComponent<Ship> ().rend.bounds.size.y / 2;	

							/** Warunek sprawdzający czy dotknięcie ekranu mieści się w prawidłowym zakresie **/
							if (tpos.x > posXship - width && tpos.x < posXship + width
							  && tpos.y > posYship - height && tpos.y < posYship + height && tpos.y < 23f) {

								Spawner.ships [i].hp -= Weapon.weapons [14].damage;   /** Odebranie określonej liczby punktów życia **/

							}  // Collider



						} // PĘTLA FOR
							

					if (GLOBAL.boss_active == true) {

						for (int i = 0; i < Spawner.BossParts.Count; i++) {

							posXship = Spawner.BossParts [i].GetComponent<BossPart> ().transform.position.x;    
							posYship = Spawner.BossParts [i].GetComponent<BossPart> ().transform.position.y;   

							width = Spawner.BossParts [i].GetComponent<BossPart> ().GetComponent<SpriteRenderer>().bounds.size.x / 2;
							height = Spawner.BossParts [i].GetComponent<BossPart> ().GetComponent<SpriteRenderer>().bounds.size.y / 2;	

							/** Warunek sprawdzający czy dotknięcie ekranu mieści się w prawidłowym zakresie **/
							if (tpos.x > posXship - width && tpos.x < posXship + width
								&& tpos.y > posYship - height && tpos.y < posYship + height && tpos.y < 23f) {

								Spawner.BossParts [i].hp -= Weapon.weapons [14].damage;   /** Odebranie określonej liczby punktów życia **/

							}  // Collider



						} // PĘTLA FOR

					}
					

				} // Touch Phase
				
     
			} // TouchCount

			j++;

	      } // WHILE

		}



}

