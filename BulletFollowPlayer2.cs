using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is to make bullets go to the player's position
//A similar script to this is for other bullets so that not all bullets are shot exactly the same

public class BulletFollowPlayer2 : MonoBehaviour
{
    public float speed; //speed of the bullet
	private Transform Player; //reference of the player
	private Vector2 target; //position of the player
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform; //Find the player through its specified tag 
		target = new Vector2(Player.position.x  , Player.position.y); //Find the player's position
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position , target , speed* Time.deltaTime); //Make bullets move to specified position
		Destroy(gameObject, 5);
		
    }
	
	void OnCollisionEnter2D (Collision2D col) {
		
			
			if (col.gameObject.tag == "walls") {
				
				Destroy(gameObject); //if bullet hits a wall, destroy bullet immediatly
				
			}
			
	}
}
