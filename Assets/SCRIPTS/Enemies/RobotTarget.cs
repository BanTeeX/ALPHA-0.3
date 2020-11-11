using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTarget : MonoBehaviour {

	public PlayerMovement followTarget; 

	// Use this for initialization
	void Start () {

		followTarget = FindObjectOfType<PlayerMovement> ();

	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);

	}
}
