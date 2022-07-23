using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is to show PopUpMenu when Pause button is pressed 

public class PopUpMenu : MonoBehaviour
{
    public Canvas canvas; //Reference Menu
	public bool check = false;
	
	public void PopUp() { //This function checks if button is pressed and turns off gameplay canvas and turns on PopUpMenu
		
		if (check==false) {
			
			check = true;
			canvas.enabled = true;
		}
		else if (check == true) {
			
			check = false;
			canvas.enabled = false;
		}
	}
}
