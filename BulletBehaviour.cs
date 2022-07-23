using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
	
	public float moveSpeed = 140f;
	Rigidbody2D rb;
	Player target;
	Vector2 moveDirection;
    
    void Start()
    {
		
        rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindObjectOfType<Player>();
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2 (moveDirection.x , moveDirection.y);
		
    }

   
	

}
