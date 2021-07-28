using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualStats : MonoBehaviour {

	public Text dmg;
	public Text spd;
	public Text price;
	public Text lvl;

	int id;
	Canvas cn;
	Weapon bufor;

	void Start()
	{
		cn  = GetComponentInParent<Canvas> ();
		id = returnID (cn.name);

		dmg.font = Resources.Load<Font> ("pixel");
		spd.font = Resources.Load<Font> ("pixel");
		price.font = Resources.Load<Font> ("pixel");
		lvl.font = Resources.Load<Font> ("pixel");

	}

	// Update is called once per frame
	void Update () {

		Show ();

	}

	public void Show()
	{
		bufor = Weapon.weapons [id];
		if (bufor != null) {
			
			dmg.text = bufor.damage.ToString ();
			spd.text = bufor.shoot_time.ToString ();
			price.text = bufor.price.ToString ();
			lvl.text = bufor.lvl.ToString ();
		}

	}

	int returnID (string name)
	{

		switch (name) {

		case "text_sst":

			return 0;

			break;

		case "text_mst":

			return 1;

			break;

		case "text_rc":

			return 2;

			break;

		case "text_frc":

			return 3;

			break;

		case "text_laserbeam":

			return 4;

			break;

		case "text_lasergun":

			return 5;

			break;

		case "text_rlb":

			return 6;

			break;

		case "text_rlg":

			return 7;

			break;

		case "text_lg":

			return 8;

			break;

		case "text_slg":

			return 9;

			break;

		case "text_sg":

			return 10;

			break;

		case "text_missilehelper":

			return 11;

			break;

		case "text_rocketlauncher":

			return 12;

			break;

		case "text_atomiccannon":

			return 13;

			break;

		case "text_player":

			return 14;

			break;

		default:
			return -1;
			break;

		}
	}
}
