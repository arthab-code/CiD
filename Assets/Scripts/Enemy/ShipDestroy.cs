using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDestroy : MonoBehaviour {

	private Sprite              spriteAnim;
	private SpriteRenderer      rend;
	private Ship                shipScript;
	private float               time;
	private Animator            anim;
	AudioSource audio;
	bool audioPlay = false;
	public bool                 destroyed  = false;
	public bool  setDestroyed = false;

	// Use this for initialization
	void Awake () {

		shipScript = GetComponentInParent<Ship> ();
		rend = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();

		spriteAnim = Resources.Load<Sprite> ("Animation/Ships/Destroy/destroy");    /** Wgranie i **/
		rend.sprite = spriteAnim;                                                   /** wyswietlenie sprajta **/ 
		 
		transform.position = shipScript.transform.position;                         /** Ustalenie pozycji pocztakowej naimacji na pozycje rodzica **/
	
		//anim.transform.localScale = new Vector3 (5, 5, 0);

		time = 0;                                                                   /** Ustawienie zmiennej time na 0 **/
		anim.enabled = false;                                                       /** Wylaczenie wyswietlania animacji **/
		rend.enabled = false;                                                       /** Wylaczenie wyswietlania spritea obiektu ShipDestroy **/
	
		
	}
		

	public void DestroyShipAnim()
	{
		if (setDestroyed == false) {

			destroyed = true;
			setDestroyed = true;

		}

		shipScript.rend.enabled = false;                                            /** ustawienie wyswietlanie grafiki przeciwnika na false **/
		rend.enabled = true;                                                        /** ustawienie wyswielania grafiki sprajta Ship Destroy na true **/ 
		anim.enabled = true;                                                        /** ustawienie animacji na true **/
		rend.transform.localScale = new Vector3 (3f, 3f);
		anim.Play ("destroy_bufor");                                                  /** rozpoczecie animowania sprajta **/

		audio.transform.position = transform.position;

		shipScript.hit = true;

		if (audio.isPlaying == false && audioPlay == false) {

			audio.Play ();
			audioPlay = true;

		}

		time += Time.deltaTime;                                                     /** Dodanie do zmiennej time przemijającego czasu **/

		if (time >= 0.66) {                                                           /** jeśli time jest większy od 0.66 dochodzi do uuchomienia funkcji niszczącej cały obiekt Ship **/
			shipScript.DestroyWin ();

			return;
		}


	}
		


}
