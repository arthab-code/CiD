using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextStats : MonoBehaviour {

	public Text dmg;
	public Text spd;
	public Text lvl;

	int id;



	void Awake()
	{
		Canvas cn = GetComponentInParent<Canvas> ();
		id = returnID (cn.name);

		dmg.font = Resources.Load<Font> ("pixel");
		spd.font = Resources.Load<Font> ("pixel");
		lvl.font = Resources.Load<Font> ("pixel");

	}

	// Update is called once per frame
	void Update () {

		Show ();

	}

	public void Show()
	{
		Weapon bufor = Weapon.weapons[id];

		if (bufor != null) {
			dmg.text = bufor.damage_next.ToString ();
			spd.text = bufor.shoot_time_next.ToString ();
			lvl.text = bufor.lvl_next.ToString ();
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

