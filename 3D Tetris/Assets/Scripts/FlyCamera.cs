using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    public Vector3 prevMousePos = new Vector3(255f, 255f, 255f);
	public Vector3 difference, currentMousePos;
	public GameObject game;
	public float distance;
	public Camera BECam;
	public Camera mainCam;
	// Start is called before the first frame update
    void Start()
    {
		BECam.enabled = false;
		mainCam.enabled = true;
    }

    // Update is called once per frame
	void Update()
	{

		//If the mouse is clicked, move around accordingly
		if(Input.GetMouseButton(0))
		{

			currentMousePos = Input.mousePosition;
			difference = prevMousePos - currentMousePos;
			distance = Mathf.Sqrt(difference.x*difference.x + difference.y*difference.y);
			if(distance > 120)
			{
				distance = 120;
			}
			if(difference.x > 0)
			{
				//Rotate and translate based on position
				transform.RotateAround(game.transform.position, Vector3.up,distance*Time.deltaTime);
				
			}
			else if(difference.x < 0)
			{
				
				//Rotate and translate based on position
				transform.RotateAround(game.transform.position, Vector3.down,distance*Time.deltaTime);
				
			}
		}
		else
		{
			//Find difference in location for the mouse
			prevMousePos = Input.mousePosition;
			
		}
		if(Input.GetKey(KeyCode.F))
		{
			BECam.enabled = true;
			mainCam.enabled = false;
		}
		else
		{
			mainCam.enabled = true;
			BECam.enabled = false;
		}

		
	}
}
