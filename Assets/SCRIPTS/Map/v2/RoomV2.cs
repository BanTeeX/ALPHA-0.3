using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomV2 : MonoBehaviour {

	public int x, y, xSize, ySize, number;
	public int[] exits;


	// Use this for initialization
	void Start () {

		exits = new int[(xSize + ySize) * 2];



	}
	
	// Update is called once per frame
	void Update () {



	}

	RoomV2()
	{
		for (int i = 0; i < (xSize + ySize) * 2; i++)
			exits [i] = 0;
	}
}
