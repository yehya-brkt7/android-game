using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This script is to control the behavior and relation between player and time recorded

public class Timer : MonoBehaviour
{
	public  TMP_Text timerText; //Reference InGame Text
	public float startTime; //Start time = 0.0s
	public PlayFabLogin playfablogin; //Reference of another script PlayFabLogin
	private bool finished = false;
	public static string officialTime;
	private string newtime;
	private int startTimeconverted; 
	//public static int usedtime;
	public static bool minutes = false;
    
    void Start()
    {
        startTime = Time.time;
    }
	

    
    void Update() //This is to stop and record the time when the finish line is crossed
    {
		
		if (finished) 
			return;
		
        float t = Time.time - startTime;
		
		string minutes = ((int) t / 60).ToString();
		string seconds = (t%60).ToString("f2");
		officialTime = minutes + "." + seconds;
		newtime = officialTime.Replace("." , "");
		timerText.text = newtime;
		//timerText.text = minutes + "." + seconds;
    }
	
	public void finish() { //this function gets called when the finish line is crossed
		
		startTimeconverted = int.Parse(newtime); //cast float to int since playfab data only accepts integers 
		if (startTimeconverted > 50000) {
			
			minutes = true;
		}
		finished = true; 
		timerText.color = Color.red; //change color of time recorded to red when finish line is crossed
		playfablogin.SendLeaderBoard(startTimeconverted); //call playfab data function to send the time recorded 
	}
	
}
