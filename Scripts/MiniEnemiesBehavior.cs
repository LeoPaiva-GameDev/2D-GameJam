﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniEnemiesBehavior : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x < -80.5)
        {
            Destroy(this.gameObject);
        }
	}
}
