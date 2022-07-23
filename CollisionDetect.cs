using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is to detect collision between player and other objects

public class CollisionDetect : MonoBehaviour
{
  
	
	void OnCollisionEnter2D (Collision2D col) {
		
		if (col.gameObject.tag == "enemy") { //if collided object has this specified tag
			LightChanger.Change(); //Decrease the players range if light by specified value;
			SoundManager.PlaySound("zap"); //Create sound upon collision
			
		} 
		
		if (col.gameObject.tag == "bullet") {
			LightChanger.Change();
			SoundManager.PlaySound("zap");
			
		}
		
		if (col.gameObject.tag == "square") {
			LightChanger.Change();
			SoundManager.PlaySound("zap");
			
		}
		
		if (col.gameObject.tag == "r1") {
			LightChanger.Change();
			SoundManager.PlaySound("zap");
			
		}
		if (col.gameObject.tag == "bounds") {
			LightChanger.Change();
			SoundManager.PlaySound("zap");
			
		}
		if (col.gameObject.tag == "walls") {
			LightChanger.Change();
			SoundManager.PlaySound("zap");
			
		}
		
	}
}
