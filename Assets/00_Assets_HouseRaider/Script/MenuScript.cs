using UnityEngine;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script
using System.Collections;

public class MenuScript : MonoBehaviour 
{
	public Canvas quitMenu;
	private Button startText;
	private Button exitText;
	
	
	void Start ()
		
	{
		quitMenu = quitMenu.GetComponent<Canvas>();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;
		
	}
	


	
	
	public void ExitGame () //This function will be used on our "Yes" button in our Quit menu
		
	{
		Application.Quit(); //this will quit our game. Note this will only work after building the game
		
	}
	
	
	
	
	
}