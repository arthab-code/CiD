using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_store : MonoBehaviour {

   SpriteRenderer rend; 
   Sprite sprite;

	// Update is called once per frame
	void Update () {
	
		Render ();

	}

	public void Render()
	{

		rend = GetComponent<SpriteRenderer> ();

		switch (Store.type) {

		case Store.Type_menu.tap:

			sprite = Resources.Load<Sprite> ("Animation/Store/tap");

			rend.sprite = sprite;

			break;

		case Store.Type_menu.machine:

			sprite = Resources.Load<Sprite> ("Animation/Store/machine");

			rend.sprite = sprite;

			break;

		case Store.Type_menu.laser:

			sprite = Resources.Load<Sprite> ("Animation/Store/laser");

			rend.sprite = sprite;

			break;

		case Store.Type_menu.rocket:

			sprite = Resources.Load<Sprite> ("Animation/Store/rocket");

			rend.sprite = sprite;

			break;

		case Store.Type_menu.gate:

			sprite = Resources.Load<Sprite> ("Animation/Store/gates");

			rend.sprite = sprite;

			break;

		}


	}
}
