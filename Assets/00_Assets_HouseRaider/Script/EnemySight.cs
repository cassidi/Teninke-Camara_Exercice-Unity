using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {

	         
	public bool playerInSight;                      
	public Vector3 personalLastSighting; 
	
               
	private LastPlayerSighting lastPlayerSighting;  
	private GameObject player;                      
	private SphereCollider col;        
	
	private Vector3 previousSighting;
	void Awake ()
	{
		col = GetComponent<SphereCollider> ();
		lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
		player = GameObject.FindGameObjectWithTag(Tags.girl);


		personalLastSighting = lastPlayerSighting.resetPosition;
		previousSighting = lastPlayerSighting.resetPosition;
	}
	
	
	void Update()
	{
		if(playerInSight)
			print("Detected");

		if(lastPlayerSighting.position != previousSighting)
			personalLastSighting = lastPlayerSighting.position;
		

		previousSighting = lastPlayerSighting.position;
	}
	
	
	void OnTriggerStay (Collider other)
	{
		if(other.gameObject == player)
		{
			//lastPlayerSighting.position = player.transform.position;
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		float sous1 = ((transform.position.x) - (other.transform.position.x));
		float sous2 = ((transform.position.y) - (other.transform.position.y));
		float sous3 = ((transform.position.z) - (other.transform.position.z));
		float distance = Mathf.Sqrt((Mathf.Pow(sous1, 2)+
		                             Mathf.Pow(sous2, 2)+
		                             Mathf.Pow(sous3, 2)
		                            ));
		print ("Distance : "+distance);
		if (other.gameObject == player && distance > col.radius) {
						print ("Undetected");
						playerInSight = false;
						lastPlayerSighting.position = new Vector3 (1000f, 1000f, 1000f);
		}
	}
	
	

}