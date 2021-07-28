using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public SpriteRenderer                 rend;
	public Sprite                         spr;

	public GameObject                     ship;
	public Ship                           shipScript;
	 

	public static Weapon[]                weapons;
	public static int                     id = -1;

	public int                            lvl = 0;
	public int                            price;
	public float                          ammo;
	public float                          max_ammo;

	public float                          reload_time;
	public float                          shoot_time;
	public float                          ray_shoot;
	public float                          damage;

	public float                          damage_next;
	public float                          lvl_next;
	public float                          shoot_time_next;

	public bool                           active = false;   /** true = active, false = deactive **/
	public bool                           onArea = false;   /** czy broń znajduje się na planszy do gry - true albo false **/
	public bool                           side   = false;  /** false = right side, true = left side **/
	public bool                           shoot  = false;

	public int                            slot_id = 0; 

	public bool                           aim = false;

	public bool                           added = true;


	// Use this for initialization
	void Start () {

		rend = GetComponent<SpriteRenderer> ();
		weapons = new Weapon[15];
		added = true;
		SetStats ();
		
	}
	
	// Update is called once per frame
	void Update () {

		Render ();

	}

	/** Metoda renderująca broń **/
	void Render()
	{
		Weapon bufor = GetComponent<Weapon>();

		switch (this.name) {

		case "PLAYER":

			spr = Resources.Load<Sprite>("Animation/Weapons/Player/str");

			rend.sprite = spr;

			bufor.rend.sprite = spr;
			weapons [14] = bufor;

			break;

		case "SST":

			if (lvl == 0)
				spr = Resources.Load<Sprite> ("Animation/Weapons/Turret/SST/SST_d");
			else
				spr = Resources.Load<Sprite> ("Animation/Weapons/Turret/SST/SST_a");

			rend.sprite = spr;
			bufor.rend.sprite = spr;

			weapons [0] = bufor;
			ammo_strip ammo = GameObject.Find ("SST").GetComponentInChildren<ammo_strip>();
			if (GLOBAL.shop_pause == true) 
				weapons [0].rend.flipX = false;


			if (weapons [0].side == true && weapons [0].onArea == true && GLOBAL.shop_pause == false) 
				weapons [0].rend.flipX = true;


			break;


		case "MST":

			if (lvl == 0)
				spr = Resources.Load<Sprite>("Animation/Weapons/Turret/MST/MST_d");
			else
				spr = Resources.Load<Sprite>("Animation/Weapons/Turret/MST/MST_a");
			
			rend.sprite = spr;
			bufor.rend.sprite = spr;
			weapons [1] = bufor;

			if (GLOBAL.shop_pause == true)
				weapons [1].rend.flipX = false;

			if (weapons [1].side == true && weapons [1].onArea == true && GLOBAL.shop_pause == false)
				weapons [1].rend.flipX = true;

			break;

		case "RC":

			if (lvl == 0)
				spr = Resources.Load<Sprite>("Animation/Weapons/Turret/RotaryCannon/RotaryCannon_d");
			else
				spr = Resources.Load<Sprite>("Animation/Weapons/Turret/RotaryCannon/RotaryCannon_a");
			
			rend.sprite = spr;
			bufor.rend.sprite = spr;
			weapons [2] = bufor;

			if (GLOBAL.shop_pause == true)
				weapons [2].rend.flipX = false;

			if (weapons [2].side == true && weapons [2].onArea == true && GLOBAL.shop_pause == false)
				weapons [2].rend.flipX = true;

			break;

		case "FRC":

			if (lvl == 0)
				spr = Resources.Load<Sprite>("Animation/Weapons/Turret/FRC/FRC_d");
			else
				spr = Resources.Load<Sprite>("Animation/Weapons/Turret/FRC/FRC_a");
			
			rend.sprite = spr;
			bufor.rend.sprite = spr;
			weapons [3] = bufor;

			if (GLOBAL.shop_pause == true)
				weapons [3].rend.flipX = false;

			if (weapons [3].side == true && weapons [3].onArea == true && GLOBAL.shop_pause == false)
				weapons [3].rend.flipX = true;

			break;

		case "LaserBeam":

			if (lvl == 0)
				spr = Resources.Load<Sprite>("Animation/Weapons/Laser/LaserBeam/LaserBeam_d");
			else
				spr = Resources.Load<Sprite>("Animation/Weapons/Laser/LaserBeam/LaserBeam_a");
			
			rend.sprite = spr;
			bufor.rend.sprite = spr;
			weapons [4] = bufor;

			if (GLOBAL.shop_pause == true)
				weapons [4].rend.flipX = false;

			if (weapons [4].side == true && weapons [4].onArea == true && GLOBAL.shop_pause == false)
				weapons [4].rend.flipX = true;

			break;

		case "LaserGun":

			if (lvl == 0)
				spr = Resources.Load<Sprite>("Animation/Weapons/Laser/LaserGun/LaserGun_d");
			else
				spr = Resources.Load<Sprite>("Animation/Weapons/Laser/LaserGun/LaserGun_a");
			
			rend.sprite = spr;
			bufor.rend.sprite = spr;
			weapons [5] = bufor;

			if (GLOBAL.shop_pause == true)
				weapons [5].rend.flipX = false;

			if (weapons [5].side == true && weapons [5].onArea == true && GLOBAL.shop_pause == false)
				weapons [5].rend.flipX = true;

			break;

		case "RLB":

			if (lvl == 0)
				spr = Resources.Load<Sprite>("Animation/Weapons/Laser/RLB/RLB_d");
			else
				spr = Resources.Load<Sprite>("Animation/Weapons/Laser/RLB/RLB_a");
			
			rend.sprite = spr;
			bufor.rend.sprite = spr;
			weapons [6] = bufor;

			if (GLOBAL.shop_pause == true)
				weapons [6].rend.flipX = false;

			if (weapons [6].side == true && weapons [6].onArea == true && GLOBAL.shop_pause == false)
				weapons [6].rend.flipX = true;

			break;

		case "RLG":

			if (lvl == 0)
				spr = Resources.Load<Sprite>("Animation/Weapons/Laser/RLG/RLG_d");
			else
				spr = Resources.Load<Sprite>("Animation/Weapons/Laser/RLG/RLG_a");
			
			rend.sprite = spr;
			bufor.rend.sprite = spr;
			weapons [7] = bufor;

			if (GLOBAL.shop_pause == true)
				weapons [7].rend.flipX = false;

			if (weapons [7].side == true && weapons [7].onArea == true && GLOBAL.shop_pause == false)
				weapons [7].rend.flipX = true;

			break;

		case "LaserGate":

			if (lvl == 0)
				spr = Resources.Load<Sprite>("Animation/Weapons/Gates/LaserGate/LaserGate_d");
			else
				spr = Resources.Load<Sprite>("Animation/Weapons/Gates/LaserGate/LaserGate_a");
			
			rend.sprite = spr;
			bufor.rend.sprite = spr;
			weapons [8] = bufor;

			if (GLOBAL.shop_pause == true)
				weapons [8].rend.flipX = false;

			if (weapons [8].side == true && weapons [8].onArea == true && GLOBAL.shop_pause == false)
				weapons [8].rend.flipX = true;

			break;

		case "SLG":

			if (lvl == 0)
				spr = Resources.Load<Sprite>("Animation/Weapons/Gates/SLG/SLG_d");
			else
				spr = Resources.Load<Sprite>("Animation/Weapons/Gates/SLG/SLG_a");
			
			rend.sprite = spr;
			bufor.rend.sprite = spr;
			weapons [9] = bufor;

			if (GLOBAL.shop_pause == true)
				weapons [9].rend.flipX = false;

			if (weapons [9].side == true && weapons [9].onArea == true && GLOBAL.shop_pause == false)
				weapons [9].rend.flipX = true;

			break;

		case "SlowingGate":

			if (lvl == 0)
				spr = Resources.Load<Sprite>("Animation/Weapons/Gates/SlowingGate/SlowingGate_d");
			else
				spr = Resources.Load<Sprite>("Animation/Weapons/Gates/SlowingGate/SlowingGate_a");
			
			rend.sprite = spr;
			bufor.rend.sprite = spr;
			weapons [10] = bufor;

			if (GLOBAL.shop_pause == true)
				weapons [10].rend.flipX = false;

			if (weapons [10].side == true && weapons [10].onArea == true && GLOBAL.shop_pause == false)
				weapons [10].rend.flipX = true;

			break;

		case "MissileHelper":

			if (lvl == 0)
				spr = Resources.Load<Sprite>("Animation/Weapons/Rocket/MissileHelper/MissileHelper_d");
			else
				spr = Resources.Load<Sprite>("Animation/Weapons/Rocket/MissileHelper/MissileHelper_a");
			
			rend.sprite = spr;
			bufor.rend.sprite = spr;
			weapons [11] = bufor;

			if (GLOBAL.shop_pause == true)
				weapons [11].rend.flipX = false;

			if (weapons [11].side == true && weapons [11].onArea == true && GLOBAL.shop_pause == false)
				weapons [11].rend.flipX = true;

			break;

		case "RocketLauncher":

			if (lvl == 0)
				spr = Resources.Load<Sprite>("Animation/Weapons/Rocket/RocketLauncher/RocketLauncher_d");
			else
				spr = Resources.Load<Sprite>("Animation/Weapons/Rocket/RocketLauncher/RocketLauncher_a");
			
			rend.sprite = spr;
			bufor.rend.sprite = spr;
			weapons [12] = bufor;

			if (GLOBAL.shop_pause == true)
				weapons [12].rend.flipX = false;

			if (weapons [12].side == true && weapons [12].onArea == true && GLOBAL.shop_pause == false)
				weapons [12].rend.flipX = true;

			break;

		case "AtomicCannon":

			if (lvl == 0)
				spr = Resources.Load<Sprite>("Animation/Weapons/Rocket/AtomicCannon/AtomicCannon_d");
			else
				spr = Resources.Load<Sprite>("Animation/Weapons/Rocket/AtomicCannon/AtomicCannon_a");
			
		    rend.sprite = spr;
			bufor.rend.sprite = spr;
			weapons [13] = bufor;

			if (GLOBAL.shop_pause == true)
				weapons [13].rend.flipX = false;

			if (weapons [13].side == true && weapons [13].onArea == true && GLOBAL.shop_pause == false)
				weapons [13].rend.flipX = true;

			break;

		}

	}

	/** Metoda ustawiająca statystyki broni **/
	public void SetStats()
	{
		Weapon bufor = GetComponent<Weapon>();

		switch (this.name) {

		case "SST":

			bufor.transform.parent = GameObject.Find ("SST_SLOT_M").transform;
			bufor.transform.position = GameObject.Find ("SST_SLOT_M").transform.position;

			bufor.lvl = 0;
			bufor.damage = 0;
			bufor.price = 50;
			bufor.max_ammo = 0;
			bufor.ammo = max_ammo;
			bufor.reload_time = 0; 
			bufor.shoot_time = 0;

			bufor.damage_next = (bufor.lvl + 1) * 10f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 0.7f - ((bufor.lvl+1) / 100);

			if (weapons [0] == null)
				weapons [0] = bufor;

			break;

		case "MST":

			bufor.transform.parent = GameObject.Find ("MST_SLOT_M").transform;
			bufor.transform.position = GameObject.Find ("MST_SLOT_M").transform.position;

			bufor.lvl = 0;
			bufor.damage = 0;
			bufor.price = 300;
			bufor.max_ammo = 0;
			bufor.ammo = max_ammo;
			bufor.reload_time = 0; 
			bufor.shoot_time = 0;

			bufor.damage_next = (bufor.lvl + 1) * 15f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 0.5f - ((bufor.lvl+1) / 100);

			if (weapons [1] == null)
				weapons [1] = bufor;

			break;

		case "RC":

			bufor.transform.parent = GameObject.Find ("RC_SLOT_M").transform;
			bufor.transform.position = GameObject.Find ("RC_SLOT_M").transform.position;

			bufor.lvl = 0;
			bufor.damage = 0;
			bufor.price = 400;
			bufor.max_ammo = 0;
			bufor.ammo = max_ammo;
			bufor.reload_time = 0; 
			bufor.shoot_time = 0;

			bufor.damage_next = (bufor.lvl + 1) * 10f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 0.7f - ((bufor.lvl+1) / 100);

			if (weapons [2] == null)
				weapons [2] = bufor;

			break;

		case "FRC":

			bufor.transform.parent = GameObject.Find ("FRC_SLOT_M").transform;
			bufor.transform.position = GameObject.Find ("FRC_SLOT_M").transform.position;

			bufor.lvl = 0;
			bufor.damage = 0;
			bufor.price = 500;
			bufor.max_ammo = 0;
			bufor.ammo = max_ammo;
			bufor.reload_time = 0; 
			bufor.shoot_time = 0;

			bufor.damage_next = (bufor.lvl + 1) * 15f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 0.5f - ((bufor.lvl+1) / 100);

			if (weapons [3] == null)
				weapons [3] = bufor;

			break;

		case "LaserBeam":

			bufor.transform.parent = GameObject.Find ("LASERBEAM_SLOT_M").transform;
			bufor.transform.position = GameObject.Find ("LASERBEAM_SLOT_M").transform.position;

			bufor.lvl = 0;
			bufor.damage = 0;
			bufor.price = 600;
			bufor.max_ammo = 0;
			bufor.ammo = max_ammo;
			bufor.reload_time = 0; 
			bufor.shoot_time = 0;

			bufor.damage_next = (bufor.lvl + 1) * 0.6f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 0.4f - ((bufor.lvl+1) / 100);

			if (weapons [4] == null)
				weapons [4] = bufor;

			break;

		case "LaserGun":

			bufor.transform.parent = GameObject.Find ("LASERGUN_SLOT_M").transform;
			bufor.transform.position = GameObject.Find ("LASERGUN_SLOT_M").transform.position;

			bufor.lvl = 0;
			bufor.damage = 0;
			bufor.price = 400;
			bufor.max_ammo = 0;
			bufor.ammo = max_ammo;
			bufor.reload_time = 0; 
			bufor.shoot_time = 0;

			bufor.damage_next = (bufor.lvl + 1) * 0.5f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 0.5f - ((bufor.lvl+1) / 100);

			if (weapons [5] == null)
				weapons [5] = bufor;

			break;

		case "RLB":

			bufor.transform.parent = GameObject.Find ("RLB_SLOT_M").transform;
			bufor.transform.position = GameObject.Find ("RLB_SLOT_M").transform.position;

			bufor.lvl = 0;
			bufor.damage = 0;
			bufor.price = 800;
			bufor.max_ammo = 0;
			bufor.ammo = max_ammo;
			bufor.reload_time = 0; 
			bufor.shoot_time = 0;

			bufor.damage_next = (bufor.lvl + 1) * 0.8f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 0.4f - ((bufor.lvl+1) / 100);

			if (weapons [6] == null)
				weapons [6] = bufor;

			break;

		case "RLG":

			bufor.transform.parent = GameObject.Find ("RLG_SLOT_M").transform;
			bufor.transform.position = GameObject.Find ("RLG_SLOT_M").transform.position;

			bufor.lvl = 0;
			bufor.damage = 0;
			bufor.price = 1300;
			bufor.max_ammo = 0;
			bufor.ammo = max_ammo;
			bufor.reload_time = 0; 
			bufor.shoot_time = 0;

			bufor.damage_next = (bufor.lvl + 1) * 0.5f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 0.4f - ((bufor.lvl+1) / 100);

			if (weapons [7] == null)
				weapons [7] = bufor;

			break;

		case "LaserGate":

			bufor.transform.parent = GameObject.Find ("LG_SLOT_M").transform;
			bufor.transform.position = GameObject.Find ("LG_SLOT_M").transform.position;

			bufor.lvl = 0;
			bufor.damage = 0;
			bufor.price = 700;
			bufor.max_ammo = 0;
			bufor.ammo = max_ammo;
			bufor.reload_time = 0; 
			bufor.shoot_time = 0;

			bufor.damage_next = (bufor.lvl + 1) * 0.5f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 2f + ((bufor.lvl+1) / 100);

			if (weapons [8] == null)
				weapons [8] = bufor;

			break;

		case "SLG":

			bufor.transform.parent = GameObject.Find ("SLG_SLOT_M").transform;
			bufor.transform.position = GameObject.Find ("SLG_SLOT_M").transform.position;

			bufor.lvl = 0;
			bufor.damage = 0;
			bufor.price = 1300;
			bufor.max_ammo = 0;
			bufor.ammo = max_ammo;
			bufor.reload_time = 0; 
			bufor.shoot_time = 0;

			bufor.damage_next = (bufor.lvl + 1) * 0.8f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 3f + ((bufor.lvl+1) / 100);

			if (weapons [9] == null)
				weapons [9] = bufor;

			break;

		case "SlowingGate":

			bufor.transform.parent = GameObject.Find ("SG_SLOT_M").transform;
			bufor.transform.position = GameObject.Find ("SG_SLOT_M").transform.position;

			bufor.lvl = 0;
			bufor.damage = 0;
			bufor.price = 2000;
			bufor.max_ammo = 0;
			bufor.ammo = max_ammo;
			bufor.reload_time = 0; 
			bufor.shoot_time = 0;

			bufor.damage_next = (bufor.lvl + 1) * 0;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 2f + ((bufor.lvl+1) / 100);

			if (weapons [10] == null)
				weapons [10] = bufor;

			break;

		case "MissileHelper":

			bufor.transform.parent = GameObject.Find ("MISSILEHELPER_SLOT_M").transform;
			bufor.transform.position = GameObject.Find ("MISSILEHELPER_SLOT_M").transform.position;

			bufor.lvl = 0;
			bufor.damage = 0;
			bufor.price = 2000;
			bufor.max_ammo = 0;
			bufor.ammo = max_ammo;
			bufor.reload_time = 0; 
			bufor.shoot_time = 0;

			bufor.damage_next = (bufor.lvl + 1) * 5f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 1f - ((bufor.lvl+1) / 100);


			if (weapons [11] == null)
				weapons [11] = bufor;

			break;

		case "RocketLauncher":

			bufor.transform.parent = GameObject.Find ("ROCKETLAUNCHER_SLOT_M").transform;
			bufor.transform.position = GameObject.Find ("ROCKETLAUNCHER_SLOT_M").transform.position;

			bufor.lvl = 0;
			bufor.damage = 0;
			bufor.price = 3000;
			bufor.max_ammo = 0;
			bufor.ammo = max_ammo;
			bufor.reload_time = 0; 
			bufor.shoot_time = 0;

			bufor.damage_next = (bufor.lvl + 1) * 8f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 3f - ((bufor.lvl+1) / 100);

			if (weapons [12] == null)
				weapons [12] = bufor;

			break;

		case "AtomicCannon":

			bufor.transform.parent = GameObject.Find ("ATOMICCANNON_SLOT_M").transform;
			bufor.transform.position = GameObject.Find ("ATOMICCANNON_SLOT_M").transform.position;

			bufor.lvl = 0;
			bufor.damage = 0;
			bufor.price = 5000;
			bufor.max_ammo = 0;
			bufor.ammo = max_ammo;
			bufor.reload_time = 0; 
			bufor.shoot_time = 0;

			bufor.damage_next = (bufor.lvl + 1) * 10f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 3f - ((bufor.lvl+1) / 100);

			if (weapons [13] == null)
				weapons [13] = bufor;

			break;

		case "PLAYER":

			bufor.transform.parent = GameObject.Find ("PLAYER_SLOT_M").transform;
			bufor.transform.position = GameObject.Find ("PLAYER_SLOT_M").transform.position;

			bufor.lvl += 1;
			bufor.damage = 3f;
			bufor.price = 100;
			bufor.max_ammo = 10;
			bufor.ammo = max_ammo;
			bufor.reload_time = 1.5f; 

			bufor.damage_next = (bufor.lvl + 1) * 3f;
			bufor.lvl_next = (bufor.lvl + 1);
			bufor.shoot_time_next = 0f;

			if (weapons [14] == null)
				weapons [14] = bufor;

			break;

		}
	}


}
