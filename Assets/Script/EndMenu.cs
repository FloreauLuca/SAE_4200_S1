using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winText;
	// Use this for initialization
	void Start () {
	    if (GlobalGameManager.Instance.Win)
	    {
	        winText.text = "Win";
	    }
	    else
	    {
	        winText.text = "GameOver";
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
