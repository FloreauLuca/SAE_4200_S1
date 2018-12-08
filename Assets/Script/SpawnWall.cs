using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWall : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    private GameObject currentWall;
    private GameObject nextWall;

    [SerializeField] private float startDelay;
    public float StartDelay
    { get { return startDelay; } set { startDelay = value; } }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnDelay());

        nextWall = wallPrefab;
        currentWall = Instantiate(nextWall, transform);

    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if (currentWall.transform.position.y >= nextWall.GetComponent<BoxCollider2D>().size.y/2+currentWall.GetComponent<BoxCollider2D>().size.y/2 + transform.position.y)
        {
            currentWall = Instantiate(nextWall, new Vector2(currentWall.transform.position.x, currentWall.transform.position.y + GameManager.Instance.Speed - (nextWall.GetComponent<BoxCollider2D>().size.y / 2 + currentWall.GetComponent<BoxCollider2D>().size.y /2)), Quaternion.identity, transform);
            nextWall = wallPrefab;
        }

    }
    IEnumerator SpawnDelay()
    {
        yield return new WaitForSecondsRealtime(startDelay);
        while (true)
        {
            yield return new WaitForSecondsRealtime(GameManager.Instance.EnemyDelay);
            nextWall = GameManager.Instance.EnemyPrefab[Random.Range(0, GameManager.Instance.EnemyPrefab.Length)];
        }

    }
}
