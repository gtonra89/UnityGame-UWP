using UnityEngine;
using System.Collections;

public class Highscores : MonoBehaviour {

	const string privateCode = "Lue5PnQTNUqjhU4Z3LT6Ywn87duzf2Lk67IgJpjGH0Tw";
	const string publicCode = "59f9c90a6b2b65dd70927a7a"; 
	const string webURL = "http://dreamlo.com/lb/";

	DisplayHighscores Display;
	public Highscore[] list;
	static Highscores instance;
	
	void Awake() {
		Display = GetComponent<DisplayHighscores> ();
		instance = this;
	}


	public void DownloadHighscores() {
		StartCoroutine("DownloadFromDatabase");
	}

	IEnumerator DownloadFromDatabase() {
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;
		
		if (string.IsNullOrEmpty (www.error)) {
			Format (www.text);
			Display.OnHighscoresDownloaded(list);
		}
		else {
			print ("Error Downloading: " + www.error);
		}
	}

	void Format(string textStream) {
		string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		list = new Highscore[entries.Length];

		for (int i = 0; i <entries.Length; i ++) {
			string[] entryInfo = entries[i].Split(new char[] {'|'});
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			list[i] = new Highscore(username,score);
			print (list[i].username + ": " + list[i].score);
		}
	}

}

public struct Highscore {
	public string username;
	public int score;

	public Highscore(string _username, int _score) {
		username = _username;
		score = _score;
	}

}
