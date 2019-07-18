using UnityEngine;
using System.Collections;

public class Scale_by_time : MonoBehaviour {

	public Vector2 startingScale;
	public float speed;
	Vector3 target;
	// Use this for initialization
	void Start () {
		target = this.transform.localScale;
		this.transform.localScale = startingScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.localScale != target) {
			this.transform.localScale = Vector3.Lerp (this.transform.localScale, target, Time.deltaTime * speed);
		} else {
			GameObject.Destroy(this);
		}
	}
}
