using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSize : MonoBehaviour {

	public Camera camera;
	public SpriteRenderer rend;

	// Use this for initialization
	void Start () {

		Vector3 screenSize = rend.size;

		float height = 2f * camera.orthographicSize;
		float width = height / Screen.height * Screen.width; //height * camera.aspect;

		Sprite s = rend.sprite;

		float heightUnit = s.textureRect.height / s.pixelsPerUnit;
		float widthUnit = s.textureRect.width / s.pixelsPerUnit;

		screenSize.x = width / widthUnit;
		screenSize.y = height / heightUnit;

		rend.transform.localScale = screenSize;

	}

}
