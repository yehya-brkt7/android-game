using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is to allow an enemy ai to follow the player
//Other identical scripts to this one serve the same role but to different objects 

public class EnemyFollow : MonoBehaviour
{
	public float speed; //speed of moving
	public float stoppingDistance; //at what distance between the enemy and player does the enemy stop following the player 
	private Transform target; ////Reference the target to be followed
	
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //assign variable target to be the player
    }

    
    void Update()
    {
		if (Vector2.Distance(transform.position, target.position) < 4.4) { //check if the player is this close (10) from the enemy 
			if (Vector2.Distance(transform.position, target.position) > stoppingDistance) { //decide when the enemy stops chasing the player to prevent colliding
			
				transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // Start chasing target
			}
		}
    }
}
