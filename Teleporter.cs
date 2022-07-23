using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
	public Transform destination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnCollisionEnter2d (Collision2D col) {
		
		if (col.gameObject.tag == "r1") {
		//gameObject.transform.position = destination.transform.position;
		Destroy(col.gameObject);
		}
		
	}
}

