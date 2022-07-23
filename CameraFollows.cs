using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is to make the camera follow the specified player

public class CameraFollows : MonoBehaviour
{
   public Transform target; //Specify the player
   [Range(1,10)]
   public float smoothSpeed; //speed of following the player between 1 and 10
   public Vector3 offset; // position of the camera
   
   void FixedUpdate() {
	   
	   Vector3 targetPosition = target.position + offset; //position of both the camera and player
	   Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.fixedDeltaTime); //move camera position to player
	   transform.position = targetPosition;
	   
   }
}
