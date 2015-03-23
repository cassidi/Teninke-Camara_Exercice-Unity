using UnityEngine;
using System.Collections;

public class StingerMusic : MonoBehaviour {
	
	public AudioClip GrabClip;                       
	
	private GameObject player;                      
	private PlayerInventory playerInventory;        
	public float fadeSpeed = 7f;                                        
	public float musicFadeSpeed = 1f;  
	private float timer; 
	public float timerstinger = 6f;
	private AudioSource stinger;
	
	
	
	
	
	void Awake ()
	{
		
		player = GameObject.FindGameObjectWithTag(Tags.girl);
		playerInventory = player.GetComponent<PlayerInventory>();
		stinger = transform.Find("Stinger").audio;
		playerInventory.hasRelic = false;
		
	}
	
	
	void Update ()
	{
		
		if (playerInventory.hasRelic = true) {
			audio.clip = GrabClip;
			audio.Play();
			MusicFading();
			timer = 0;
			
		}
	}
	
	
	void MusicFading()
	{
		// If the alarm is not being triggered...
		if(playerInventory.hasRelic)
		{
			// ... fade out the normal music...
			audio.volume = Mathf.Lerp(audio.volume, 0f, musicFadeSpeed * Time.deltaTime);
			
			// ... and fade in the panic music.
			stinger.volume = Mathf.Lerp(stinger.volume, 0.8f, musicFadeSpeed * Time.deltaTime);
		}
		else if(timer >= timerstinger)
		{
			// Otherwise fade in the normal music and fade out the panic music.
			audio.volume = Mathf.Lerp(audio.volume, 0.8f, musicFadeSpeed * Time.deltaTime);
			stinger.volume = Mathf.Lerp(stinger.volume, 0f, musicFadeSpeed * Time.deltaTime);
		}
	}
	
}



