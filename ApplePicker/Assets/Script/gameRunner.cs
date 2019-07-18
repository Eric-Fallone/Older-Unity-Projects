using UnityEngine;
using System.Collections;

public class gameRunner : MonoBehaviour {
	public GUIText scoreText;
	public GUIText highText;
	public GUIText gameOverText;
	public AppleTree ap;
	int score;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("highScore") == true) {
			 highText.text ="High Score: "+ PlayerPrefs.GetInt("highScore");
		}
	}
	
	// Update is called once per frame

	public void addScore(int up){
		score = score + up;
		scoreText.text = "Score: " + score;
	}
	public void gameOver(){
		ap.gameRunning = false;
		gameOverText.text = "Game Over";
		if (PlayerPrefs.HasKey ("highScore") == true) {
			if(PlayerPrefs.GetInt("highScore")< score){
				PlayerPrefs.SetInt("highScore",score);
			}
		}
		PlayerPrefs.SetInt("highScore",score);
	}

}
