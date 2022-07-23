using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is to raise the frames per second ration is game 

public class TargetFrameRate : MonoBehaviour
{
	public int target = 60;
    
    void Start()
    {
        QualitySettings.vSyncCount = 0;
    }

    
    void Update()
    {
        if (target != Application.targetFrameRate) {
			
			Application.targetFrameRate = target;
		}
    }
}
