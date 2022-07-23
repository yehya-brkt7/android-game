using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is to create a flash screen effect when pressing explosion button

public class FlashScreen : MonoBehaviour
{
    public Canvas canvas; //Assign the canvas(image) to appear when pressing button
    public bool check = false; 
	public bool updateOn = true;
 
	public void TurnOn () {
		
		if (updateOn == true) {
			canvas.enabled = true;
			
		}
		
	}
	
	public void TurnOff () {
		 StartCoroutine (updateOff()); //call below IEnumerable functions
		 StartCoroutine (Reset());
		 
		 
	}
	 
	 
	public IEnumerator updateOff ()
	{
		yield return new WaitForSeconds (0.05f); //Make flash screen for only 0.05s
		updateOn = false; 
		canvas.enabled = false;
		check = true;
	}
	
	public IEnumerator Reset ()
	{
		yield return new WaitForSeconds (0.05f); //reset boolean to false after 0.05s 
		updateOn = true;
	}
	
	
	
}
