using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is to control the sounds in the game

public class SoundManager : MonoBehaviour
{
	public static AudioClip ExplodeSound , ZapSound, FireSound, TeleportSound, ClickSound, BatsSound; //Reference multiple sound effects
	static AudioSource audioSrc; //Reference audio source
    
    void Start()
    {
		ExplodeSound = Resources.Load<AudioClip> ("explode");
		ZapSound = Resources.Load<AudioClip> ("zap");
		FireSound = Resources.Load<AudioClip> ("fire");
		TeleportSound = Resources.Load<AudioClip> ("teleport"); // Assign sound effects according to their name in unity folder
		ClickSound = Resources.Load<AudioClip> ("click");
		BatsSound = Resources.Load<AudioClip> ("bats");
		audioSrc = GetComponent<AudioSource> ();
    }

   
    void Update()
    {
        
    }
	
	public static void PlaySound (string clip) {
		
		switch (clip) {
			
			case "explode":
				audioSrc.PlayOneShot(ExplodeSound);
				break;
			case "zap":
				audioSrc.PlayOneShot(ZapSound);
				break;
			case "fire":
				audioSrc.PlayOneShot(FireSound); //play sound effects according to each situation/buttonclick...
				break;
			case "teleport":
				audioSrc.PlayOneShot(TeleportSound);
				break;
			case "click":
				audioSrc.PlayOneShot(ClickSound);
				break;
			case "bats":
				audioSrc.PlayOneShot(BatsSound);
				break;
		}
	}
}
