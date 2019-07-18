using UnityEngine;
using System.Collections;

public class Movement_Rotate_To_player : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
		if(PlayerLogic.S.numLives>0){
			Quaternion newRotation = Quaternion.LookRotation(transform.position - PlayerLogic.S.transform.position, Vector3.forward);
			newRotation.x = 0;
			newRotation.y = 0;

			this.transform.rotation = newRotation;
		}
	}
}
