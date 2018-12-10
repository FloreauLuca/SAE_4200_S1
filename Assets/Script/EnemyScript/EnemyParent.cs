using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    [SerializeField] protected int damage;

    [SerializeField] protected AudioClip hitSound;

	// Use this for initialization
	protected void Start ()
	{

	}
	
	// Update is called once per frame
	protected void Update () {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().Hit(damage, hitSound);
        }
    }
}
