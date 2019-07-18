using UnityEngine;
using System.Collections;
[RequireComponent (typeof (Rigidbody))]
public class Movement_Changing_Random : MonoBehaviour {
	public float speedMinStart;
	public float speedMaxStart;

	public float speedMinSecond;
	public float speedMaxSecond;

	public float delay;
	public float sndDelay;

	public float minAngleStart;
	public float maxAngleStart;

	public float minAngleSecond;
	public float maxAngleSecond;

	float sndX;
	float sndY;

	float sndXs;
	float sndYs;
	
	void Start (){
		//initial speed

		sndX = Random.Range (minAngleStart, maxAngleStart);
		sndY = Random.Range (speedMinStart, speedMaxStart);

		sndXs = Random.Range (minAngleSecond, maxAngleSecond);
		sndYs = Random.Range (speedMinSecond, speedMaxSecond) ;

		delay = Time.time+delay;
		sndDelay = delay + sndDelay;
	}

	void Update(){


		//first Speed
		if (Time.time < delay) {

			Vector3 target = this.transform.position;
			target.x += sndX;
			transform.position = Vector3.MoveTowards (this.transform.position,
		                                         target,
		                                         Time.deltaTime * Mathf.Abs (sndX));
			target = this.transform.position;
			target.y += sndY;
			transform.position = Vector3.MoveTowards (this.transform.position,
		                                         target,
		                                         Time.deltaTime * Mathf.Abs (sndY));

			//secound speed


		}
		else{

			transform.position = Vector3.MoveTowards(transform.position,
			                                         this.transform.position +new Vector3(sndXs,sndYs,0f),
			                                         Time.deltaTime * Mathf.Abs(sndY));
			//stops if statement from happening again
			if(Time.time > sndDelay)
				//destroys this code only
				GameObject.Destroy(this);
		}
	}
}
