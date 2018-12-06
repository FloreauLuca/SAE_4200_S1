using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    private GameObject newWall;
    private GameObject oldWall;

    // Use this for initialization
    void Start ()
    {
        newWall = Instantiate(wallPrefab, transform);
        oldWall = Instantiate(wallPrefab, new Vector2(transform.position.x, transform.position.y + newWall.GetComponent<BoxCollider2D>().size.y), Quaternion.identity, transform);
    }
	
	// Update is called once per frame
	void Update ()
    { 
        newWall.transform.position = new Vector2(newWall.transform.position.x, newWall.transform.position.y + GameManager.Instance.Speed);
        oldWall.transform.position = new Vector2(oldWall.transform.position.x, oldWall.transform.position.y + GameManager.Instance.Speed);
        if (newWall.transform.position.y >= newWall.GetComponent<BoxCollider2D>().size.y + transform.position.y)
        {
            Destroy(oldWall);
            oldWall = newWall.gameObject;
            newWall = Instantiate(wallPrefab, transform);
        }

    }
}
