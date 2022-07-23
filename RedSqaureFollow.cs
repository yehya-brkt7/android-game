using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is to control the behaviour of the square enemy

public class RedSqaureFollow : MonoBehaviour
{
    public float speed; //speed of enemy
	public float stoppingDistance; //distance between enemy and playe at which enemy stops following player
	public GameObject RoundEffect; //Reference enemy movement effect
	private Transform target; //Reference player position
	
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //assign target to player
    }

    
    void Update()
    {
		if (Vector2.Distance(transform.position, target.position) < 50) { //check if the player is this close (50) from the enemy 
			if (Vector2.Distance(transform.position, target.position) > stoppingDistance) { //decide when the enemy stops chasing the player to prevent colliding
			
				transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // Start chasing target
				GameObject RoundEffectIns = Instantiate(RoundEffect, transform.position, Quaternion.identity); //Creat effect
			}
		}
    }
}
