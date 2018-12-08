using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * ((GameManager.Instance.Speed/Time.fixedDeltaTime)*GameManager.Instance.EndTime)+transform.position.y);
        
        Debug.Log(transform.localScale.y * ((GameManager.Instance.Speed / Time.fixedDeltaTime) * GameManager.Instance.EndTime));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    transform.position = new Vector2(transform.position.x, transform.position.y + GameManager.Instance.Speed);
    }
}
