using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusShip : MonoBehaviour {

	public float hp;
	public float speed;

	public GameObject SUN;

	Sprite spr;
	SpriteRenderer rend;

	float posXspr;
	float posYspr;
	float width;
	float height;

	// Use this for initialization
	void Awake () {

		SetStats ();

	}
	
	// Update is called once per frame
	void Update () {

		if (BonusManager.bs.Count > 0) {
			AreaClick ();

			if (GLOBAL.shop_pause == false && GLOBAL.pause == false && GLOBAL.wave_pause == false && GLOBAL.exit_pause == false
			    && GLOBAL.gameover_pause == false && GLOBAL.bonus_pause == false || GLOBAL.tutorial_pause == true) {
			
				Move ();
			
			}
		}
	}

	void SetStats()
	{

		hp = 1f;
		speed = 0.3f;

	}

	void Move()
	{

		transform.position -= new Vector3 (0f, speed);

	}

	void DestroyWin()
	{
		if (BonusManager.bs.Count > 0) {
			
			GLOBAL.bonus_pause = true;
			Destroy (BonusManager.bs[0].gameObject);
			BonusManager.bs.Remove (BonusManager.bs [0]);

		}
		
	}

	void DestroyNoWin()
	{

		if (transform.position.y <= SunSpawner.suns[0].transform.position.y) {

			Destroy (gameObject);
			Destroy (this);

		}

	}

	public void AreaClick()
	{

		Vector2 tpos;                                                        /** Zmienna pomocnicza przechowująca wspłrzędne dotkniętego punktu na ekranie **/
		posXspr = BonusManager.bs[0].transform.position.x;    
		posYspr = BonusManager.bs[0].transform.position.y;   

		width = BonusManager.bs[0].gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2;
		height = BonusManager.bs[0].gameObject.GetComponent<SpriteRenderer>().bounds.size.y / 2;

		/** Warunek sprawdzający, czy został dotknięty ekran **/
		if (Input.touchCount > 0) {

			Touch touch = Input.GetTouch (0);                                /** Zmienna przechwycająca dotknięcie ekranu **/

			/** Warunek sprawdzający czy faza dotknięcia jest fazą początkową (dotknięcie ekranu) **/

			if (Input.GetTouch (0).phase == TouchPhase.Began) {

				tpos = Camera.main.ScreenToWorldPoint (touch.position);      /** Zmienna pomocnicza przechwytująca pozycję dotknięcia skonwertowaną do odpowiednich koordynatów kamery **/

				/** Warunek sprawdzający czy dotknięcie ekranu mieści się w prawidłowym zakresie **/
				if (tpos.x > posXspr - width && tpos.x < posXspr + width
					&& tpos.y > posYspr - height && tpos.y < posYspr + height && GLOBAL.tutorial_pause == false) {

					DestroyWin ();


				}

			}

		}

	}
}
