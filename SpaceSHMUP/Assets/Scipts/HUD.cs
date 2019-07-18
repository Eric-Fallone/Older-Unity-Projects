using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	public static HUD S;
	public GUIText gameOver;

	public GUIText score;
	public int scoreValue;
	public GUIText endLeveltext;

	public GameObject[] lifeModel;
	public GameObject[] shieldModel;

	public GUIText nextLifeScore;
	public int nextLife;

	public string nextLevel;

	void Start(){
		S = this;
		gameOver.text = "";
		score.text = "Score: 0";
		nextLifeScore.text="Nex life in: "+nextLife;
		if (lifeModel.Length != 3) {
			Debug.LogError("Incorrect size of arrat for lives model");
		}
		lifeModel [0].SetActive (true);
		lifeModel [1].SetActive (true);
		lifeModel [2].SetActive (false);

		shieldModel [0].SetActive (true);
		shieldModel [1].SetActive (false);
		shieldModel [2].SetActive (false);

		endLeveltext.text = "";
	}

	public void setGameOverText(){
		gameOver.text = "Game Over\n'r' to reset";
	}
	public void updateScore(int i){
		if(PlayerLogic.S.numLives<1){
			return;
		}
		scoreValue += i;
		score.text = "Score: "+scoreValue;
		if(scoreValue>=nextLife){
			gainLife();
			nextLife+=1000;
			nextLifeScore.text="Nex life in: "+nextLife;
		}
	}
	public void loseLife(){
		//remove a model of the the ship
		if(PlayerLogic.S.numLives<1){
			return;
		}
		lifeModel [PlayerLogic.S.numLives-1].SetActive(false);
	}
	public void gainLife(){
		//adds a model of the the ship
		if(PlayerLogic.S.numLives<1){
			return;
		}
		if(PlayerLogic.S.numLives<4){
			PlayerLogic.S.numLives++;
		}
		lifeModel [PlayerLogic.S.numLives-2].SetActive(true);
	}

	public void useShield(){
		shieldModel [PlayerLogic.S.numShields].SetActive (false);
	}
	public void gainShield(){
		shieldModel [PlayerLogic.S.numShields].SetActive (true);
	}

	public void endLevel(){
		StartCoroutine (endLevelHelper ());
	}

	IEnumerator endLevelHelper(){
		endLeveltext.text="Final Stats\n";
		yield return new WaitForSeconds(1f);
		if(PlayerLogic.S.shotsFired==0){
			endLeveltext.text+="Accuracy: Pacifist\n";
		}else{
			endLeveltext.text+="Accuracy: "+((((float)PlayerLogic.S.shotsFired-(float)PlayerLogic.S.shotsMissed)/(float)PlayerLogic.S.shotsFired)*100)+"%\n";
		}
		yield return new WaitForSeconds(1f);
		endLeveltext.text+="Score: "+scoreValue+"\n";
	}
}
