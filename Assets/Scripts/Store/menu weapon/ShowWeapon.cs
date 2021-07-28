using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWeapon : MonoBehaviour {

	Menu_weapon MW;

	// Use this for initialization
	void Awake () {

		MW = GameObject.Find("Weapon_menu").GetComponent<Menu_weapon> ();

	}
	
	// Update is called once per frame
	void Update () {

	//	if (MW.active == true)
			//Show ();


	}

	public void Show()
	{

		Weapon bufor = Weapon.weapons[Weapon.id];

		if (bufor != null) {
			
			bufor.rend.sortingOrder = 11;

			bufor.transform.position = transform.position;

		}
			

	}



}
