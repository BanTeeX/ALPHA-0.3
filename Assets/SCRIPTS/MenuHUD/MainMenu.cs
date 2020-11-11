using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    
    public Text controls;

    private Canvas mainmenu;

    // Use this for initialization
    void Start () {
        mainmenu = (Canvas)GetComponent<Canvas>();
        controls.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
    }

    public void Tutorial()
    {
		//tip1.enabled = true;
		//mainmenu.enabled = false;
		Time.timeScale = 1;
		SceneManager.LoadScene("GRA_TEST");
    }

    public void Control()
    {
        if(controls.enabled)
        {
            controls.enabled = false;
        }
        else
        {
            controls.enabled = true;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

	public void Game()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("GRA_TEST_2");
	}

	public void Generator()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("RandomMap");
	}
}
