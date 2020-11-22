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

    public void NewTetromino()
    {
		if(previewTetramino != null) {
			Destroy(previewTetramino);
		}
		
		if(bagCount == Tetrominoes.Length -1) {	
			spawnpiece(bagCount);
			Shuffle();	
			previewTetramino = (GameObject)Instantiate(Tetrominoes[bagCount], previewPosition, previewRotation);
			TetrisBlock block = previewTetramino.GetComponent(typeof(TetrisBlock)) as TetrisBlock;
			block.canMove = false;
			bagCount = 0;
		}
		else {
			//spawn a tetramino at the current position
			spawnpiece(bagCount);
			previewTetramino = (GameObject)Instantiate(Tetrominoes[bagCount + 1], previewPosition, previewRotation);
			TetrisBlock block = previewTetramino.GetComponent(typeof(TetrisBlock)) as TetrisBlock;
			block.canMove = false;
			bagCount++;
		}
    }
	
	public GameObject getCurrentPiece() {
		return Tetrominoes[bagCount];
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
	
	
	//spawn the tetramino at the location of the spawner
	private void spawnpiece(int n) {
		GameObject tetramino = (GameObject)Instantiate(Tetrominoes[n], transform.position, Quaternion.identity);
		TetrisBlock currentPiece = tetramino.GetComponent(typeof(TetrisBlock)) as TetrisBlock;
		
		if(!currentPiece.ValidMove()) {
			Application.LoadLevel(1);
		}
	}
	
}
 