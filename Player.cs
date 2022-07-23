using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is to assign the player that will be moved with the MovementJoystick

public class Player : MonoBehaviour
{
	
	public MovementJoystick movementJoystick; //Reference joystick
	public float playerSpeed; //speed of player movement
	private Rigidbody2D rb;  //Reference RigodBody of player
	
    void Start()
    {
		rb = GetComponent<Rigidbody2D>(); //assign rigidbody of player
    }

    
    void FixedUpdate() //move player with joystick movement
    {
        if(movementJoystick.joystickVec.y !=0) {
			
			rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);
		}
		
		else {
			
			rb.velocity = Vector2.zero;
		}
    }
}
