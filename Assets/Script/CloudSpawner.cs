using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    [SerializeField] private GameObject cloudPrefab;

    [SerializeField] private float cloudDelay;
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
        while (true)
        {
            yield return new WaitForSecondsRealtime(cloudDelay);
            Instantiate(cloudPrefab, new Vector3(Random.Range(-5, 5), transform.position.y), Quaternion.identity, transform);
        }

    }
}
