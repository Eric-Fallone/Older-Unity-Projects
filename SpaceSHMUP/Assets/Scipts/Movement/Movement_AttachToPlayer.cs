using UnityEngine;
using System.Collections;
[RequireComponent (typeof (Rigidbody))]
public class Movement_AttachToPlayer : MonoBehaviour {

	public float delayInitial;
	public float attachmentLength;




	// Use this for initialization
	void Start () {
		if(delayInitial==0){
			this.transform.SetParent(Movement_Player.S.transform);
		}
		delayInitial = Time.time + delayInitial;
		attachmentLength = delayInitial + attachmentLength;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time>delayInitial){
			this.transform.SetParent(Movement_Player.S.transform);
		}
		if(Time.time>attachmentLength){
			this.transform.SetParent(null);
		}
	}
}
