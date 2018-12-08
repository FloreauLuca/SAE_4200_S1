using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    public GameObject Camera
    { get { return camera; } set { camera = value; } }

    [SerializeField] private float speed = 1;
    public float Speed
    { get { return speed; } set { speed = value; } }


    [SerializeField] private GameObject[] enemyPrefab;
    public GameObject[] EnemyPrefab
    { get { return enemyPrefab; } set { enemyPrefab = value; } }
    
    [SerializeField] private float enemyDelay;
    public float EnemyDelay
    { get { return enemyDelay; } set { enemyDelay = value; } }

    [SerializeField] private bool paused = false;
    public bool Paused
    { get { return paused; } set { paused = value; } }


    [SerializeField] private float endTime;
    public float EndTime
    { get { return endTime; } set { endTime = value; } }
    private float currentTime;

    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

	// Use this for initialization
	void Start ()
	{
	    instance = this;
	    GlobalGameManager.Instance.Win = false;

	}
	
	// Update is called once per frame
	void Update () {
	    if (currentTime >= endTime)
	    {
            GlobalGameManager.Instance.End();
	    }
	    else if (!paused)
	    {
	        currentTime += Time.deltaTime;
	    }

	    if (Input.GetButtonDown("Pause"))
	    {
	        if (paused)
	        {
	            Time.timeScale = 1;
	            paused = false;
	        }
	        else
	        {
	            Time.timeScale = 0;
	            paused = true;
	        }
        }
	}
}
