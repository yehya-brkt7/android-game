using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is assigned for the finish line of the game

public class FinishLine : MonoBehaviour
{
   private void OnTriggerEnter2D (Collider2D other) { //check if finish line is crossed
	   
	   GameObject.Find("Player").SendMessage("finish"); //Find finish line through object's name
   }
   void Awake() {
	   
	   DontDestroyOnLoad(this); //Do not destroy the object when tranitioning between scenes
   }
}
