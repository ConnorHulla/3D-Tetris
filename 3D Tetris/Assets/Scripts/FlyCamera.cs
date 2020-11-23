using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    public Vector3 prevMousePos = new Vector3(255f, 255f, 255f);
	public Vector3 difference, currentMousePos, calc;
	public float speed = 2.0f;
	public int time = 0;
	public float distance2d;
	private Vector3 gameCenter = new Vector3(2.5f,0.0f,2.5f);
	private Vector3 cameraPos = new Vector3(-8f,10f,-8f);
	// Start is called before the first frame update
    void Start()
    {
		distance2d = Mathf.Sqrt(Mathf.Pow((gameCenter.x - cameraPos.x), 2) + Mathf.Pow((gameCenter.z - cameraPos.z), 2));
		calc = new Vector3(Mathf.Cos(time*speed)*-distance2d,10,Mathf.Sin(time*speed)*-distance2d) + gameCenter;
		Debug.Log(calc);
		transform.position = calc;
		transform.Rotate(15f,90f,0.0f);
    }

    // Update is called once per frame
	void Update()
	{

		//If the mouse is clicked, move around accordingly
		if(Input.GetMouseButton(0))
		{
			
			currentMousePos = Input.mousePosition;
			difference = prevMousePos - currentMousePos;
			//transform.position += new Vector3(0.1f, 0.0f, 0.0f);
			//If the user moves left or right with their mouse, move camera left or right
			if(difference.x > 0)
			{
				time++;
				calc = new Vector3(Mathf.Cos(time*speed)*-distance2d,10,Mathf.Sin(time*speed)*-distance2d) + gameCenter;
				Debug.Log(calc);
				transform.position = calc;
			}
			else if(difference.x < 0)
			{
				time--;
				calc = new Vector3(Mathf.Cos(time*speed)*-distance2d,10,Mathf.Sin(time*speed)*-distance2d) + gameCenter;
				Debug.Log(calc);
				transform.position = calc;
			}
			//If the user moves up or down with their mouse, move camera up or down??
			if(difference.y > 0)
			{
				
			}
			else if(difference.y < 0)
			{
				
			}
			
			
		}
		else
		{
			//Find difference in location for the mouse
			prevMousePos = Input.mousePosition;
		}
	}
}
