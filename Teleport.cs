using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is to show the shape of the teleportion gate in game

public class Teleport : MonoBehaviour
{
	public GameObject TeleportEffect;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        GameObject TeleportEffectIns = Instantiate(TeleportEffect, transform.position, Quaternion.identity);
    }
}
