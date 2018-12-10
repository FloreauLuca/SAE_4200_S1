using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GlobalGameManager : MonoBehaviour {

    private bool win = false;
    public bool Win
    { get { return win; } set { win = value; } }

    private AudioMixer audiomixer;

    private static GlobalGameManager instance;
    public static GlobalGameManager Instance
    {
        get { return instance; }
    }
    // Use this for initialization
    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        win = false;


    }

    // Update is called once per frame
    void Update () {
		
	}



    public void Death()
    {
        win = false;
        SceneManager.LoadScene("MenuEnd");
    }
    public void End()
    {
        win = true;
        SceneManager.LoadScene("MenuEnd");
    }
}
