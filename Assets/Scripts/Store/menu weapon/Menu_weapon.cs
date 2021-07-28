using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_weapon : MonoBehaviour {

	public bool                   active = false;
	public bool                   activeMenu = false;

	public SpriteRenderer         rend;

	// Use this for initialization
	void Awake () {

		rend = GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {

	//	if (active == true)
			
    	//	Show ();
		
		
	}

	public void Show()
	{
		Vector2 bufor;

		bufor.x = 0f;
		bufor.y = 0f;

		rend.transform.position = bufor;
		transform.position = bufor;

	}


	public void Hide()
	{
		Vector2 bufor;

		bufor.x = 130f;
		bufor.y = 0f;

		transform.position = bufor;
		rend.transform.position = bufor;

	}
		

}
