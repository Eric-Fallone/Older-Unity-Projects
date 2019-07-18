using UnityEngine;
using System.Collections;

public class BackGroundMovingStars : MonoBehaviour {

	public GameObject one;
		public GameObject two;
	public float speed;
	public float resetYPos;

	Vector3 oneStart;

	// Use this for initialization
	Vector3 target;
	void Start(){
		target=new Vector3(0f,resetYPos-1,one.transform.position.z);
		oneStart = one.transform.position;
	}

	// Update is called once per frame
	void Update () {
		one.transform.position = new Vector3 (target.x,one.transform.position.y -speed *Time.deltaTime ,target.z);
		two.transform.position = new Vector3 (target.x,two.transform.position.y -speed *Time.deltaTime ,target.z);

		if(one.transform.position.y<resetYPos){
			one.transform.position=oneStart;
		}

		if(two.transform.position.y<resetYPos){
			two.transform.position=oneStart;
		}

	}
}
