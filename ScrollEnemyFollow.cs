using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is to control behaviour of Enemies

public class ScrollEnemyFollow : MonoBehaviour
{
    public float speed; //enemy speed
	public float stoppingDistance; //distance between enemy and playe at which enemy stops following player
	public GameObject RoundEffect; //Reference enemy movement effect
	private Transform target; //Reference player position
	
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //assign target to player
    }

    void Update()
    {
		if (Vector2.Distance(transform.position, target.position) < 5.7) { //check if the player is this close (50) from the enemy 
			if (Vector2.Distance(transform.position, target.position) > stoppingDistance) { //decide when the enemy stops chasing the player to prevent colliding
			
				transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // Start chasing target
				GameObject RoundEffectIns = Instantiate(RoundEffect, transform.position, Quaternion.identity); //Create effect
			}
		}
    }
	
	void OnCollisionEnter2D (Collision2D col) { //check collision between player and enemy
		
		if (gameObject.tag == "r1") {
			if(col.gameObject.tag == "Player") {
			
				Destroy(gameObject); //destroy enemy upon collision
			}
		}
	}
}
