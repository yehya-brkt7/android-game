using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is to play music during GamePlay and MainMenu

public class MusicPlayer : MonoBehaviour
{
	
	public AudioClip[] clips; //List of music clips
	private AudioSource audioSource; //Reference of audio source
    
    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>(); //assign audio source
		audioSource.loop = false; //Loop song or not
    }

	private AudioClip GetRandomClip() {
		
		return clips[Random.Range(0, clips.Length)]; //Play random song 
	}
    
    void Update()
    {
		if(!audioSource.isPlaying) {
			audioSource.clip = GetRandomClip(); //play another song when previous one is over
			audioSource.Play();
		}
    }
}
