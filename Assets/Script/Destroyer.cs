using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    
	// Update is called once per frame
	void Update () {
		
	}

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
