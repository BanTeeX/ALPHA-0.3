using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckTip : MonoBehaviour
{

    public Button next;
    public Collider2D check;
    public GameObject checkObject;
    public Collider2D player;

    private Canvas tip;

    // Use this for initialization
    void Start()
    {
        tip = (Canvas)GetComponent<Canvas>();

        next = next.GetComponent<Button>();

        tip.enabled = false;
        checkObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsTouching(check))
        {
            Time.timeScale = 0;
            tip.enabled = true;
        }
    }

    public void nextClick()
    {
        tip.enabled = false;
        Time.timeScale = 1;
        checkObject.SetActive(false);
    }
}