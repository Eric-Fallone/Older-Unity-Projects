using UnityEngine;
using System.Collections;

public class Movement_Homing : MonoBehaviour {

	public Vector3 target;
	public float speed;
	public float delay;
	public float life;
	// Use this for initialization
	void Start () {
			if(PlayerLogic.S==null){
			//	this.transform.rotation=Quaternion.Euler( new Vector3(0,0,180));
			Debug.Log("asd");
				return;
			}
			
			Quaternion newRotation = Quaternion.LookRotation(transform.position - PlayerLogic.S.transform.position, Vector3.forward);
			newRotation.x = 0;
			newRotation.y = 0;
			this.transform.rotation = newRotation;
			//search for the nearest enemy that has a greater y value then the player

	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
		transform.position += transform.up * Time.deltaTime * speed;
	//	transform.LookAt (target,Vector3.up);
	}
}
