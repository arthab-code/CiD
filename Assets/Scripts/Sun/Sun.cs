using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {
	
	public static Vector2    POS;

	public float             MoveSTep     = 10f;

	public Sprite            sprite;
	public SpriteRenderer    rend;

	public bool up = true;

	GameObject SunPointer;

	void Awake()
	{
		SunPointer = GameObject.Find ("sun_pointer");
		POS = SunPointer.transform.position;
		rend = GetComponent<SpriteRenderer> ();        /** Pobranie komponentu SpriteRenderer **/
		SetPosition ();                                /** Metoda wywołująca ustawienie pozycji słońca **/
		Renderer ();                                   /** Metoda wyświetlająca słońce **/
	}
		
	void Update()
	{
		if (GLOBAL.shop_pause == false && GLOBAL.pause == false && GLOBAL.gameover_pause == false) {

			Move ();                                       /** Metoda poruszająca słońcem **/
			GameOverPause ();

		} else {

		}

	}


	/** Metoda wywołująca ustawienie pozycji słońca **/
	public void SetPosition () {

		transform.position = SunPointer.transform.position;

	}
		
	/** Metoda wyświetlająca słońce **/
	public void Renderer()
	{

		sprite = Resources.Load<Sprite> ("Animation/Sun/sun");
		rend.sprite = sprite;

	}

	/** Metoda poruszająca słońcem **/
	public void Move()
	{

		/** Jeśli pozycja słońca jest mniejsza od statycznej pozycji wtedy dochodzi do poruszenia **/
		if (transform.position.y <= POS.y) {
		
			Vector3 bufor;
			bufor = transform.position;
			bufor.y += 0.4f;
			transform.position = bufor;
		
		} else if (transform.position.y > POS.y && up == false) {
			
			transform.position = POS;
			up = true;

		} 

	}
		

	public void GameOverPause()
	{
		if (GLOBAL.gameover_pause == false) {
			
			if (transform.position.y + (SunSpawner.suns [0].rend.bounds.size.y / 2) > 28) {

				GLOBAL.gameover_pause = true;
				transform.position -= new Vector3 (0, 2f);

			}

		}

	}

}
