using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public int xSize, ySize, x = 0, y = 0, counter, a;
	public int[] check;
	public Room[][] tab;
	public Room[] room;

	// Use this for initialization
	void Start () {

		counter = 0;
		//tabela pokoi
		tab = new Room[xSize][];
		for (int i = 0; i < xSize; i++)
			tab [i] = new Room[ySize];
		for (int i = 0; i < xSize; i++) {
			for (int j = 0; j < ySize; j++) {
				tab [i] [j] = new Room ();
				if (i == 0)
					tab [i] [j].exits [3] = 2;
				if (j == 0)
					tab [i] [j].exits [2] = 2;
				if (i == xSize - 1)
					tab [i] [j].exits [1] = 2;
				if (j == ySize - 1)
					tab [i] [j].exits [0] = 2;
			}
		}

		counter = 0;
		//zaczyna od 0,0
		x = 0;
		y = 0;

		while (counter < xSize * ySize) 
		{
			a = 0; //sprawdza ilość wyjść
			for (int i = 0; i < 4; i++)
				if (tab [x] [y].exits [i] != 2)
					a++;
			check = new int[a];
			a = 0; //układa wyjścia w tabelę
			for (int i = 0; i < 4; i++)
				if (tab [x] [y].exits [i] != 2) 
				{
					check [a] = i;
					a++;
				}
			Go (check[Random.Range(0, a)]); //przechodzi do kolejnego pokoju
			counter++;
		}
		counter = 0;
		x = 0;
		y = 0;
		//zamienia wszystkie 0 na brak przejścia
		for (int i = 0; i < xSize; i++) {
			for (int j = 0; j < ySize; j++) {
				for (int k = 0; k < 4; k++)
					if (tab [i] [j].exits [k] == 0)
						tab [i] [j].exits [k] = 2;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		//for bez fora (kopiowanie obiektów do świata)

		if (counter < xSize * ySize) {
			Instantiate (room[Random.Range(0,room.Length)], transform.position, Quaternion.identity, transform);
			if (y == ySize)
			{
				x++;
				y = 0;
			}
			y++;
			counter++;
		}
	}

	void Go (int d)
	{
		switch (d) 
		{
		case 0: //góra
			tab [x] [y].exits [0] = 1;
			y++;
			tab [x] [y].exits [2] = 1;
			break;
		case 1: //prawo
			tab [x] [y].exits [1] = 1;
			x++;
			tab [x] [y].exits [3] = 1;
			break;
		case 2: //dół
			tab [x] [y].exits [2] = 1;
			y--;
			tab [x] [y].exits [0] = 1;
			break;
		case 3: //lewo
			tab [x] [y].exits [3] = 1;
			x--;
			tab [x] [y].exits [1] = 1;
			break;
		}
	}
}
