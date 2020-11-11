using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorV2 : MonoBehaviour {

	public int xSize, ySize, x = 0, y = 0, counter, a;
	public int[] check;
	public RoomV2[][] tab;
	public RoomV2[][] roomTypes;


	// Use this for initialization
	void Start () {

		tab = new RoomV2[xSize][];
		for (int i = 0; i < xSize; i++)
			tab [i] = new RoomV2[ySize];

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
