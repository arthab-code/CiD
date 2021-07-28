using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidthSize : MonoBehaviour {

	public Camera camera;
	public SpriteRenderer rend;

	// Use this for initialization
	void Start () {

		Vector3 screenSize = rend.size;

		float height = 2f * camera.orthographicSize;
		float width = height * camera.aspect;

		Sprite s = rend.sprite;

		float heightUnit = s.textureRect.height / s.pixelsPerUnit;
		float widthUnit = s.textureRect.width / s.pixelsPerUnit;

		screenSize.x = width / widthUnit;

		if (gameObject.name == "BACKGROUND") {
			
			screenSize.y = (height / heightUnit) * 5;

		} else {

			screenSize.y = (height / heightUnit) / 4;

		}


		rend.transform.localScale = screenSize;

	}
}
