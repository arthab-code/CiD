using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour {

	public Text tutorial;

	
	// Update is called once per frame
	void Update () {

		Show ();
	}

	void Show()
	{

		switch (GLOBAL.tutorial_count) {

		case 0:

			tutorial.text = "Welcome to Click & Defend tutorial!";

			break;

		case 1:

			tutorial.text = "The goal of the game is to score as many points as possible by destroying the falling elements";

			break;

		case 2:

			tutorial.text = "You destroy enemies by clicking on them";

			break;

		case 3:

			tutorial.text = "If the elements fall into the fire, its level rises, when it lines up with the green line - the game ends";

			break;

		case 4:

			tutorial.text = "In the next stage the first enemy will appear - destroy him ! ";

			break;

		case 5:

			tutorial.text = "DESTROY BY CLICKING ON THEM ";

			break;

		case 6:

			tutorial.text = "In the armory you can buy a weapon that mentions you in battle";

			break;

		case 7:

			tutorial.text = "Go to the weaponary ";

			break;

		case 8:

			tutorial.text = "Go to the machine tab ";

			break;

		case 9:

			tutorial.text = "Buy a mechanical cannon ";

			break;

		case 10:

			tutorial.text = "The set button allows you to set the weapon on the game board ";

			break;

		case 11:

			tutorial.text = "After setting the cannon, another opponent will appear. Destroy him! ";

			break;

		case 12:

			tutorial.text = "When the enemy appears in the field of view, the cannon starts to shoot at him ";

			break;

		case 13:

			tutorial.text = "You have completed the guide. You are ready to destroy opponents ! ";

			break;


		}

	}
}
