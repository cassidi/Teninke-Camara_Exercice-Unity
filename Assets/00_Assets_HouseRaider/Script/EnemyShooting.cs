using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	public float maximumDamage = 120f;                  
	public float minimumDamage = 45f;                 
	public AudioClip shotClip;                          
	public float flashIntensity = 3f;                  
	public float fadeSpeed = 10f;                       
	
	public const float RELOAD_TIME = 3f;
	private float reload = 0f;

	private HashIDs hash;                              
	public LineRenderer laserShotLine;                
	private Light laserShotLight;                       
	private SphereCollider col;                        
	private Transform player;                           
	private PlayerHealth playerHealth;                  
	public bool shooting;                             
	private float scaledDamage;                         
	
	void Awake ()
	{
		laserShotLine = GetComponentInChildren<LineRenderer>();
		laserShotLight = laserShotLine.gameObject.light;
		col = GetComponent<SphereCollider>();
		player = GameObject.FindGameObjectWithTag(Tags.girl).transform;
		playerHealth = player.gameObject.GetComponent<PlayerHealth>();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
		

		laserShotLine.enabled = false;
		laserShotLight.intensity = 0f;
		

		scaledDamage = maximumDamage - minimumDamage;
	}
	
	
	void Update ()
	{

		if (!shooting) {

			Shoot ();
		}
		else {
			reload += Time.deltaTime;
			if(reload >= 0.5f){

				laserShotLine.enabled = false;

			}
			if(reload >= RELOAD_TIME){
				reload = 0f;
				shooting = false;
			}
		}

	
		laserShotLight.intensity = Mathf.Lerp(laserShotLight.intensity, 0f, fadeSpeed * Time.deltaTime);
		//laserShotLine.intensity = Mathf.Lerp(laserShotLight.intensity, 0f, fadeSpeed * Time.deltaTime);
	}
	
	

	
	public void Shoot ()
	{

		shooting = true;
		
		// The fractional distance from the player, 1 is next to the player, 0 is the player is at the extent of the sphere collider.
		float fractionalDistance = (col.radius - Vector3.Distance(transform.position, player.position)) / col.radius;
		
		// The damage is the scaled damage, scaled by the fractional distance, plus the minimum damage.
		float damage = scaledDamage * fractionalDistance + minimumDamage;
		
		// The player takes damage.
		playerHealth.TakeDamage(damage);
		
		// Display the shot effects.
		ShotEffects();
	}
	
	
	public void ShotEffects ()
	{
		// Set the initial position of the line renderer to the position of the muzzle.
		laserShotLine.SetPosition(0, laserShotLine.transform.position);
		
		// Set the end position of the player's centre of mass.
		laserShotLine.SetPosition(1, player.position + Vector3.up );

		// Turn on the line renderer.
		laserShotLine.enabled = true;
		
		// Make the light flash.
		laserShotLight.intensity = flashIntensity;
		
		// Play the gun shot clip at the position of the muzzle flare.
		AudioSource.PlayClipAtPoint(shotClip, laserShotLight.transform.position);
	}
}