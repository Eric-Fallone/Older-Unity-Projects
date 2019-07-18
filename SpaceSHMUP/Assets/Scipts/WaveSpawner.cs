using UnityEngine;
using System.Collections;
//need this inorder to see multi array in the inspector

public class WaveSpawner : MonoBehaviour {
	public static WaveSpawner S;
	public GameObject[] enemies;

	public float[] delay;

	public int waveNum=0;

	public string curLevel;

	public bool doneSpawning=false;

	// Use this for initialization
	void Start () {
		S = this;

		curLevel= Application.loadedLevelName;

		if(enemies.Length != delay.Length){
			Debug.Log("Wave spawner does not have equal lengths of arrays ");
		}

		StartCoroutine (swawnWaves());
	}

	void Update(){
		if(Input.GetKeyDown("r")==true){
			Application.LoadLevel(curLevel);
		}
		if(doneSpawning==true && GameObject.FindGameObjectsWithTag("Enemy").Length==0){
			HUD.S.endLevel();
			doneSpawning=false;
		}
	}


	IEnumerator swawnWaves(){
		//delay for start of game 

		//yield return new WaitForSeconds(1f);

		for(;waveNum<enemies.Length;waveNum++){
			//next wave
			yield return new WaitForSeconds(delay[waveNum]);
			enemies[waveNum].SetActive(true);
		}
		doneSpawning = true;
	}
}