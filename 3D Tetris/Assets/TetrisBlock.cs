using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{	

	public Vector3 rotationPoint;
	
	private float time;
	public float timePeriod;
	public static int height = 10;
	public static int width = 8;
	public static int length = 8;
	private static Transform[,,] grid = new Transform[width,height,length];

	bool canFall = true;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
		timePeriod = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > timePeriod){
			 transform.position += new Vector3(0,-1,0);
			 if(!ValidMove()) {
				 transform.position -= new Vector3(0,-1,0);
				 AddToGrid();
				 this.enabled = false;
				 FindObjectOfType<spawn>().NewTetromino(); 
				 CheckForLines();
			 }
			 time = 0;
		}
		
		if(Input.GetKeyDown(KeyCode.W)) {
			transform.position += new Vector3(0, 0, 1);
			if(!ValidMove()) {
				transform.position -= new Vector3(0, 0, 1);
			}
		}
		else if(Input.GetKeyDown(KeyCode.A)) {
			transform.position += new Vector3(-1,0,0);
			if(!ValidMove()) {
				transform.position -= new Vector3(-1,0,0);
			}
		}
		else if(Input.GetKeyDown(KeyCode.D)) {
			transform.position += new Vector3(1,0,0);
			if(!ValidMove()) {
				transform.position -= new Vector3(1,0,0);
			}
		}
		else if(Input.GetKeyDown(KeyCode.S)) {
			transform.position += new Vector3(0, 0,-1);
			if(!ValidMove()) {
				transform.position -= new Vector3(0, 0, -1);
			}
		}
		else if(Input.GetKeyDown(KeyCode.Space)) {
			transform.position += new Vector3(0, -1,0);
			if(!ValidMove()) {
				transform.position -= new Vector3(0, -1, 0);
			}
		}
		//rotation logic
		else if(Input.GetKeyDown(KeyCode.J)) {
			transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), 90);
			if(!ValidMove()) {
				transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), -90);
			}
		}
		else if(Input.GetKeyDown(KeyCode.L)) {
			transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), -90);
			if(!ValidMove()) {
				transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), 90);
			}
		}
		else if(Input.GetKeyDown(KeyCode.I)) {
			transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(1,0,0), 90);
			if(!ValidMove()) {
				transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(1,0,0), -90);
			}
		}
		else if(Input.GetKeyDown(KeyCode.K)) {
			transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(1,0,0), -90);
			if(!ValidMove()) {
				transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(1,0,0), 90);
			}
		}
		else if(Input.GetKeyDown(KeyCode.P)) {
			canFall = !canFall;
		}
		else if(Input.GetKeyDown(KeyCode.H)) {
			while(ValidMove()) {
				transform.position += new Vector3(0, -1, 0);
			}
			transform.position -= new Vector3(0, -1, 0);
			AddToGrid();
			this.enabled = false;
			FindObjectOfType<spawn>().NewTetromino(); 
			CheckForLines();
		}
		
		if(canFall)
		{
			time += UnityEngine.Time.deltaTime;
		}
    }
	bool ValidMove() {
		foreach (Transform children in transform) {
			int roundedX = Mathf.RoundToInt(children.transform.position.x);
			int roundedY = Mathf.RoundToInt(children.transform.position.y);
			int roundedZ = Mathf.RoundToInt(children.transform.position.z);
			
			//check for x
			if(roundedX < 0 || roundedX >= width) {
				return false;
			}
			//check for y
			if(roundedY < 0 || roundedY >= height) {
				return false;
			}
			//check for z
			if(roundedZ < 0 || roundedZ >= length) {
				return false;
			}
			//if this child is in a spot that is already occupied
			if(grid[roundedX, roundedY, roundedZ] != null) {
				return false;
			}
		}
		return true;
	}
	
	void CheckForLines() {
		bool isLine;
		//fill in the list of lines to delete
		List<int> linesToDelete = new List<int>();
		for(int i = 0; i < height; i++) {
			isLine = true;
			for(int j = 0; j < width; j++) {
				for(int k = 0; k < length; k++) {
					if(grid[j,i,k] == null) {
						isLine = false;
						break;
					}
				}
				if(isLine == false) {
					break;
				}
			}
			if(isLine == true) {
				linesToDelete.Add(i);
			}
		}
		int z = 0;
		//deleteall the lines 
		foreach (int del in linesToDelete) {
			deleteLine(del - z);
			z++;
		}
	}
	void deleteLine(int lineToDelete) {
		//step 1: delete all the tetraminos in the line
		for(int i = 0; i < width; i++) {
			for(int j = 0; j < length; j++) {
				Destroy(grid[i, lineToDelete,j].gameObject);
				grid[i,lineToDelete, j] = null;
			}
		}
		//step 2: move everything down by 1
		for(int i = lineToDelete + 1 ; i < height; i++) {
			for(int j = 0; j < width; j++) {
				for(int k = 0; k < length; k++) {	
					if(grid[j, i,k] != null) {
						grid[j, i-1,k] = grid[j, i,k];
						grid[j, i,k] = null;
						grid[j, i-1,k].transform.position -= new Vector3(0, 1,0);
					}
				}
			}
		} 
	}
	
	void AddToGrid() {
		foreach (Transform children in transform) {
			int roundedX = Mathf.RoundToInt(children.transform.position.x);
			int roundedY = Mathf.RoundToInt(children.transform.position.y);
			int roundedZ = Mathf.RoundToInt(children.transform.position.z);
			grid[roundedX, roundedY, roundedZ] = children;
		}
	}
}
