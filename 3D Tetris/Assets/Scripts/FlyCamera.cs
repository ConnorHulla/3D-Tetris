using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    public Vector3 mousePos = new Vector3(255, 255, 255);
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
	void Update()
	{
		
		if(Input.GetMouseButtonDown(0))
		{
			Debug.Log("hecc");
			Debug.Log(Input.mousePosition);
		}
	}
}
