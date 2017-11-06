using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {
	
	//const string privateCode = "Lue5PnQTNUqjhU4Z3LT6Ywn87duzf2Lk67IgJpjGH0Tw";
	//const string publicCode = "59f9c90a6b2b65dd70927a7a"; 
	//const string webURL = "http://dreamlo.com/lb/"; 
	
	//public Highscore[] highscoresList;
	//DisplayHighscores highscoreDisplay;
	//static MainMenuController instance;
	
	//void Awake() {
		//highscoreDisplay = GetComponent<DisplayHighscores> ();
		//instance = this;
	//}
		
	[SerializeField]
	private GameObject leaderboardpanel ;
	
	public void PlayGame() {
		Application.LoadLevel ("Gameplay");
	}
	
	public void showPanel() {
		Time.timeScale = 0f;
		leaderboardpanel.SetActive(true);
		
	}
	
	public void GoToMenu() {
		Time.timeScale = 1f;
		Application.LoadLevel ("MainMenu");
	}
}
	
	
	
	
