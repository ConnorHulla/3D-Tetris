using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
	public GameObject[] Tetrominoes;
    // Start is called before the first frame update
    void Start()
    {
        NewTetromino();
    }

    // Update is called once per frame
    public void NewTetromino()
    {
        Instantiate(Tetrominoes[Random.Range(0,Tetrominoes.Length)], transform.position, Quaternion.identity);
    }
}
 