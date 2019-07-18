using UnityEngine;
using System.Collections;

public class PlayerWeapons: MonoBehaviour {
	public static PlayerWeapons S;
	public GameObject[] Projectiles;
	public float[] delays;
	public int selProj=0;
	public Transform Cannon;


	public float nextFire;
	public float delay;

	// Use this for initialization
	void Start () {
		S = this;
		if(delays.Length!=Projectiles.Length){
			Debug.LogError("incorrect lengths for arrays in player weapons");
		}
	}
	

	void Update () {
		if(PlayerLogic.S.numLives<1){
			return;
		}

		//fire weapon if mouse is down
		if (Input.GetAxis("Jump")==1) {
			//check to see if you can fire again
			if (Time.time < nextFire) {
				return;
			}
			//update total shots
			PlayerLogic.S.shotsFired++;
			if(this.selProj==2){
				PlayerLogic.S.shotsFired+=2;
			}

			Instantiate (Projectiles [selProj], Cannon.position, Quaternion.identity);
			delay = delays [selProj];
			nextFire = Time.time + delay;

		}
	}
	public void pickUpWeapon(int i){
		selProj = i;
		nextFire = Time.time;
	}



}
