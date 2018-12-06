using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float startDelay;
    // Use this for initialization
    void Start ()
    {
        StartCoroutine(SpawnDelay());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSecondsRealtime(startDelay);
        while (true)
        {
            yield return new WaitForSecondsRealtime(spawnDelay);
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length-1)], transform);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other);
        }
    }
}
