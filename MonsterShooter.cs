using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShooter : MonoBehaviour
{
	
	[SerializeField]
	GameObject Bulletenemy;
	
	Rigidbody2D rb;
	public float fireRate;
	float nextFire;
	public static float healthAmount;
	private Transform target;
    // Start is called before the first frame update
    void Start()
    {
		healthAmount = 1;
		rb = GetComponent<Rigidbody2D>();
        fireRate = 2f;
		nextFire = Time.time;
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < 15) {
		CheckIfTimeToFire();
		}
		
    }
	
	void CheckIfTimeToFire() {
		
			if (Time.time > nextFire) {
			
				Instantiate (Bulletenemy, transform.position, Quaternion.identity);
				SoundManager.PlaySound("fire");
				nextFire = Time.time + fireRate;
			}
		
	}
	
	//void OnCollisionEnter2D (Collision2D col) {
		
		//if (col.gameObject.tag == "Bullet") {
			//healthAmount -= 0.33f;
			//if (healthAmount <= 0) {
			
			//Destroy(gameObject);
			//}
		//}
	//}
	
	
	
}
