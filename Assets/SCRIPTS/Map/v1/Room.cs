using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

	public int[] exits;
	public int x, y, a = 0;
	public GameObject wallN, wallS, wallE, wallW;
	public Generator gen;


	// Use this for initialization
	void Start () {

		//odnajduje siebie w tabeli z generatora
		gen = FindObjectOfType<Generator>();
		x = gen.x;
		y = gen.y - 1;
		transform.position = new Vector3 (x * 30, y * 29, y) ;

		wallN.SetActive (false);
		wallE.SetActive (false);
		wallS.SetActive (false);
		wallW.SetActive (false);

		//sprawdza czy wszystkie wyjścia są zamknięte
		exits = gen.tab [x][y].exits;
		for (int k = 0; k < 4; k++) 
		{
			if (exits [k] == 2)
				a++;
		}
		//jeśli tak niszczy
		if (a == 4)
			Destroy (gameObject);
		
		//wypełana wyjścia ścianami
		if (exits [0] == 2)
			wallN.SetActive (true);
		if (exits [1] == 2)
			wallE.SetActive (true);
		if (exits [2] == 2)
			wallS.SetActive (true);
		if (exits [3] == 2)
			wallW.SetActive (true);





	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Room ()
	{
		exits = new int[4];
		for (int i = 0; i < 4; i++)
			exits [i] = 0;
	}
}
