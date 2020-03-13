using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
	public float scrollx = 0.5f;
	public float scrolly = 0.5f;
	private float timer;
	void Start()
	{
		timer=0;
	}
	void Update ()
    {
		timer+=Time.deltaTime;
		/*
		float offsetX = Time.time * scrollx;
		float offsetY = Time.time * scrolly;
		 */
		float offsetX = timer * scrollx;
		float offsetY = timer * scrolly;
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (offsetX,offsetY);
	}
}
