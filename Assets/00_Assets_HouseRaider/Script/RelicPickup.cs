using UnityEngine;
using System.Collections;

public class RelicPickup : MonoBehaviour {

	public AudioClip Grab;                       
	
	private GameObject player;                      
	private PlayerInventory playerInventory;        


	
	                                     

	
	void Awake ()
	{

		player = GameObject.FindGameObjectWithTag(Tags.girl);
		playerInventory = player.GetComponent<PlayerInventory>();
		//stinger = transform.Find("Stinger").audio;

	}
	
	
	void OnTriggerEnter (Collider other)
	{

				if (other.gameObject == player) {

						AudioSource.PlayClipAtPoint (Grab, transform.position);
			

						playerInventory.hasRelic = true;
			

						Destroy (gameObject);
					

				}
		}



						
		}
	


