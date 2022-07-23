using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

//This script is to control the light of the player

public class LightChanger : MonoBehaviour
{
    
    public static Light myLight; //reference the player's light
	public GameObject player; //reference the player
	public static PopUpMenu pop; //Reference the PopUpMenu that appears after pressing a button
	public static Button btn; //Reference a button
	public static Button MenuBtn; //Reference a button

	

	void Start () {
         
		 btn = GameObject.Find("Recharge").GetComponent<Button>(); //assign button through its name
		 MenuBtn = GameObject.Find("ad").GetComponent<Button>(); //assign button through its name
		 btn.interactable = false; //turn off button at start of the game
		 MenuBtn.interactable = false; //turn off button at start of the game
         myLight = GetComponent<Light>(); //assign the player's light
		 StartCoroutine(ColorChangeRoutine()); //call Coroutine function to change light color
		 player = GameObject.Find ("Player"); //assign player
		 
     }   
	
	private IEnumerator ColorChangeRoutine() { //This function changes the players light color every 3s
		while (true) { //random value is given for R(red), G(green), B(blue) and trasnparency between specified values
			myLight.color = new Color32(System.Convert.ToByte(Random.Range(0, 200)), System.Convert.ToByte(Random.Range(0, 50)), System.Convert.ToByte(Random.Range(0, 150)), 255);
			yield return new WaitForSeconds(3);
		}
	}
	
	

	
	public static void Change() {
		
		myLight.range -= 0.06f; //static function to be called in other scripts...decrease light by specified value
	}
	public static void ChangeLess() {
		
		myLight.range -= 0.024f; //static function to be called in other scripts...decrease light by specified value
	}
	public static void Black() {
		
		myLight.color = Color.black; //static function to be called in other scripts...change light color
	}
	
	//THE FOLLOWING CODE IS TO ALLOW PLAYER TO PRESS RECHARGE LIGHT BUTTON ONLY ONCE
	//AND THE PopUpMenu RECHARGE BUTTON TWICE (user has to watch rewarded video ad which are to be implemented later )
	public static bool check = false;
	public static bool MenuCheck = false;
	public static bool MenuCheck2 = false;
	public static int counter = 0;
	
	public static void ReCharge() { //increase player's light range by 2 when button is clicked
		
			myLight.range += 2f;
			check = true;
			
	
	}
	public static void ReChargeMenu() { //increase player's light range by 1 when button is clicked in the PopUpMenu
		
			myLight.range += 1f;
			MenuCheck = true;
			counter++;
	
	}
	
	void Update() {
		
		if (myLight.range <= 1.5f) {
			Destroy(player);
			SceneManager.LoadScene(0);
		}
		
		if(myLight.range <= 2.2f) {
			
			btn.interactable = true;
		}
		if(myLight.range <= 2.2f && check ==true) {
			
			MenuBtn.interactable = true;
		}
		
		if (check == true) {
			btn.interactable = false;
			btn.GetComponent<Image>().color = Color.grey;
		}
		
		
		
		if (MenuCheck == true) {
			
			MenuCheck2 = true;
			MenuBtn.interactable = false;
			
			
		}
		if (myLight.range <= 2.2 && MenuCheck2 == true && counter<2) {
		
			MenuBtn.interactable = true;
		}
		
		
		
		
		
		
	}
	
}