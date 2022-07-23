using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevel2 : MonoBehaviour
{
	
	public Button btn; //Reference a button
	
    // Start is called before the first frame update
    void Start()
    {
		btn.interactable = false; //turn off button at start of the game  
	
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.minutes == true) {
			
			btn.interactable = true;
		}
    }
}
