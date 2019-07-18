using UnityEngine;
using System.Collections;
[RequireComponent (typeof (Rigidbody))]
public class Movement_Changing : MonoBehaviour {

	public Vector2 startSpeed;
	public Vector2 endSpeed;
	public float delay;
	public float delaySnd;

	
	void Start (){
		//initial speed
		
		delay = Time.time+delay;
		delaySnd = delay + delaySnd;
	}
	
	void Update(){
		
		
		//first Speed
		if (Time.time < delay) {
			Vector3 target = this.transform.position;
			target.x += startSpeed.x;
			transform.position = Vector3.MoveTowards (this.transform.position,
			                                          target,
			                                          Time.deltaTime * Mathf.Abs (startSpeed.x));
			target = this.transform.position;
			target.y += startSpeed.y;
			transform.position = Vector3.MoveTowards (this.transform.position,
			                                          target,
			                                          Time.deltaTime * Mathf.Abs (startSpeed.y));
			
			//secound speed
			
			
		}
		else{
			Vector3 target = this.transform.position;
			target.x += endSpeed.x;
			transform.position = Vector3.MoveTowards (this.transform.position,
			                                          target,
			                                          Time.deltaTime * Mathf.Abs (endSpeed.x));
			target = this.transform.position;
			target.y += endSpeed.y;
			transform.position = Vector3.MoveTowards (this.transform.position,
			                                          target,
			                                          Time.deltaTime * Mathf.Abs (endSpeed.y));
		
			//stops if statement from happening again
			if(Time.time > delaySnd)
				//destroys this code only
				GameObject.Destroy(this);
		}
	}
}
