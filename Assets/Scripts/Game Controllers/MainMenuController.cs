using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {
	
	[SerializeField]
	private GameObject leaderboardpanel ;
	
	public void PlayGame() {
		Application.LoadLevel ("Gameplay");
	}
	//public void LeaderBoard(){
		//showPanel();
	//}
	public void showPanel() {
		Time.timeScale = 0f;
		leaderboardpanel.SetActive(true);
		
	}

}
