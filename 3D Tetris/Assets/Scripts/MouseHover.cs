using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    //Mouse enters -> change text color to light blue
    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = new Color(.561f,.863f,.992f);
    }
	
	//Mouse exits -> change text color back to white
	void OnMouseExit()
	{
		GetComponent<Renderer>().material.color = Color.white;
	}
}
