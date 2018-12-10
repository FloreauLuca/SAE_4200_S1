using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winText;

    [SerializeField] private PlayableDirector timeLineLoose;
    [SerializeField] private PlayableDirector timeLineWin;

    // Use this for initialization
    void Start () {
	    if (GlobalGameManager.Instance.Win)
	    {
	        winText.text = "Win";
            timeLineWin.Play();
	    }
	    else
	    {
	        winText.text = "GameOver";
            timeLineLoose.Play();
        }

    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Start"))
	    {
	        SceneManager.LoadScene("MainScene");
	    }
    }
}
