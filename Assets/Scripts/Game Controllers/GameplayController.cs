using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameplayController : MonoBehaviour {
	/*********************************************************************************/
	const string privateCode = "Lue5PnQTNUqjhU4Z3LT6Ywn87duzf2Lk67IgJpjGH0Tw"; // generated private code for leaderboard
	const string publicCode = "59f9c90a6b2b65dd70927a7a"; //generated public code for leaderboard
	const string webURL = "http://dreamlo.com/lb/"; //leaderboard url
	private string username = "";
	private int score;
	
/*********************************************************************************************/	
	
	public void AddNewHighscore(string username, int score) {
		StartCoroutine(UploadNewHighscore(username,score));
	}

	IEnumerator UploadNewHighscore(string username, int score) {
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty(www.error))
			print ("Upload Successful");
		else {
			print ("Error uploading: " + www.error);
		}
	}
/**************************************************************************************/	
	[SerializeField]
	private GameObject pausePanel;
	
	[SerializeField]
	private Button restartGameButton;

	[SerializeField]
	private Text scoreText, pauseText;

/***************************************************************************************************************/	
	
	
	public InputField inputField;
	
	void awake(){
		inputField = GameObject.Find("InputField").GetComponent<InputField>();
	}
	
	void Start () {
		scoreText.text = score + "M";
		StartCoroutine (CountScore());
	}

	IEnumerator CountScore() {
		yield return new WaitForSeconds(0.6f);
		score++;
		scoreText.text = score + "M";
		StartCoroutine (CountScore());
	}

	void OnEnable() {
		PlayerDied.endGame += PlayerDiedEndTheGame;
	}

	void OnDisable() {
		PlayerDied.endGame -= PlayerDiedEndTheGame;
	}
	void PlayerDiedEndTheGame() {
		pauseText.text = "Retry";
		pausePanel.SetActive (true);
		restartGameButton.onClick.RemoveAllListeners ();
		restartGameButton.onClick.AddListener (() => RestartGame());
		Time.timeScale = 0f;

	}
	
	public void setUsername(string name){
		username = name;
		AddNewHighscore(username,score);		// call add new high score method which works fine already
	}
	
	
	public void PauseButton() {
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
		restartGameButton.onClick.RemoveAllListeners ();
		restartGameButton.onClick.AddListener (() => ResumeGame());
	}

	public void GoToMenu() {
		Time.timeScale = 1f;
		Application.LoadLevel ("MainMenu");
	}

	public void ResumeGame() {
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void RestartGame() {
		Time.timeScale = 1f;
		Application.LoadLevel ("Gameplay");
	}

}
















  

	
















































