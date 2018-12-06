using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    [SerializeField] protected int damage;

	// Use this for initialization
	protected void Start ()
	{

	}
	
	// Update is called once per frame
	protected void Update () {
	    GetComponent<Transform>().position = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y + GameManager.Instance.Speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().Hit(damage);
        }

        if (other.tag == "SpawnEnemy")
        {
            Debug.Log(true);

            Destroy(gameObject);
        }
    }
}
