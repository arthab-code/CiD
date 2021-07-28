using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_anim_laser : MonoBehaviour {

	public float speed;
	public Vector3 pos;
	public SpriteRenderer rend;

	// Use this for initialization
	void Awake () {
		rend = GetComponent <SpriteRenderer> ();
		rend.enabled = false;

		
	}



}
