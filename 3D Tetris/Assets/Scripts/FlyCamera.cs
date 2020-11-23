using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    public Vector3 prevPos = new Vector3(255, 255, 255);
	public Vector3 difference;
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
	void Update()
	{
		//Find difference in location for the mouse
		prevPos = Input.mousePosition;
		//If the mouse is clicked, move around accordingly
		if(Input.GetMouseButton(0))
		{
			difference = prevPos - Input.mousePosition;
			transform.position += new Vector3(0.1f, 0.0f, 0.0f);
			//If the user moves left or right with their mouse, move camera left or right
			if(difference.x > 0)
			{
				
			}
			else if(difference.x < 0)
			{
				
			}
		
			if(difference.y > 0)
			{}
			else if(difference.y < 0)
			{
				
			}
			
			
		}
	}
}
