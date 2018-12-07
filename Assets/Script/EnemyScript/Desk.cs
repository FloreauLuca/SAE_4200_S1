using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : EnemyParent
{
    [SerializeField] private float launchingSpeed;

    private float timeSinceSpawn;
    // Use this for initialization
    protected void Start()
    {
        base.Start();
        timeSinceSpawn = 0;
    }

    // Update is called once per frame
    protected void Update()
    {
        base.Update();
        GetComponent<Transform>().position = new Vector2(GetComponent<Transform>().position.x+(launchingSpeed* GetComponent<Transform>().lossyScale.x), GetComponent<Transform>().position.y);
        GetComponent<Transform>().position = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y - timeSinceSpawn);
        timeSinceSpawn += Time.deltaTime;

    }
}
