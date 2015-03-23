using UnityEngine;
using System.Collections;

public class PlayerEscape : MonoBehaviour {


	public float timeToEndLevel = 3f;
	
	private SceneFadeInOut sceneFadeInOut;    
	private HashIDs hash;                      
	private GameObject player;                 
	private PlayerInventory playerInventory;    
	private bool playerEscape;
	private float timer; 



	void Awake () {
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
		player = GameObject.FindGameObjectWithTag(Tags.girl);
		playerInventory = player.GetComponent<PlayerInventory>();
		sceneFadeInOut = GameObject.FindGameObjectWithTag(Tags.fader).GetComponent<SceneFadeInOut>();
	
	}
	void OnTriggerEnter (Collider other)
	{

		if(other.gameObject == player)

			playerEscape = true;
	}
	
	
	void OnTriggerExit (Collider other)
	{

		if(other.gameObject == player)
		{

			playerEscape = false;
			//timer = 0;
		}
	}

	void Update () {
		if (playerEscape && playerInventory.hasRelic){
		    // if (Input.GetButtonDown ("Fire1"))
			//if(!audio.isPlaying && timer >= timeToEndLevel)
				//if(timer >= timeToEndLevel)
					// ... play the clip.
				//audio.clip = helicopterClip;
				//audio.Play();//audio.clip = Helicopter;
						//audio.Play ();
			//if(timer >= timeToEndLevel)    // ... call the EndScene function  .&& playerInventory.hasRelic && timer >= timeToEndLevel
			sceneFadeInOut.EndScene ();}
						
		//else if(playerEscape && Input.GetButtonDown ("Fire1") && !playerInventory.hasRelic){
				

			//else if(Input.GetButtonDown ("Fire1") && !playerInventory.hasRelic){

			//else if (Input.GetButtonDown ("Fire1"){
							// If the player doesn't have the key play the access denied audio clip.
							//audio.clip = accessDeniedClip;
				            //audio.Play();
			}


}

				
			




	

