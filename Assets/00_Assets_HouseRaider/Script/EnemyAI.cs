using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {


	public const float RELOAD_TIME = 3f;
	private float reload = 0f;
	
	private EnemySight enemySight;                        
	private EnemyShooting enemyShoot;
	private Transform player;                              
	private PlayerHealth playerHealth;                      
	private LastPlayerSighting lastPlayerSighting;          

	
	void Awake ()
	{

		enemySight = GetComponent<EnemySight>();
		enemyShoot = GetComponent<EnemyShooting>();
		player = GameObject.FindGameObjectWithTag(Tags.girl).transform;
		playerHealth = player.GetComponent<PlayerHealth>();
		lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
	}
	
	
	void Update ()
	{
	
		if (enemySight.playerInSight && playerHealth.health > 0f) {

			if (!enemyShoot.shooting) {
				
				Shooting ();
			}
			else {
				reload += Time.deltaTime;
				if(reload >= 0.5f){
					enemyShoot.laserShotLine.enabled = false;

				}
				if(reload >= RELOAD_TIME){
					reload = 0f;
					enemyShoot.shooting = false;
				}
			}

				}
		

	}
	void Shooting()
	{
		enemyShoot.Shoot();
	}
	

}