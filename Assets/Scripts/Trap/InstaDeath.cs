﻿using UnityEngine;
using System.Collections;

public class InstaDeath : MonoBehaviour {
	private GameObject player;
	// Use this for initialization
	void Start () {
		//player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.collider.tag == "Player")
			HeroController.GameOver = true;
	}
}