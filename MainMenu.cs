using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this script is to load different scenes specified to different buttons

public class MainMenu : MonoBehaviour
{
	
	
	public void PlayGame() {
		
		SceneManager.LoadScene(1); //Load GamePlay scene
		LightChanger.check = false; //reset boolean used in other script
		LightChanger.MenuCheck = false; //reset boolean used in other script
		Time.timeScale = 1; //Resume Time
		SoundManager.PlaySound("bats"); //Play sound
		
	}
	
		public void PlayGame2() {
		
		SceneManager.LoadScene(2); //Load GamePlay scene
		LightChanger.check = false; //reset boolean used in other script
		LightChanger.MenuCheck = false; //reset boolean used in other script
		Time.timeScale = 1; //Resume Time
		SoundManager.PlaySound("bats"); //Play sound
		
	}

	public void QuitGame() {
		
		Application.Quit(); //Button to quit game
		
	}
	public void Pause() {
		
        Time.timeScale = 0; //stop time when pause is clicked
		
	}
	public void Continue() {
		
		Time.timeScale = 1; //resume time
	}
	
	public void Menu () {
		
		SceneManager.LoadScene(0); //load MainMenu scene
		
		
	}
	
}
