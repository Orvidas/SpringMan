﻿using UnityEngine;
using System;
using System.Collections;

public class MoveProjectileScript : MonoBehaviour {

    float xSpeed;
    float ySpeed;
    float angle;
    private GameObject player;
    private GameObject parent;
    private int maxspeed;
    private float timeLeft;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        parent = transform.parent.gameObject;
        maxspeed = 30;
        CalculateVelocity();
		if(xSpeed!=Mathf.Infinity&&ySpeed!=Mathf.Infinity)
        	rigidbody2D.velocity = new Vector2(xSpeed, ySpeed);
        timeLeft = 2.5f;
    }

    void FixedUpdate () {
		Debug.Log ("xSpeed: " + rigidbody2D.velocity.x + " ySpeed: " + rigidbody2D.velocity.y);
        if (timeLeft <= 0) //Switch to time based.
            Destroy(this.gameObject);
        else
        {
            timeLeft -= Time.deltaTime;
        }
    }

    void CalculateVelocity()
    {
        angle = CalculateAngle();
		var absAngle = Mathf.Abs (angle);
        if (parent != null)
            maxspeed = 30 + Math.Abs((int) parent.rigidbody2D.velocity.x) + Math.Abs((int) parent.rigidbody2D.velocity.y);
        float div = 45 / (maxspeed / 2);
		xSpeed = maxspeed - (float) Math.Round(absAngle / div);
        ySpeed = maxspeed - xSpeed;
        if (player.transform.position.x < transform.position.x)
            xSpeed *= -1;
        if (player.transform.position.y < transform.position.y)
            ySpeed *= -1;
		if (ySpeed < -20)
						ySpeed -= 30;

    }

    float CalculateAngle()
    {
        float y = 0;
        float x = 0;
        y = player.transform.position.y - transform.position.y;
        x = player.transform.position.x - transform.position.x;
		if(y < 0)
			return Mathf.Atan (y / x) * Mathf.Rad2Deg * -1;
		else
			return Mathf.Atan (y / x) * Mathf.Rad2Deg;
    }

}
