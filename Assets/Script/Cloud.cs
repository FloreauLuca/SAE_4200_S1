using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    transform.position = new Vector2(transform.position.x, transform.position.y + GameManager.Instance.Speed);
    }
}
