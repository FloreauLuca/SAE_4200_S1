﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {
	    transform.position = new Vector2(transform.position.x, transform.position.y + GameManager.Instance.Speed);
        Debug.Log("debug");
    }
}
