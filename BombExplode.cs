using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script serves various action regardign the controlled player

public class BombExplode : MonoBehaviour
{
	public float fieldOfImpact; //fieldOfImpact is the circular area around the player
	public float force1 , force2; //forces created to push enemies away
	public LayerMask LayerToHit; //The Layer specified for object that are affected by the players explosion...Each object can be assigned a layer 
	public GameObject ExplosionEffect; // Reference the explosion effect
	
	public Transform m0; 
	public Transform m1;
	public Transform m2;
	public Transform m3;
	public Transform m4;  //Each Transform shows different position on the map 
	public Transform m5;
	public Transform m6;
	public Transform down;
	public Transform up;
	
	
	private int rand1;
	private int rand2;
	private int rand3; //Create six random numbers
	private int rand4;
	private int rand5;
	private int rand6;
	
    
    void Start()
    {
        rand1 = Random.Range(0,2);
		rand2 = Random.Range(0,2);
		rand3 = Random.Range(0,2); //assign all the random numbers to be between 1 and 2
		rand4 = Random.Range(0,2);
		rand5 = Random.Range(0,2);
		rand6 = Random.Range(0,2);
	
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space)) { //if space is pressed then explode(only used in unity on pc
		   explode();
	   }
	   
    }
	
	public void explode() {
		
		Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, LayerToHit); //Check all objects inside fieldOfImpact
		
		foreach(Collider2D obj in objects) { //for all object inside fieldOfImpact
			
			
			Vector2 direction = obj.transform.position - transform.position;  //direction of enemies being pushed away upon explosion 
			
			if (obj.gameObject.tag == "enemy") { //check if object has this tag
			obj.GetComponent<Rigidbody2D>().AddForce(direction * force1); //add force to the enemy to push it away
			Destroy(obj.gameObject ,0.1f); //destroy enemy after 0.1s of explosion
			}
			if (obj.gameObject.tag == "bullet") {
			obj.GetComponent<Rigidbody2D>().AddForce(direction * force2);
			}
			if (obj.gameObject.tag == "wallss") {
			Destroy(obj.gameObject);
			}
			if (obj.gameObject.tag == "r1") {
			obj.GetComponent<Rigidbody2D>().AddForce(direction * force2);
			Destroy(obj.gameObject ,0.3f);
			}
		
			
		}
		SoundManager.PlaySound("explode"); //instantiate sound upon explosion
		GameObject ExplosionEffectIns = Instantiate(ExplosionEffect, transform.position, Quaternion.identity); //instantiate explosion effect
		Destroy(ExplosionEffectIns, 3); //destroy explosion effect after 3s
		LightChanger.ChangeLess(); //if player explodes, decrease his light by specific value...ChangeLess is a function called from another script(LightChanger)
		
		
	}
	
	void OnDrawGizmosSelected() { //draw the fieldOfImpact for development purposes in unity
		
		Gizmos.color = Color.blue; //color of the fieldOfImpact
		Gizmos.DrawWireSphere(transform.position, fieldOfImpact); //draw the circular area 
	}
	
	public void ChangeField() { //function to change fieldOfImpact at some point of the game
		
		fieldOfImpact = 4f;
	}
	
	void OnCollisionEnter2D (Collision2D col) { //check collision between objects
		
		if (col.gameObject.tag == "wall") {
			ChangeField(); //call function to change fieldOfImpact if playes reaches a specified new level
			Destroy(col.gameObject); //destroy the gate of the new level
		}
		//--------------------------------------------------------------------//
		//ALL THE FOLLOWING CONDITIONS ARE TO EXECUTE THE TELEPORTATION LEVEL OF THE GAME
		//EXPLAINED IN THE REPORT
		if (col.gameObject.name == "right1") {
			if( rand1 == 0 ){
				transform.position = m1.transform.position;
				SoundManager.PlaySound("teleport");
				
			}
			else {
				transform.position = m0.transform.position;
				SoundManager.PlaySound("teleport");
				
			}
		}
		
		
		if (col.gameObject.name == "left1") {
			if( rand1 == 1){
				transform.position = m1.transform.position;
				SoundManager.PlaySound("teleport");
			}
			else {
				transform.position = m0.transform.position;
				SoundManager.PlaySound("teleport");
			}		
		}		
		
		//--------------------------------------------------------------------//
		if (col.gameObject.name == "right2") {
			if( rand2 == 0 ){
				transform.position = m2.transform.position;
				SoundManager.PlaySound("teleport");
				
			}
			else {
				transform.position = m0.transform.position;
				SoundManager.PlaySound("teleport");
				
			}
		}
		
		if (col.gameObject.name == "left2") {
			if( rand2 == 1){
				transform.position = m2.transform.position;
				SoundManager.PlaySound("teleport");
			}
			else {
				transform.position = m0.transform.position;
				SoundManager.PlaySound("teleport");
			}		
		}		
		
		//--------------------------------------------------------------------//
		if (col.gameObject.name == "right3") {
			if( rand3 == 0 ){
				transform.position = m3.transform.position;
				SoundManager.PlaySound("teleport");
				
			}
			else {
				transform.position = m0.transform.position;
				SoundManager.PlaySound("teleport");
				
			}
		}
		
		if (col.gameObject.name == "left3") {
			if( rand3 == 1){
				transform.position = m3.transform.position;
				SoundManager.PlaySound("teleport");
			}
			else {
				transform.position = m0.transform.position;
				SoundManager.PlaySound("teleport");
			}		
		}		
		
		//--------------------------------------------------------------------//
		if (col.gameObject.name == "right4") {
			if( rand4 == 0 ){
				transform.position = m4.transform.position;
				SoundManager.PlaySound("teleport");
				
			}
			else {
				transform.position = m1.transform.position;
				SoundManager.PlaySound("teleport");
				
			}
		}
		
		if (col.gameObject.name == "left4") {
			if( rand4 == 1){
				transform.position = m4.transform.position;
				SoundManager.PlaySound("teleport");
			}
			else {
				transform.position = m1.transform.position;
				SoundManager.PlaySound("teleport");
			}		
		}		
		
		//--------------------------------------------------------------------//
		if (col.gameObject.name == "right5") {
			if( rand5 == 0 ){
				transform.position = m5.transform.position;
				SoundManager.PlaySound("teleport");
				
			}
			else {
				transform.position = m2.transform.position;
				SoundManager.PlaySound("teleport");
				
			}
		}
		
		if (col.gameObject.name == "left5") {
			if( rand5 == 1){
				transform.position = m5.transform.position;
				SoundManager.PlaySound("teleport");
			}
			else {
				transform.position = m2.transform.position;
				SoundManager.PlaySound("teleport");
			}		
		}		
		
		//--------------------------------------------------------------------//
		if (col.gameObject.name == "right6") {
			if( rand6 == 0 ){
				transform.position = m6.transform.position;
				SoundManager.PlaySound("teleport");
				
			}
			else {
				transform.position = m3.transform.position;
				SoundManager.PlaySound("teleport");
				
			}
		}
		
		if (col.gameObject.name == "left6") {
			if( rand6 == 1){
				transform.position = m6.transform.position;
				SoundManager.PlaySound("teleport");
			}
			else {
				transform.position = m3.transform.position;
				SoundManager.PlaySound("teleport");
			}		
		}		
		//--------------------------------------------------------------------//
		
		
		if (col.gameObject.name == "downtaker") {
			
			transform.position = down.transform.position;
			SoundManager.PlaySound("teleport");
		}
		
		if (col.gameObject.name == "uptaker") {
			
			transform.position = up.transform.position;
			SoundManager.PlaySound("teleport");
		}
	}
	
	
}
