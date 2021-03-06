﻿using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {
	public float savedtime = 0;
    public float CountDown = 30f;
	public float speed = 0.5f;

	private Vector2 offset = Vector2.zero;
	private Material mat;
	
	void Start () {
		mat = GetComponent<Renderer> ().material;
		offset = mat.GetTextureOffset ("_MainTex");
	}

	void Update () {
		if(((Time.time) - (savedtime)) > CountDown ) { 
            savedtime = Time.time; //reset the saved time
			speed += (0.010f);
			offset.x += speed * Time.deltaTime;
		}
		else{
			offset.x += speed * Time.deltaTime;
			mat.SetTextureOffset ("_MainTex", offset);
		}
	}
}
