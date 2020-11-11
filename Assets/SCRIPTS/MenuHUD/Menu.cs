using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Button buttonPLAY;
    public Button buttonEXIT;
	public bool a;

    private Canvas menu;

    // Use this for initialization
    void Start () {
        menu = (Canvas)GetComponent<Canvas>();

        buttonPLAY = buttonPLAY.GetComponent<Button>();
        buttonEXIT = buttonEXIT.GetComponent<Button>();

		menu.enabled = false;
		a = false;
    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			menu.enabled = !menu.enabled;
			a = !a;
			if (a) 
				Time.timeScale = 0;
			else 
				Time.timeScale = 1;
        }
    }

    public void exit()
    {

        SceneManager.LoadScene("MainMenu");
    }

    public void play()
    {
        menu.enabled = false;
        Time.timeScale = 1;
    }
}
