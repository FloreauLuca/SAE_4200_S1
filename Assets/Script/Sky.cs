using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{

	// Use this for initialization
	void Start () {
        Debug.Log(transform.localScale);
	    Debug.Log(GameManager.Instance);
        Debug.Log(GameManager.Instance.Speed);
	    Debug.Log(Time.fixedDeltaTime);
        Debug.Log(GameManager.Instance.EndTime);
        Debug.Log(transform.position.y);
	    transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * ((GameManager.Instance.Speed/Time.fixedDeltaTime)*GameManager.Instance.EndTime)+transform.position.y);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    transform.position = new Vector2(transform.position.x, transform.position.y + GameManager.Instance.Speed);
    }
}
