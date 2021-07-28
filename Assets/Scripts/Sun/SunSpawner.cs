using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : MonoBehaviour {

	public GameObject    sun;               /** Referencja do prefabrykatu Sun**/
	public static Sun[] suns;               /** Utworzenie tablicy ktora odnosi sie do 1 elementu Sun **/

	// Use this for initialization
	void Awake () {
		
		//suns = new Sun[1];                  /** Utworzenie tablicy 1 elementowej **/
    	//GameObject go = Instantiate (sun);  /** Utworzenie instancji obiektu Sun **/
		//Sun s = go.GetComponent<Sun> ();    /** Zebranie skryptu Sun z instancji obiektu Sun **/
		//suns [0] = s;                       /** Przypisanie skryptu do tablicy **/

		
	}
	

}
