using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public bool isStart;
	public bool isQuit;
	public bool isCredits;
	public bool isMenu;
	public bool isHTP;
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnMouseUp()
    {
        if(isStart)
		{
			//This is to open my old scene which is the the main game
			Application.LoadLevel(2);
		}
		if(isQuit)
		{
			//Quit the game
			Application.Quit();
		}
		if(isCredits)
		{
			//Open credits scene
			Application.LoadLevel(3);
		}
		if(isMenu)
		{
			//Return back to main menu
			Application.LoadLevel(0);
		}
		if(isHTP)
		{
			//Open instructions
			Application.LoadLevel(4);
		}
    }
}
