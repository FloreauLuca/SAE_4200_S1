using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    private float parallaxSpeed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    transform.position = new Vector2(transform.position.x, transform.position.y + GameManager.Instance.Speed*parallaxSpeed);
    }

    public void SetParallaxSpeed (float size)
    {
        parallaxSpeed /= size;
        GetComponentInChildren<SpriteRenderer>().sortingOrder = 10- (int)size;
    }

}
