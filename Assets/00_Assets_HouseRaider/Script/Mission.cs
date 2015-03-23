using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mission : MonoBehaviour {
	

	
	public GUIText MissionText;
	public float fadeSpeed = 5f;
	public bool entrance;
	public GameObject cube;
	private GameObject player; 
	
	void Awake () 
		
	{
		
		MissionText = cube.GetComponentInChildren<GUIText> ();
		MissionText.color = Color.clear;
		player = GameObject.FindGameObjectWithTag(Tags.girl);
	}
	
	void Update () 
		
	{
		ColorChange();
	}
	
	void OnTriggerStay (Collider other)
	{
		if(other.gameObject == player)
		{
			entrance = true;
		} 
		
	}
	
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == player)
		{
			entrance = false;                       
			
		} 
		
	}
	
	void ColorChange () 
		
	{
		
		if (entrance)
		{
			MissionText.color = Color.Lerp (MissionText.color, Color.white, fadeSpeed * Time.deltaTime);
			
		}
		
		if (!entrance)
		{
			MissionText.color = Color.Lerp (MissionText.color, Color.clear, fadeSpeed * Time.deltaTime);
		}
		
	}
}