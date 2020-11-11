using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTip : MonoBehaviour
{

    public Button next;

    private Canvas tip;

    // Use this for initialization
    void Start()
    {
        tip = (Canvas)GetComponent<Canvas>();

        next = next.GetComponent<Button>();

        tip.enabled = false;

		if (gameObject.name == "Tip1")
			tip.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (tip.enabled)
        {
            Time.timeScale = 0;
        }
    }

    public void nextClick()
    {
        tip.enabled = false;
        Time.timeScale = 1;
    }
}
