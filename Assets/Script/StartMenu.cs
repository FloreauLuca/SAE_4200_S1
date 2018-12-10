using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    [SerializeField] private PlayableDirector timeline;
    [SerializeField] private GameObject panel;


	// Use this for initialization
	void Start ()
	{
	    GlobalGameManager.Instance.Win = false;

	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Start"))
	    {
            panel.SetActive(false);
            timeline.Play();
            Invoke("LoadScene", 1.6f);
	    }
	}

    void LoadScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
