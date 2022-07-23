using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is to instantiate the bats effect at the start of the game

public class Bats : MonoBehaviour
{
	
	public GameObject BatsEffect; //Reference the Bats effect and choose it in unity
    
    void Start()
    {
        GameObject BatsEffectIns = Instantiate(BatsEffect, transform.position, Quaternion.identity); //Create the bats effect
		
    }

}
