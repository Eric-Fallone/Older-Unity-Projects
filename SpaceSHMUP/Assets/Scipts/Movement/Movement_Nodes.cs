using UnityEngine;
using System.Collections;
[RequireComponent (typeof (Rigidbody))]
public class Movement_Nodes : MonoBehaviour {
	public Vector3[] change;
	public float[] speed;
	//public float[] delay;
	public Vector3 start;

	public Vector3 target;
	public float curSpeed;

	// Use this for initialization
	void Start () {
		if (change.Length != speed.Length) {
			//error checking for sanity
			Debug.LogError(this.gameObject.name+" in wave "+this.transform.parent.name+" : has an error with the length of the arrays");
		}
		start = this.transform.position;
		//starts the coroutine for targeting
		StartCoroutine (targetChooser());
	}
	
	// Update is called once per frame
	void Update () {
		//goes to target
		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * curSpeed);
	}
	IEnumerator targetChooser(){
		for(int c=0;c<change.Length;c++){
			target=start + change[c];
			curSpeed=speed[c];
			while(this.transform.position!=target){
				yield return new WaitForSeconds(.01f);
			}
			//yield return new WaitForSeconds(delay[c]);
			start=this.transform.position;
		}
		yield return new WaitForSeconds(1f);
	}
}
