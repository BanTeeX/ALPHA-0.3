using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

	public GameObject followTarget;

	public bool miniMap;

	private bool a = true;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);

		if (Input.GetAxisRaw ("Camera") > 0.5) 
		{
			GetComponent<Camera> ().orthographicSize = 100;
			miniMap = true;
			if (a) 
			{
				transform.Translate (0, 0, -200);
				a = false;
				Time.timeScale = 0;
			}
		} 
		else
		{
			GetComponent<Camera> ().orthographicSize = 7;
			miniMap = false;
			if (!a) 
			{
				transform.Translate (0, 0, 200);
				a = true;
				Time.timeScale = 1;
			}
		}


	}
}
