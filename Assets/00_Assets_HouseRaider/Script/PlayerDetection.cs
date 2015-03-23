using UnityEngine;
using System.Collections;

public class PlayerDetection : MonoBehaviour {

	private GameObject player;                          
	private LastPlayerSighting lastPlayerSighting;      
	
	private EnemySight enemySight;
	public GameObject enemySightContainer;

	void Awake ()
	{
		enemySight = GetComponentInParent<EnemySight>();

		player = GameObject.FindGameObjectWithTag(Tags.girl);
		lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
	}
	
	void Update(){

	}

	void OnTriggerStay (Collider other)
	{

		// If the colliding gameobject is the player...
		if(other.gameObject == player)
		{
			print ("Detected Cone");
			enemySight.playerInSight = true;
			lastPlayerSighting.position = player.transform.position;
			// ... raycast from the camera towards the player.
			/*Vector3 relPlayerPos = player.transform.position - transform.position;
			RaycastHit hit;
			
			if(Physics.Raycast(transform.position, relPlayerPos, out hit))
			
				// If the raycast hits the player...
				if(hit.collider.gameObject == player){

					
					// ... set the last global sighting of the player to the player's position.
					lastPlayerSighting.position = player.transform.position;
		
			}*/

	}
   }

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == player) {
			print ("Undetected Cone");

		}

	}
}

