using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float health = 100f;   
	public float currentHealth;  
	public float resetAfterDeathTime = 5f;              
	public AudioClip deathClip;    
	public Slider healthSlider;                                 // Reference to the UI's health bar.
	public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.                                 // The audio clip to play when the player dies.
	public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

	
	
	private Animator anim;                              
	          
	private HashIDs hash;                               
	private SceneFadeInOut sceneFadeInOut;              
	private LastPlayerSighting lastPlayerSighting;      
	private float timer;                                
	private bool playerDead;        
	private bool damaged; // A bool to show if the player is dead or not.
	AudioSource playerAudio;   
	
	
	void Awake ()
	{

		anim = GetComponent<Animator>();

		playerDead = false;
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
		sceneFadeInOut = GameObject.FindGameObjectWithTag(Tags.fader).GetComponent<SceneFadeInOut>();
		lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
		currentHealth = health;
		playerAudio = GetComponent <AudioSource> ();
	}
	
	
	void Update ()
	{

		print ("Health : "+health);

		if(damaged)
		{
			// ... set the colour of the damageImage to the flash colour.
			damageImage.color = flashColour;
		}
		// Otherwise...
		else
		{
			// ... transition the colour back to clear.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		
		// Reset the damaged flag.
		damaged = false;
	


		if(currentHealth <= 0f)
		{

			// ... and if the player is not yet dead...
			if(!playerDead){
			
				PlayerDying();
		}
			else
			{
				// Otherwise, if the player is dead, call the PlayerDead and LevelReset functions.
				PlayerDead();
				LevelReset();

			}
		}
	}
	
  
	void PlayerDying ()
	{
		// The player is now dead.
		playerDead = true;
	
		//Set the animator's dead parameter to true also.
		anim.SetBool(hash.deadBool, playerDead);
		
		// dying sound effect
		AudioSource.PlayClipAtPoint(deathClip, transform.position);

	}
	
	
	void PlayerDead ()
	{
		// If the player is in the dying state then reset the dead parameter.
		if(anim.GetCurrentAnimatorStateInfo(0).nameHash == hash.dyingState)
			anim.SetBool(hash.deadBool, false);

		
		// Reset the player sighting to turn off the alarms.
		lastPlayerSighting.position = lastPlayerSighting.resetPosition;
		
		// Stop the footsteps playing.
		//audio.Stop();
	}
	
	
	void LevelReset ()
	{
		// Increment
		timer += Time.deltaTime;
		
		//secure
		if(timer >= resetAfterDeathTime)
			// ... reset level.
			sceneFadeInOut.EndScene();
	}
	
	
	public void TakeDamage (float amount)
	{
		damaged = true;

		currentHealth -= amount;


	
	// Set the health bar's value to the current health.
	healthSlider.value = currentHealth;
	
	// Play the hurt sound effect.
	playerAudio.Play ();
	
	}
}