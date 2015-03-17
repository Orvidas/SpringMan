﻿using UnityEngine;
using System.Collections;

public class CannonBossLifeNode : MonoBehaviour 
{
	public int nodeLife;
	public Sprite damagedNode;

	private bool nodeAlive;

	// Use this for initialization
	void Start () 
	{
		nodeAlive = true;
//		scriptConnector = GameObject.FindGameObjectWithTag("Boss").GetComponent<CannonBossLife>();
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			nodeLife--;
			other.gameObject.rigidbody2D.velocity = new Vector2(other.gameObject.rigidbody2D.velocity.x, (-other.gameObject.rigidbody2D.velocity.y<25f)?18f:22f);
		}

	}

	void FixedUpdate()
	{	
		if(nodeLife == 0 && nodeAlive)
		{
			GetComponent<SpriteRenderer>().sprite = damagedNode;
			GameObject.FindGameObjectWithTag("Boss").GetComponent<CannonBossLife>().bossLifeNodes--;
			nodeAlive = false;
		}
	}
}
