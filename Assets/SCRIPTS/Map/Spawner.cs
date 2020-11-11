using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] enemiesToSpawn;
	public int[][] n;
	public int[] n0;
	public int[] n1;
	public int[] n2;
	private int l = 0;
	private float x, y;

	public float spawnRangeSquare;

	public bool aha;

	public GameObject r;


	// Use this for initialization
	void Start () {


		aha = true;

		n = new int[3][];

		n [0] = n0;
		n [1] = n1;
		n [2] = n2;
	}
	
	// Update is called once per frame
	void Update () {

		if (aha) {
			for (int i = 0; i < enemiesToSpawn.Length; i++) 
			{
				l = Random.Range(0, n[i].Length);
				for (int j = 0; j < n[i][l]; j++) 
				{
					x = transform.position.x + Random.Range (-spawnRangeSquare, spawnRangeSquare);
					y = transform.position.y + Random.Range (-spawnRangeSquare, spawnRangeSquare);

					Instantiate (enemiesToSpawn [i], new Vector3(x, y, transform.position.z), Quaternion.identity);
				}
			}
			aha = false;
		}

	}
}
