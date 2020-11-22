using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
	public GameObject[] Tetrominoes;
	public GameObject previewTetramino;
	public Vector3 previewPosition;
	public Quaternion previewRotation;
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
		if(previewTetramino != null) {
			Destroy(previewTetramino);
		}
		
		if(bagCount == Tetrominoes.Length -1) {	
			Instantiate(Tetrominoes[bagCount], transform.position, Quaternion.identity);
			Shuffle();	
			previewTetramino = (GameObject)Instantiate(Tetrominoes[bagCount], previewPosition, previewRotation);
			TetrisBlock block = previewTetramino.GetComponent(typeof(TetrisBlock)) as TetrisBlock;
			block.canMove = false;
			bagCount = 0;
		}
		else {
			//spawn the tetramino at the location of the spawner
			Instantiate(Tetrominoes[bagCount], transform.position, Quaternion.identity);
			
			previewTetramino = (GameObject)Instantiate(Tetrominoes[bagCount + 1], previewPosition, previewRotation);
			TetrisBlock block = previewTetramino.GetComponent(typeof(TetrisBlock)) as TetrisBlock;
			block.canMove = false;
			bagCount++;
		}
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
 