using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
	public GameObject[] Tetrominoes;
    // Start is called before the first frame update
	private static int bagCount;
    void Start()
    {
		bagCount = 0;
		Shuffle();
        NewTetromino();
    }

    // Update is called once per frame
    public void NewTetromino()
    {
		if(bagCount == Tetrominoes.Length) {
			Shuffle();
			bagCount = 0;
		}
		//spawn the tetramino at the location of the spawner
        Instantiate(Tetrominoes[bagCount], transform.position, Quaternion.identity);
		bagCount++;
    }
	
	//shuffle the list;
	private void Shuffle() { 
		int randomIndex;
		
		for (int i= 0; i < Tetrominoes.Length; i++) {
			randomIndex = Random.Range(0, Tetrominoes.Length);
			swap(i, randomIndex);
		}
	}
	
	private void swap(int i, int j) {
		GameObject hold = Tetrominoes[j];
		Tetrominoes[j] = Tetrominoes[i];
		Tetrominoes[i] = hold;
	}
}
 