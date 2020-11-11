using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextTip : MonoBehaviour
{

    public Button next;
    public Button nextPrevious;

    private Canvas tip;

    // Use this for initialization
    void Start()
    {
        tip = (Canvas)GetComponent<Canvas>();

        next = next.GetComponent<Button>();
        nextPrevious = nextPrevious.GetComponent<Button>();

        tip.enabled = false;
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

    public void nextPreviousClick()
    {
        Time.timeScale = 0;
        tip.enabled = true;
    }
}
