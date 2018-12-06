using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    public GameObject Camera
    {
        get { return camera; }
        set { camera = value; }
    }

    [SerializeField] private float speed = 1;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }
	// Use this for initialization
	void Start ()
	{
	    instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
