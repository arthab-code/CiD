using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameManager : MonoBehaviour {

	public GameObject FileManager;
	FileManager FM_SCRIPT;

	float bufor_lvl;
	int wave = 5;

	bool save_ready = true;
	bool save_done = true;

	public GameObject GAME_SAVE;

	float time_show_save = 0;
	float goalTimeShow = 2f;

	bool show_save_game = false;

	// Use this for initialization
	void Start () {

		FM_SCRIPT = FileManager.GetComponent<FileManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		Save ();
		SaveReadyManager ();

		if (GLOBAL.WAVE >= PlayerPrefs.GetInt("WaveBufor")) {
		
			ShowSaveGame ();
		}
	}
		
	void Save()
	{

		if (save_done == true) {

			if (GLOBAL.WAVE == 1 && PlayerPrefs.HasKey("OneSaved") == false) {

				PlayerPrefs.SetInt ("WaveBufor", 0);
				PlayerPrefs.SetInt ("OneSaved", 1);
				save_ready = false;
				save_done = false;
				show_save_game = true;
				return;

			}
		}

		if (save_ready == true) {

			bufor_lvl = GLOBAL.WAVE;

			int bufor;

			bufor = GLOBAL.WAVE / wave;

			if (bufor > 0) {
				
				bufor *= wave;
				bufor_lvl /= bufor;

			} else {

				bufor = 1;

			}

			if (bufor_lvl == 1 && GLOBAL.WAVE > 0) {

				FM_SCRIPT.SaveAll ();
				save_ready = false;
				show_save_game = true;

			}

		}
	}

	void SaveReadyManager()
	{

		if (save_ready == false && GLOBAL.WAVE > 0) {

			bufor_lvl = GLOBAL.WAVE;

			/*while (bufor_lvl > 0) {

				bufor_lvl -= wave;

			}
            */

			int bufor;

			bufor = GLOBAL.WAVE / wave;

			if (bufor > 0) {

				bufor *= wave;
				bufor_lvl /= bufor;

			} else {

				bufor = 1;

			}

			if (bufor_lvl != 1) {

				save_ready = true;

			}

		}

	}

	void ShowSaveGame()
	{

		if (show_save_game == true) {

			if (GLOBAL.wave_pause == false) {
			
				time_show_save += Time.deltaTime;
			
			}

			GAME_SAVE.transform.position = new Vector2 (0f, 0f);

			if (time_show_save > goalTimeShow) {

				time_show_save = 0;
				show_save_game = false;

			}


		} else {

			GAME_SAVE.transform.position = new Vector2 (100f, -7f);

		}

	}
}
